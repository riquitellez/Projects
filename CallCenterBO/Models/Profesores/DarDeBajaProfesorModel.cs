using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Profesores
{
    public class DarDeBajaProfesorModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaDeBaja { get; set; }
    }
}
