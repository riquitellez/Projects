using System;
using System.Collections.Generic;
using System.Text;

namespace CursosYViajes.Models.Cursos
{
    public class DetallesMatriculaModel
    {
        public string NombreAlumno { get; set; }
        public string ApellidosAlumno { get; set; }
        public string NombreCurso { get; set; }
        public Guid IdCursoPorAlumno { get; set; }
        public Guid IdCurso { get; set; }
        public Guid IdAlumno { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public DateTime? FechaDeBaja{ get; set; }
    }
}
