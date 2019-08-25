using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Configuracion
{
    public class DarDeBajaLineaModel
    {
        public Guid IdLinea { get; set; }
        public string Nombre { get; set; }
        public string Numero { get; set; }
        [Required]
        public DateTime FechaDeBaja { get; set; }
    }
}
