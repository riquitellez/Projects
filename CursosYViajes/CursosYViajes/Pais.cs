using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CursosYViajes.Datos
{
    public class Pais
    {
        public Pais() { }
        public Pais(string nombre)
        {
            IdPais = Guid.NewGuid();
            Nombre = nombre;
        }

        [Key]
        public Guid IdPais { get; protected set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; protected set; }
        public ICollection<Curso> Cursos { get; protected set; }
    }
}