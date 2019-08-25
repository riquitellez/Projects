using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallCenterBO.Data.Entidades
{
    public class Disponibilidad
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }

        [ForeignKey("Linea")]
        public Guid? IdLinea { get; set; }
        public Linea Linea { get; set; }

        [ForeignKey("Cancelacion")]
        public Guid? IdCancelacion { get; set; }

        [ForeignKey("Profesor")]
        public Guid IdProfesor { get; set; }
        public Profesor Profesor { get; set; }
        public bool AusenciaTemporal { get; set; }

    }
}