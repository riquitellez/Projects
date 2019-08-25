using System;
using System.Collections.Generic;
using System.Text;

namespace CursosYViajes.Models.Alumnos
{
    public class IndexModel
    {
        public IEnumerable<AlumnoGridModel> Alumnos { get; set; }
        public BuscadorAlumnoModel Buscador { get; set; }
    }
}
