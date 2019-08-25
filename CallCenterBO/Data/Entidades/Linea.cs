using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallCenterBO.Data.Entidades
{
    public class Linea
    {
        public Linea(string nombre, string numero, Guid? idEmpresa)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            Numero = numero;
            IdEmpresa = idEmpresa;
            FechaDeAlta = DateTime.Now;
            Activo = true;
            ConIncidencia = false;
            FechaDeBaja = null;
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Numero { get; set; }
        [ForeignKey("Empresa")]
        public Guid? IdEmpresa { get; set; }
        public EmpresaProfesor Empresa { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public DateTime? FechaDeBaja { get; set; }
        public ICollection<Disponibilidad> Disponibilidades { get; set; }
        public ICollection<Clase> Clases { get; set; }
        public bool Activo { get; set; }
        public bool ConIncidencia { get; set; }

    }
}