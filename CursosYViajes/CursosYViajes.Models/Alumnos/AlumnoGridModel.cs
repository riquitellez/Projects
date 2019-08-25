using System;

namespace CursosYViajes.Models.Alumnos
{
    public class AlumnoGridModel
    {
        public Guid IdAlumno { get; set; }
        public string DocumentoDeIdentidad { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime? FechaDeBaja { get; set; }
    }
}
