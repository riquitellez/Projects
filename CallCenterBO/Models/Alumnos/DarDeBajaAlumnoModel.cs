using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Alumnos
{
    public class DarDeBajaAlumnoModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        [Required]
        public DateTime FechaDeBaja { get; set; }
    }
}
