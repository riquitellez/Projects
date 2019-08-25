using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CursosYViajes.Datos
{
    public class Curso
    {
        public Curso() { }
        public Curso(string nombre, Pais pais)
        {
            IdCurso = Guid.NewGuid();
            Nombre = nombre;
            Pais = pais;
        }

        [Key]
        public Guid IdCurso { get; protected set; }
        [Required]
        [MaxLength (50)]
        public string Nombre { get; protected set; }
        [ForeignKey("IdPais")]        
        public Pais Pais { get; protected set; } 
        [Required]
        public Guid IdPais { get; protected set; }        
        public ICollection<CursoPorAlumno> AlumnosPorCurso { get; protected set; }
    }
}
