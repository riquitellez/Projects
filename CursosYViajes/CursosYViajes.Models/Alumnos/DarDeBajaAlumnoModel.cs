using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CursosYViajes.Models.Alumnos
{
    public class DarDeBajaAlumnoModel
    {
        public Guid IdAlumno { get; set; }
        [Required]
        public DateTime FechaDeBaja { get; set; }
    }
}
