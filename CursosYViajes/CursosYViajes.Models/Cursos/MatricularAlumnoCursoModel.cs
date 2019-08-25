using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CursosYViajes.Models.Cursos
{
    public class MatricularAlumnoCursoModel
    {
        public Guid IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public string PaisCurso { get; set; }
        public IDictionary<Guid, string> Alumnos { get; set; }
        [Required]
        public Guid IdAlumnoSeleccionado { get; set; }
        [Required]
        public DateTime FechaDeAlta { get; set; }
    }
}
