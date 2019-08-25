using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CallCenterBO.Data.Entidades
{
    public class Duracion
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Clase> Clases { get; set; }
    }
}