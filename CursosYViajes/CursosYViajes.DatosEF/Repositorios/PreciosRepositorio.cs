using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CursosYViajes.Models.Precios;

namespace CursosYViajes.DatosEF.Repositorios
{
    public class PreciosRepositorio
    {
        private ContextoCursoYViajes _contexto;

        public PreciosRepositorio(ContextoCursoYViajes contexto)
        {
            _contexto = contexto;
        }
        public PreciosRepositorio()
        {
            _contexto = new ContextoCursoYViajes();
        }

        public IEnumerable<CursoModel> GetCursos()
        {
            var cursos = _contexto.Cursos.Select(x => new
            {
                x.IdCurso,
                x.Nombre,
                nombrePais = x.Pais.Nombre
            });

            return cursos.Select(x => new CursoModel
            {
                IdCurso = x.IdCurso,
                Nombre = x.Nombre,
                Pais = x.nombrePais
            });
        }

        public CursoPrecioModel ObtenerPrecios(Guid idCurso)
        {
            var precios = _contexto.Cursos.Where(x => x.IdCurso == idCurso).Select(x => new
            {
                idCurso,
                x.Nombre,
                nombrePais = x.Pais.Nombre,
                precioPorSemana = x.PrecioPorCursosPorSemanas.Select(y => new
                {
                    y.NumSemana,
                    y.Precio
                }).ToList()
            }).Single();

            return new CursoPrecioModel
            {
                IdCurso = idCurso,
                Nombre = precios.Nombre,
                Pais = precios.nombrePais,
                PrecioPorSemana = precios.precioPorSemana.ToDictionary(x=>x.NumSemana, x=>x.Precio)
            };
        }

        public void GuardarPreciosHospedaje(Guid idCurso, int idHospedaje, IDictionary<int, double> preciosPorSemana)
        {
            var preciosSemana = _contexto.PrecioHospedajePorCursoPorSemanas.Where(x => x.IdCurso == idCurso && x.IdTipoDeHospedaje == idHospedaje).ToList();
            foreach (var pps in preciosPorSemana)
            {
                if (preciosSemana.Any(x => x.NumSemana == pps.Key))
                {
                    preciosSemana.Single(x => x.NumSemana == pps.Key).ActualizarPrecioPorSemana(pps.Value);
                }
                else
                {
                    PrecioHospedajePorCursoPorSemana pphpcps = new PrecioHospedajePorCursoPorSemana(idCurso, idHospedaje, pps.Key, pps.Value);
                    _contexto.Add(pphpcps);
                }
            }
            _contexto.SaveChanges();
        }

        public IDictionary<Guid, string> ObtenerCursosDiccionario()
        {
            var cursos = _contexto.Cursos.ToDictionary(x=>x.IdCurso, x=> x.Nombre);
            return cursos;
        }

        public IDictionary<int, string> ObtenerTiposDeHospedajeDiccionario()
        {
            var tiposDeHospedaje = _contexto.TipoHospedaje.ToDictionary(x => x.Id, x => x.Nombre);
            return tiposDeHospedaje;
        }

        public CalculadorPreciosModel CalcularPrecioTotalCurso(Guid idCursoSeleccionado, int tipoDeHospedajeSeleccionado, int idSemanaInicialSeleccionada, int idSemanaFinalSeleccionada)
        {
            var calculoPrecioCurso = _contexto.Cursos.Where(x => x.IdCurso == idCursoSeleccionado)
                .Select(x => new
                {
                    precioHospedaje = x.PrecioPorHospedajesPorCursosPorSemanas
                        .Where(y => y.IdTipoDeHospedaje == tipoDeHospedajeSeleccionado && y.NumSemana >= idSemanaInicialSeleccionada && y.NumSemana <= idSemanaFinalSeleccionada)
                        .Select(y => y.Precio).Sum(),
                    precioCurso = x.PrecioPorCursosPorSemanas
                        .Where(y => y.NumSemana >= idSemanaInicialSeleccionada && y.NumSemana <= idSemanaFinalSeleccionada)
                        .Select(y => y.Precio).Sum()
                }).Single();

            CalculadorPreciosModel model = new CalculadorPreciosModel
            {
                Cursos = _contexto.Cursos.ToDictionary(x => x.IdCurso, x => x.Nombre),
                IdCursoSeleccionado = idCursoSeleccionado,
                TiposDeHospedaje = _contexto.TipoHospedaje.ToDictionary(x => x.Id, x => x.Nombre),
                TipoDeHospedajeSeleccionado = tipoDeHospedajeSeleccionado,
                IdSemanaInicialSeleccionada = idSemanaInicialSeleccionada,
                IdSemanaFinalSeleccionada = idSemanaFinalSeleccionada,
                PrecioCurso = calculoPrecioCurso.precioCurso,
                PrecioHospedaje = calculoPrecioCurso.precioHospedaje,
                PrecioTotal = calculoPrecioCurso.precioCurso + calculoPrecioCurso.precioHospedaje
            };
            return model;
        }

        public void GuardarPreciosCurso(Guid idCurso, IDictionary<int, double> preciosPorSemana)
        {
            var preciosSemana = _contexto.PrecioPorCursoPorSemana.Where(x => x.IdCurso == idCurso).ToList();
            foreach (var pps in preciosPorSemana)
            {
                if (preciosSemana.Any(x => x.NumSemana == pps.Key))
                {
                    preciosSemana.Single(x => x.NumSemana == pps.Key).ActualizarPrecioPorSemana(pps.Value);
                }
                else
                {
                    PrecioPorCursoPorSemana ppcps = new PrecioPorCursoPorSemana(idCurso, pps.Key, pps.Value);
                    _contexto.Add(ppcps);
                }
                
            }
            _contexto.SaveChanges();
        }
        public HospedajePrecioModel ObtenerPreciosHospedaje(Guid idCurso, int tipoHospedaje = 1)
        {
            var precios = _contexto.Cursos.Where(x => x.IdCurso == idCurso).Select(x => new
            {
                idCurso,
                x.Nombre,
                nombrePais = x.Pais.Nombre,
                precioPorSemana = x.PrecioPorHospedajesPorCursosPorSemanas.Where(y => y.IdTipoDeHospedaje == tipoHospedaje).Select(y => new
                {
                    y.NumSemana,
                    y.Precio
                }).ToList()
            }).Single();

            return new HospedajePrecioModel
            {
                IdCurso = idCurso,
                Nombre = precios.Nombre,
                Pais = precios.nombrePais,
                PrecioPorSemana = precios.precioPorSemana.ToDictionary(x => x.NumSemana, x => x.Precio),
                TipoHospedajeSeleccionado = tipoHospedaje,
                TipoHospedaje = _contexto.TipoHospedaje.ToDictionary(x => x.Id, x => x.Nombre)
            };
        }
    }
}
