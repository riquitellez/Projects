using CursosYViajes.DatosEF;
using CursosYViajes.DatosEF.Repositorios;
using CursosYViajes.Models.Precios;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursosYViajes.Servicios
{
    public class PreciosServicio
    {
   
        private PreciosRepositorio _repositorio;

        public PreciosServicio(PreciosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public PreciosServicio()
        {
            _repositorio = new PreciosRepositorio();
        }
        
        public PreciosServicio(ContextoCursoYViajes contexto)
        {
            _repositorio = new PreciosRepositorio(contexto);
        }

        public CursoPrecioModel ObtenerPrecios(Guid idCurso)
        {
            return _repositorio.ObtenerPrecios(idCurso);
        }

        public IEnumerable<CursoModel> GetCursos()
        {
            return _repositorio.GetCursos();
        }

        public void GuardarPreciosCurso(Guid idCurso, IDictionary<int, double> precioPorSemana)
        {
            _repositorio.GuardarPreciosCurso(idCurso, precioPorSemana);
        }

        public HospedajePrecioModel ObtenerPreciosHospedaje(Guid idCurso, int idTipoHospedaje=1)
        {
            return _repositorio.ObtenerPreciosHospedaje(idCurso, idTipoHospedaje);
        }

        public void GuardarPreciosHospedaje(Guid idCurso, int idHospedaje, IDictionary<int,double> precioPorSemana)
        {
            _repositorio.GuardarPreciosHospedaje(idCurso, idHospedaje, precioPorSemana);
        }

        public CalculadorPreciosModel ObtenerDatosParaCalcularPrecio()
        {
            var model = new CalculadorPreciosModel
            {
                Cursos = _repositorio.ObtenerCursosDiccionario(),
                SemanasIniciales = RellenarSemanas(),
                SemanasFinales = RellenarSemanas(),
                TiposDeHospedaje = _repositorio.ObtenerTiposDeHospedajeDiccionario(),
                PrecioCurso = 0,
                PrecioHospedaje = 0,
                PrecioTotal = 0
            };

            return model;
        }

        private IDictionary<int, string> RellenarSemanas()
        {
            DateTime dt = new DateTime(2019, 01, 07);
            var diccionarioSemanas = new Dictionary<int, string>();
            for (int i = 1; i<=53; i++)
            {
                DateTime dtSemana = dt.AddDays((i - 1) * 7);
                diccionarioSemanas.Add(i, string.Format("Del {0} al {1}", dtSemana.ToShortDateString(), dtSemana.AddDays(6).ToShortDateString()));
            }
            return diccionarioSemanas;
        }

        public CalculadorPreciosModel CalcularPrecioTotalCurso(Guid idCursoSeleccionado, int tipoDeHospedajeSeleccionado, int idSemanaInicialSeleccionada, int idSemanaFinalSeleccionada)
        {
            var model = _repositorio.CalcularPrecioTotalCurso(idCursoSeleccionado, tipoDeHospedajeSeleccionado, idSemanaInicialSeleccionada, idSemanaFinalSeleccionada);
            model.SemanasIniciales = RellenarSemanas();
            model.SemanasFinales = RellenarSemanas();
            return model;
        }
    }
}
