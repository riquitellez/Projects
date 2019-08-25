using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CursosYViajes.Models.Alumnos
{
    public class MatricularAlumnoModel
    {
        public Guid IdAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public string ApellidoAlumno { get; set; }
        public IDictionary<Guid, string> Cursos { get; set; }
        [Required]
        public Guid IdCurso { get; set; }
        [Required]
        public DateTime FechaDeAlta {get; set;}
    }
}
