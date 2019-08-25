using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CallCenterBO.Data.Entidades
{
    public class Empresa
    {
        public Empresa(string nombre)
        {
            IdEmpresa = Guid.NewGuid();
            Nombre = nombre;
        }
        [Key]
        public Guid IdEmpresa { get; set; }
        [Required]
        public string Nombre { get; set; }
        public ICollection<Alumno> Alumnos { get; set; }
    }
}