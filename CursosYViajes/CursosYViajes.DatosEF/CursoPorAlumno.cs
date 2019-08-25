using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosYViajes.DatosEF
{
    public class CursoPorAlumno
    {
        public CursoPorAlumno() { }
        public CursoPorAlumno(Alumno alumno, Curso curso)
        {
            IdCursoPorAlumno = Guid.NewGuid();
            Alumno = alumno;
            Curso = curso;
        }
        public CursoPorAlumno(Guid idAlumno, Guid idCurso, DateTime fechaDeAlta)
        {
            IdCursoPorAlumno = Guid.NewGuid();
            IdAlumno = idAlumno;
            IdCurso = idCurso;
            FechaDeAlta = fechaDeAlta;
        }

        [Key]
        public Guid IdCursoPorAlumno { get; protected set; }       
        public Guid IdAlumno { get; protected set; }
        [ForeignKey("IdAlumno")]
        public Alumno Alumno { get; protected set; }
        public Guid IdCurso { get; protected set; }
        [ForeignKey("IdCurso")]
        public Curso Curso { get; protected set; }
        public DateTime FechaDeAlta { get; protected set; }
        public DateTime? FechaDeBaja { get; protected set; }

        public void CambiarFechaDeAlta(DateTime fechaDeAlta)
        {
            FechaDeAlta = fechaDeAlta;
        }
        public void DarDeBaja(DateTime fechaDeBaja)
        {
            FechaDeBaja = fechaDeBaja;
        }

        public void ReactivarAlta()
        {
            FechaDeBaja = null;
        }
        public void ModificarFechas(DateTime fechaDeAlta, DateTime? fechaDeBaja)
        {
            FechaDeAlta = fechaDeAlta;
            FechaDeBaja = fechaDeBaja;
        }
    }
}