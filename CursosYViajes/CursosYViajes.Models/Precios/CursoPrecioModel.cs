using System;
using System.Collections.Generic;
using System.Text;

namespace CursosYViajes.Models.Precios
{
    public class CursoPrecioModel
    {
        public Guid IdCurso { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public IDictionary<int, double> PrecioPorSemana { get; set; }
    }
}
