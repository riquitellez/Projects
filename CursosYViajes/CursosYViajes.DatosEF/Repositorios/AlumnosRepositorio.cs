using CursosYViajes.Models.Alumnos;
using CursosYViajes.Models.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CursosYViajes.DatosEF.Repositorios
{
    public class AlumnosRepositorio
    {
        private ContextoCursoYViajes _contexto;

        public AlumnosRepositorio(ContextoCursoYViajes contexto)
        {
            _contexto = contexto;
        }
        public AlumnosRepositorio()
        {
            _contexto = new ContextoCursoYViajes();
        }


        public IEnumerable<AlumnoGridModel> GetAlumnos(int numAlumnos = 100)
        {
            var alumnos = _contexto.Alumnos.Select(x => new
            {
                x.IdAlumno,
                x.Nombre,
                x.Apellidos,
                x.DocumentoDeIdentidad,
                x.FechaDeBaja
            }).Take(numAlumnos).ToList();
            return alumnos.Select(x => new AlumnoGridModel
            {
                IdAlumno = x.IdAlumno,
                DocumentoDeIdentidad = x.DocumentoDeIdentidad,
                Nombre = x.Nombre,
                Apellidos = x.Apellidos,
                FechaDeBaja = x.FechaDeBaja
            });
        }

        public IEnumerable<AlumnoGridModel> BuscarAlumno(string textoBuscador)
        {
            var alumnos = _contexto.Alumnos.Where(x => x.Nombre.Contains(textoBuscador) ||
            x.Apellidos.Contains(textoBuscador) ||
            x.DocumentoDeIdentidad.Contains(textoBuscador) ||
            x.Email.Contains(textoBuscador)).Select(x => new
            {
                x.IdAlumno,
                x.Nombre,
                x.Apellidos,
                x.DocumentoDeIdentidad,
                x.Email,
                x.FechaDeAlta,
                x.FechaDeBaja
            });
            return alumnos.Select(x => new AlumnoGridModel
            {
                IdAlumno = x.IdAlumno,
                Nombre = x.Nombre,
                Apellidos = x.Apellidos,
                DocumentoDeIdentidad = x.DocumentoDeIdentidad,
                FechaDeBaja = x.FechaDeBaja
            });
        }
        public void AnadirAlumno(string nombre, string apellidos, string email, string documentoDeIdentidad)
        {
            Alumno alumno = new Alumno(nombre, apellidos, email, documentoDeIdentidad);
            _contexto.Alumnos.Add(alumno);
            _contexto.SaveChanges();
        }

        public EditarAlumnoModel ObtenerAlumnoParaEditar(Guid idAlumno)
        {
            var alumno = _contexto.Alumnos.Where(x => x.IdAlumno == idAlumno).Select(x => new
            {
                x.Nombre,
                x.Apellidos,
                x.Email,
                x.FechaDeAlta
            }).Single();
            return new EditarAlumnoModel
            {
                IdAlumno = idAlumno,
                Nombre = alumno.Nombre,
                Apellidos = alumno.Apellidos,
                Email = alumno.Email,
                FechaDeAlta = alumno.FechaDeAlta                
            };
        }

        public IDictionary<Guid, string> ObtenerDiccionarioCursos()
        {
            var cursos = _contexto.Cursos.ToDictionary(x => x.IdCurso, x => x.Nombre);
            return cursos;
        }

        public bool MatricularAlumno(Guid idAlumno, Guid idCurso, DateTime fechaDeAlta)
        {
            if (_contexto.CursosPorAlumno.Any(x => x.IdCurso == idCurso && x.IdAlumno == idAlumno))
            {
                return false;
            }
            else
            {
                var cursoPorAlumno = new CursoPorAlumno(idAlumno, idCurso, fechaDeAlta);
                _contexto.Add(cursoPorAlumno);
                _contexto.SaveChanges();
            }
            return true;
            
        }

        public MatricularAlumnoModel ObtenerMatriculaParaAlumno(Guid idAlumno)
        {
            var alumno = _contexto.Alumnos.Where(x => x.IdAlumno == idAlumno).Select(x => new
            {
                x.Nombre,
                x.Apellidos
            }).Single();
            var cursos = _contexto.Cursos.ToDictionary(x => x.IdCurso, x => x.Nombre);
            return new MatricularAlumnoModel
            {
                IdAlumno = idAlumno,
                NombreAlumno = alumno.Nombre,
                ApellidoAlumno = alumno.Apellidos,
                IdCurso = cursos.First().Key,
                Cursos = cursos,
                FechaDeAlta = DateTime.Now               
            };            
        }

        public void DarDeBajaAlumno(Guid idAlumno)
        {
            var alumno = _contexto.Alumnos.Find(idAlumno);
            alumno.DarDeBaja();
            _contexto.SaveChanges();
        }

        public void DarDeBajaAlumno(Guid idAlumno, DateTime fechaDeBaja)
        {
            var alumno = _contexto.Alumnos.Find(idAlumno);
            alumno.DarDeBaja();
            _contexto.SaveChanges();
        }

        public void ReactivarAlta(Guid idAlumno)
        {
            var alumno = _contexto.Alumnos.Find(idAlumno);
            alumno.ReactivarAlta();
            _contexto.SaveChanges();
        }

        public DetallesAlumnoModel ObtenerDetallesAlumno(Guid idAlumno)
        {
            var alumno = _contexto.Alumnos.Where(x => x.IdAlumno == idAlumno).Select(x => new
            {
                x.Nombre,
                x.Apellidos,
                x.Email,
                x.DocumentoDeIdentidad,
                x.FechaDeAlta,
                x.FechaDeBaja,
                cursos = x.CursosPorAlumno.Select(y => new
                {
                    idCurso = y.IdCurso,
                    nombreCurso = y.Curso.Nombre,
                    nombrePais = y.Curso.Pais.Nombre
                })
            }).Single();
            return new DetallesAlumnoModel
            {
                IdAlumno = idAlumno,
                Nombre = alumno.Nombre,
                Apellidos = alumno.Apellidos,
                Email = alumno.Email,
                FechaDeAlta = alumno.FechaDeAlta,
                FechaDeBaja = alumno.FechaDeBaja,
                DocumentoDeIdentidad = alumno.DocumentoDeIdentidad,
                Cursos = (alumno.cursos!=null && alumno.cursos.Any()) ?
                    alumno.cursos.Select(x => new CursoGridModel
                    {
                        IdCurso=x.idCurso,
                        Nombre = x.nombreCurso,
                        Pais = x.nombrePais
                    }).ToList() : new List<CursoGridModel>()
            };
        }

        public void EditarAlumno(string nombre, string apellidos, string email, Guid idAlumno, DateTime fechaDeAlta)
        {
            var alumno = _contexto.Alumnos.Find(idAlumno);
            alumno.CambiarDatos(nombre, apellidos, email, fechaDeAlta);
            _contexto.SaveChanges();
        }
    }
}
