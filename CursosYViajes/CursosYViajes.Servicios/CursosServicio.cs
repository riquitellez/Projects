using CursosYViajes.DatosEF;
using CursosYViajes.DatosEF.Repositorios;
using CursosYViajes.Models.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CursosYViajes.Servicios
{
    public class CursosServicio
    {
        private CursosRepositorio _repositorio;

        public CursosServicio(CursosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public CursosServicio()
        {
            _repositorio = new CursosRepositorio();
        }
        public CursosServicio(ContextoCursoYViajes contexto)
        {
            _repositorio = new CursosRepositorio(contexto);
        }

        public IndexModel GetCursos(int numCursos = 100)
        {
            var cursos = _repositorio.GetCursos(numCursos);
            var paises = _repositorio.VerPaises();
            paises.Add(Guid.Empty, "Busque por país");
            paises = paises.OrderBy(x => x.Key).ToDictionary(x=>x.Key,x=>x.Value);
            var buscador = new BuscadorCursosModel
            {
                ComboPaises = paises,
                IdPais = paises.First().Key,
                TextoBuscador = string.Empty
            };
            return new IndexModel
            {
                Cursos = cursos,
                Buscador = buscador
            };
        }
        public IDictionary<Guid, string> VerPaises()
        {
            return _repositorio.VerPaises();
        }

        public void CrearCurso(AnadirCursoModel model)
        {
            if (model.IdPais != null && string.IsNullOrWhiteSpace(model.PaisNuevo))
            {
                _repositorio.CrearCurso(model.Nombre, model.IdPais.Value, model.PrecioPorSemana);
            }
            else _repositorio.CrearCursoYPais(model.Nombre, model.PaisNuevo, model.PrecioPorSemana);
        }

        public EditarCursoModel ObtenerCursoParaEditar(Guid idCurso)
        {
            return _repositorio.ObtenerCursoParaEditar(idCurso);
        }
        public void EditarCurso(EditarCursoModel model)
        {
            if (model.IdPais != null && string.IsNullOrWhiteSpace(model.PaisNuevo))
            {
                _repositorio.EditarCurso(model.Nombre, model.IdPais.Value, model.IdCurso, model.FechaDeAlta, model.PrecioPorSemana);
            }
            else _repositorio.EditarCursoConPaisNuevo(model.Nombre, model.PaisNuevo, model.IdCurso, model.FechaDeAlta, model.PrecioPorSemana);
        }

        public DetallesCursoModel ObtenerDetallesCurso(Guid idCurso)
        {
            DetallesCursoModel curso = _repositorio.ObtenerDetallesCurso(idCurso);
            return curso;
        }

        public void ReactivarAlta(Guid idCurso)
        {
            _repositorio.ReactivarAlta(idCurso);
        }
        public void DarDeBaja(Guid idCurso, DateTime? fechaDeBaja)
        {
            _repositorio.DarDeBaja(idCurso, fechaDeBaja);
        }

        public MatricularAlumnoCursoModel ObtenerAlumnosParaMatricula(Guid idCurso)
        {
            MatricularAlumnoCursoModel model = _repositorio.ObtenerAlumnosParaMatricula(idCurso);
            return model;
        }

        public DeleteMatriculaModel ObtenerDatosParaEliminarMatricula(Guid idCurso, Guid idAlumno)
        {
            DeleteMatriculaModel model = _repositorio.ObtenerDatosParaEliminarMatricula(idCurso, idAlumno);
            return model;
        }

        public void EliminarMatricula(Guid idCursoPorAlumno, DateTime fechaDeBaja)
        {
            _repositorio.EliminarMatricula(idCursoPorAlumno, fechaDeBaja);
        }

        public void ReactivarAltaMatricula(Guid idCursoPorAlumno)
        {
            _repositorio.ReactivarAltaMatricula(idCursoPorAlumno);
        }

        public DetallesMatriculaModel ObtenerDetallesMatricula(Guid idCursoPorAlumno)
        {
            DetallesMatriculaModel model = _repositorio.ObtenerDetallesMatricula(idCursoPorAlumno);
            return model;
        }

        public void ModificarFechasMatricula(Guid idCursoPorAlumno, DateTime fechaDeAlta, DateTime? fechaDeBaja)
        {
            _repositorio.ModificarFechasMatricula(idCursoPorAlumno, fechaDeAlta, fechaDeBaja);
        }
        public IndexModel BuscarCursos(Guid idPais, string texto)
        {
            var cursos = _repositorio.GetCursos(idPais, texto);
            var paises = _repositorio.VerPaises();
            paises.Add(Guid.Empty, "Busque por país");
            paises = paises.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            var buscador = new BuscadorCursosModel
            {
                ComboPaises = paises,
                IdPais = idPais,
                TextoBuscador = texto
            };
            return new IndexModel
            {
                Cursos = cursos,
                Buscador = buscador
            };            
        }

        /*public CalculadorPrecioModel ObtenerDatosParaCalcularPrecio(string nombreCurso, Guid idCurso, DateTime fechaEntrada, int numeroSemanas, string tipoDeHospedaje)
        {
            CalculadorPrecioModel model = _repositorio.ObtenerDatosParaCalcularPrecio(nombreCurso, idCurso, fechaEntrada, numeroSemanas, tipoDeHospedaje);
            return model;
        }*/
    }
}
