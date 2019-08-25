using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CursosYViajes.DatosEF
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
            FechaDeAlta = DateTime.Now;
            FechaDeBaja = null;
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


        [Required]
        public string DocumentoDeIdentidad { get; protected set; }

        [Required]//No necesario  para DateTime. Por defecto es required
        public DateTime FechaDeAlta { get; protected set; }
        public DateTime? FechaDeBaja { get; protected set; }

        public ICollection<CursoPorAlumno> CursosPorAlumno { get; protected set; }

        public void CambiarDatos(string nombre, string apellidos, string email, DateTime fechaDeAlta)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            FechaDeAlta = fechaDeAlta;
        }

        public void DarDeBaja()
        {
            FechaDeBaja = DateTime.Now;
        }

        public void DarDeBaja(DateTime fechaDeBaja)
        {
            FechaDeBaja = fechaDeBaja;
        }
        public void ModificarFechaDeAlta(DateTime fechaDeAlta)
        {
            FechaDeAlta = fechaDeAlta;
        }

        public void ReactivarAlta()
        {
            FechaDeBaja = null;
        }
    }
}
