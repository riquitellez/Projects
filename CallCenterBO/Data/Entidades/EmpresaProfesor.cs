using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CallCenterBO.Data.Entidades
{
    public class EmpresaProfesor
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public ICollection<Profesor> Profesores { get; set; }
        public ICollection<Linea> Lineas { get; set; }
    }
}