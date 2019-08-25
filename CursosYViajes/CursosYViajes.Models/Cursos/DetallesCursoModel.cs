using CursosYViajes.Models.Alumnos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursosYViajes.Models.Cursos
{
    public class DetallesCursoModel
    {
        public Guid IdCurso { get; set; }
        public string Nombre { get; set; }
        public string NombrePais { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public DateTime? FechaDeBaja { get; set; }
        public double PrecioPorSemana { get; set; }
        public IDictionary<Guid,AlumnoGridModel> Alumnos { get; set; }

    }
}
