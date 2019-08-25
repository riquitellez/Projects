using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosYViajes.Datos
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

        [Key]
        public Guid IdCursoPorAlumno { get; protected set; }       
        public Guid IdAlumno { get; protected set; }
        [ForeignKey("IdAlumno")]
        public Alumno Alumno { get; protected set; }
        public Guid IdCurso { get; protected set; }
        [ForeignKey("IdCurso")]
        public Curso Curso { get; protected set; }        
    }
}