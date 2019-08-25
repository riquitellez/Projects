using CursosYViajes.Models.Cursos;
using System;
using System.Collections.Generic;

namespace CursosYViajes.Models.Alumnos
{
    public class DetallesAlumnoModel
    {
        public Guid IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string DocumentoDeIdentidad { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public DateTime? FechaDeBaja { get; set; }
        public IEnumerable<CursoGridModel> Cursos {get;set;}
    }
}
