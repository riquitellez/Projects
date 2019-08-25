using CursosYViajes.DatosEF;
using CursosYViajes.DatosEF.Repositorios;
using CursosYViajes.Models.Alumnos;
using System;
using System.Collections.Generic;

namespace CursosYViajes.Servicios
{
    public class AlumnosServicio
    {
        private AlumnosRepositorio _repositorio;

        public AlumnosServicio(AlumnosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public AlumnosServicio()
        {
            _repositorio = new AlumnosRepositorio();
        }
        public AlumnosServicio(ContextoCursoYViajes contexto)
        {
            _repositorio = new AlumnosRepositorio(contexto);
        }

        public IndexModel ObtenerAlumnos(int numAlumnos = 100)
        {
            BuscadorAlumnoModel model = new BuscadorAlumnoModel();
            var alumnos = _repositorio.GetAlumnos(numAlumnos);
            return new IndexModel
            {
                Buscador = model,
                Alumnos = alumnos
            };
        }

        public IndexModel BuscarAlumno(string textoBuscador)
        {
            var alumnos = _repositorio.BuscarAlumno(textoBuscador);
            return new IndexModel
            {
                Alumnos = alumnos,
                Buscador = new BuscadorAlumnoModel
                {
                    TextoBuscador = textoBuscador
                }
            };
        }

        public void AnadirAlumno(AnadirAlumnoModel model)
        {
            _repositorio.AnadirAlumno(model.Nombre, model.Apellidos, model.Email, model.DocumentoDeIdentidad);
        }

        public EditarAlumnoModel ObtenerAlumnoParaEditar(Guid idAlumno)
        {
            return _repositorio.ObtenerAlumnoParaEditar(idAlumno);
        }
        public void EditarAlumno(EditarAlumnoModel model)
        {
            _repositorio.EditarAlumno(model.Nombre, model.Apellidos, model.Email, model.IdAlumno, model.FechaDeAlta);
        }

        public DetallesAlumnoModel ObtenerDetallesAlumno(Guid idAlumno)
        {
            return _repositorio.ObtenerDetallesAlumno(idAlumno);
        }

        public void DarDeBajaAlumno(Guid idAlumno)
        {
            _repositorio.DarDeBajaAlumno(idAlumno);
        }

        public void DarDeBajaAlumno(Guid idAlumno, DateTime fechaDeBaja)
        {
            _repositorio.DarDeBajaAlumno(idAlumno, fechaDeBaja);
        }

        public void ReactivarAlta(Guid idAlumno)
        {
            _repositorio.ReactivarAlta(idAlumno);
        }

        public IDictionary<Guid,string> ObtenerDiccionarioCursos()
        {
            return _repositorio.ObtenerDiccionarioCursos();
        }

        public void MatricularAlumno(Guid idAlumno, Guid idCurso, DateTime fechaDeAlta)
        {
            _repositorio.MatricularAlumno(idAlumno, idCurso, fechaDeAlta);
        }

        public MatricularAlumnoModel ObtenerMatriculaParaAlumno(Guid idAlumno)
        {
            MatricularAlumnoModel model = _repositorio.ObtenerMatriculaParaAlumno(idAlumno);
            return model;
        }
    }
}
