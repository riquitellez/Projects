using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CursosYViajes.Models.Cursos
{
    public class DarDeBajaCursoModel
    {
        public Guid IdCurso { get; set; }
        [Required]
        public DateTime FechaDeBaja { get; set; }
    }
}
