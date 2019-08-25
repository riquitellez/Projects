using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CallCenterBO.Data.Entidades
{
    public class TipoDeCancelacion
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public ICollection<CancelacionDisponibilidad> Cancelaciones { get; set; }
        public string Descripcion { get; set; }
    }
}