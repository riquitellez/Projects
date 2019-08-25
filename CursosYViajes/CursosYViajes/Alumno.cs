using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CursosYViajes.Datos
{
    public class Alumno
    {
        public Alumno() { }
        public Alumno(string nombre, string apellidos, string email, string documentoDeIdentidad)
        {
            IdAlumno = Guid.NewGuid();
            Nombre = nombre;
            Apellidos = apellidos;           
            Email = email;
            DocumentoDeIdentidad = documentoDeIdentidad;
        }

        [Key]
        public Guid IdAlumno { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; protected set; }

        [Required]
        [MaxLength(50)]
        public string Apellidos { get; protected set; }

        [Required]
        [EmailAddress]
        public string Email { get; protected set; }
        public ICollection<CursoPorAlumno> CursosPorAlumno { get; protected set;}

        [Required]
        public string DocumentoDeIdentidad { get; protected set; }
    }
}
