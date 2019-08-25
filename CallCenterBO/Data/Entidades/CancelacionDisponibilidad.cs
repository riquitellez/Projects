using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallCenterBO.Data.Entidades
{
    public class CancelacionDisponibilidad
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("TipoDeCancelacion")]
        public Guid IdTipoDeCancelacion { get; set; }
        public TipoDeCancelacion TipoDeCancelacion { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public ICollection<Disponibilidad> Disponibilidades { get; set; }
    }
}