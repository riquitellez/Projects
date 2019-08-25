using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CallCenterBO.Data.Entidades
{
    public class Plan
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set; } 
        public ICollection<Alumno> Alumnos { get; set; }
    }
}