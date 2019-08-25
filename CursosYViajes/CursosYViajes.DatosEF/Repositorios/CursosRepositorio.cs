using CursosYViajes.Models.Alumnos;
using CursosYViajes.Models.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CursosYViajes.DatosEF.Repositorios
{
    public class CursosRepositorio
    {
        private ContextoCursoYViajes _contexto;
        public CursosRepositorio(ContextoCursoYViajes contexto)
        {
            _contexto = contexto;
        }
        public CursosRepositorio()
        {
            _contexto = new ContextoCursoYViajes();
        }

        public IEnumerable<CursoGridModel> GetCursos(int numCursos = 100)
        {
            var cursos = _contexto.Cursos.Take(numCursos).Select(x => new
            {
                x.IdCurso,
                x.Nombre,
                pais = x.Pais.Nombre,
                x.FechaDeBaja
            }).ToList();
            return cursos.Select(x => new CursoGridModel
            {
                IdCurso = x.IdCurso,
                Nombre = x.Nombre,
                Pais = x.pais,
                FechaDeBaja = x.FechaDeBaja
            });
        }
        public IEnumerable<CursoGridModel> GetCursos(Guid idPais, string texto)
        {
            var cursos = _contexto.Cursos;
            IQueryable<Curso> cursosQuery = cursos.Where(x=>true);
            if (idPais != Guid.Empty)
            {
                cursosQuery = cursosQuery.Where(x => x.IdPais == idPais);
            }

            if (!string.IsNullOrWhiteSpace(texto))
            {
                cursosQuery = cursosQuery.Where(x => x.Nombre.Contains(texto));
            }

            var result = cursosQuery.Select(x => new
            {
                x.IdCurso,
                x.Nombre,
                pais = x.Pais.Nombre,
                x.FechaDeBaja
            }).ToList();
            return result.Select(x=> new CursoGridModel
            {
                IdCurso = x.IdCurso,
                Nombre = x.Nombre,
                Pais = x.pais,
                FechaDeBaja = x.FechaDeBaja
            });
        }
        public IDictionary<Guid, string> VerPaises()
        {
            return _contexto.Paises.ToDictionary(x => x.IdPais, x => x.Nombre);
        }

        public void CrearCurso(string nombre, Guid idPais, double precioPorSemana)
        {
            Curso curso = new Curso(nombre, idPais, precioPorSemana);
            _contexto.Cursos.Add(curso);
            _contexto.SaveChanges();
        }
        public void CrearCursoYPais(string nombre, string paisNuevo, double precioPorSemana)
        {
            Pais pais = new Pais(paisNuevo); 
            Curso curso = new Curso(nombre, pais, precioPorSemana);
            _contexto.Cursos.Add(curso);
            _contexto.SaveChanges();
        }

        public void EditarCurso(string nombre, Guid idPais, Guid idCurso, DateTime fechaDeAlta, double precioPorSemana)
        {
            var curso = _contexto.Cursos.Find(idCurso);
            curso.CambiarDatos(nombre, idPais, fechaDeAlta, precioPorSemana);
            _contexto.SaveChanges();
        }
        public void EditarCursoConPaisNuevo(string nombre, string paisNuevo, Guid idCurso, DateTime fechaDeAlta, double precioPorSemana)
        {
            var curso = _contexto.Cursos.Find(idCurso);
            Pais pais = new Pais(paisNuevo);
            curso.CambiarDatos(nombre, pais, fechaDeAlta, precioPorSemana);
            _contexto.SaveChanges();
        }
        public void ReactivarAlta (Guid idCurso)
        {
            var curso = _contexto.Cursos.Find(idCurso);
            curso.ReactivarAlta();
            _contexto.SaveChanges();
        }

        public MatricularAlumnoCursoModel ObtenerAlumnosParaMatricula(Guid idCurso)
        {
           
            var alumnos = _contexto.Alumnos
                .Where(x => !x.CursosPorAlumno.Any(y => y.IdCurso == idCurso))
                .ToDictionary(x => x.IdAlumno, x => x.Apellidos + ", " + x.Nombre);
            var datosCurso = _contexto.Cursos.Where(X => X.IdCurso == idCurso).Select(x => new
            {
                x.Nombre,
                Pais = x.Pais.Nombre
            }).Single();
            MatricularAlumnoCursoModel model = new MatricularAlumnoCursoModel
            {
                IdCurso = idCurso,
                NombreCurso = datosCurso.Nombre,
                PaisCurso = datosCurso.Pais,
                Alumnos = alumnos,
                IdAlumnoSeleccionado = alumnos.First().Key,
                FechaDeAlta = DateTime.Now
            };
            return model;
        }

        public DetallesMatriculaModel ObtenerDetallesMatricula(Guid idCursoPorAlumno)
        {
            var fechas = _contexto.CursosPorAlumno.Where(x => x.IdCursoPorAlumno == idCursoPorAlumno).Select(x => new
            {
                x.Alumno.Nombre,
                x.Alumno.Apellidos,
                nombreCurso = x.Curso.Nombre,
                x.IdAlumno,
                x.IdCurso,
                x.FechaDeAlta,
                x.FechaDeBaja
            }).Single();
            DetallesMatriculaModel model = new DetallesMatriculaModel
            {
                NombreAlumno = fechas.Nombre,
                ApellidosAlumno = fechas.Apellidos,
                NombreCurso = fechas.nombreCurso,
                FechaDeAlta = fechas.FechaDeAlta,
                FechaDeBaja = fechas.FechaDeBaja,
                IdCurso = fechas.IdCurso,
                IdAlumno = fechas.IdAlumno,
                IdCursoPorAlumno = idCursoPorAlumno,                
            };
            return model;
        }

        public CalculadorPrecioModel ObtenerDatosParaCalcularPrecio(string nombreCurso, Guid idCurso, DateTime fechaEntrada, int numeroSemanas, string tipoDeHospedaje)
        {
            var curso = _contexto.Cursos.Where(x => x.IdCurso == idCurso).Select(x => new
            {
                x.Nombre,
                x.IdCurso,
                x.PrecioPorSemana
            }).Single();
            CalculadorPrecioModel model = new CalculadorPrecioModel
            {
                IdCurso = idCurso,
                NombreCurso = nombreCurso,
                FechaEntrada = DateTime.Today,
                NumeroSemanas = numeroSemanas,
                TipoDeHospedaje = tipoDeHospedaje,
                PrecioCurso = (curso.PrecioPorSemana * numeroSemanas)+50+(10*numeroSemanas)
            };
            return model;
        }

        public void ModificarFechasMatricula(Guid idCursoPorAlumno, DateTime fechaDeAlta, DateTime? fechaDeBaja)
        {
            var matricula = _contexto.CursosPorAlumno.Find(idCursoPorAlumno);
            matricula.ModificarFechas(fechaDeAlta, fechaDeBaja);
            _contexto.SaveChanges();
        }

        public void ReactivarAltaMatricula(Guid idCursoPorAlumno)
        {
            var matricula = _contexto.CursosPorAlumno.Find(idCursoPorAlumno);
            matricula.ReactivarAlta();
            _contexto.SaveChanges();
        }

        public void EliminarMatricula(Guid idCursoPorAlumno, DateTime fechaDeBaja)
        {
            var matricula = _contexto.CursosPorAlumno.Find(idCursoPorAlumno);
            matricula.DarDeBaja(fechaDeBaja);
            _contexto.SaveChanges();                        
        }

        public DeleteMatriculaModel ObtenerDatosParaEliminarMatricula(Guid idCurso, Guid idAlumno)
        {
            var datosParaBaja = _contexto.CursosPorAlumno.Where(x => x.IdCurso == idCurso && x.IdAlumno == idAlumno)
                .Select(x => new
                {
                    idCursoPorAlumno = x.IdCursoPorAlumno,
                    nombreCurso = x.Curso.Nombre,
                    nombrePais = x.Curso.Pais.Nombre,
                    nombreAlumno = x.Alumno.Nombre,
                    apellidosAlumno = x.Alumno.Apellidos,
                }).Single();
            DeleteMatriculaModel model = new DeleteMatriculaModel
            {   IdCursoPorAlumno = datosParaBaja.idCursoPorAlumno,
                IdCurso = idCurso,
                NombreCurso = datosParaBaja.nombreCurso,
                IdAlumno = idAlumno,
                PaisCurso = datosParaBaja.nombrePais,
                NombreAlumno = datosParaBaja.nombreAlumno,
                ApellidosAlumno = datosParaBaja.apellidosAlumno,
                FechaDeBaja = DateTime.Now
            };
            return model;
        }

        public DetallesCursoModel ObtenerDetallesCurso(Guid idCurso)
        {
            var curso = _contexto.Cursos.Where(x => x.IdCurso == idCurso).Select(x => new
            {
                x.IdCurso,
                x.Nombre,
                x.FechaDeAlta,
                x.FechaDeBaja,
                x.PrecioPorSemana,
                NombrePais = x.Pais.Nombre,
                alumnos = x.AlumnosPorCurso.Select(y => new
                {
                    y.IdAlumno,
                    y.Alumno.Nombre,
                    y.Alumno.Apellidos,
                    y.Alumno.DocumentoDeIdentidad,
                    y.FechaDeBaja,
                    y.IdCursoPorAlumno
                })
            }).Single();

            return new DetallesCursoModel
            {
                IdCurso = idCurso,
                Nombre = curso.Nombre,
                NombrePais = curso.NombrePais,
                FechaDeAlta = curso.FechaDeAlta,
                FechaDeBaja = curso.FechaDeBaja,
                PrecioPorSemana = curso.PrecioPorSemana,
                Alumnos = (curso.alumnos != null && curso.alumnos.Any())? 
                    curso.alumnos.ToDictionary(x => x.IdCursoPorAlumno, x => new AlumnoGridModel
                    {
                        IdAlumno = x.IdAlumno,
                        Nombre = x.Nombre,
                        Apellidos = x.Apellidos,
                        DocumentoDeIdentidad = x.DocumentoDeIdentidad,
                        FechaDeBaja = x.FechaDeBaja
                    }):new Dictionary<Guid, AlumnoGridModel>(),               
            };
        }

        public EditarCursoModel ObtenerCursoParaEditar(Guid idCurso)
        {
            var curso = _contexto.Cursos.Where(x => x.IdCurso == idCurso).Select(x => new
            {
                x.IdCurso,
                x.Nombre,
                x.IdPais,
                x.FechaDeAlta,
                x.PrecioPorSemana
            }).Single();
            return new EditarCursoModel
            {
                IdCurso = idCurso,
                Nombre = curso.Nombre,
                IdPais = curso.IdPais,
                FechaDeAlta = curso.FechaDeAlta,
                PrecioPorSemana = curso.PrecioPorSemana
            };
        }
        public void DarDeBaja(Guid idCurso, DateTime? fechaDeBaja)
        {
            var curso = _contexto.Cursos.Find(idCurso);
            curso.DarDeBaja(fechaDeBaja);
            _contexto.SaveChanges();
        }
    }
}
