using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CursosYViajes.Models.Cursos
{
    public class DeleteMatriculaModel
    {
        [Required]
        public Guid IdCursoPorAlumno { get; set; }
        public Guid IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public string PaisCurso { get; set; }
        public string NombreAlumno { get; set; }
        public string ApellidosAlumno { get; set; }
        public Guid IdAlumno { get; set; }
        [Required]
        public DateTime FechaDeBaja { get; set; }
        
    }
}
