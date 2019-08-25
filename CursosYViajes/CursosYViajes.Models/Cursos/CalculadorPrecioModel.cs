using System;
using System.Collections.Generic;
using System.Text;

namespace CursosYViajes.Models.Cursos
{
    public class CalculadorPrecioModel
    {
        public IDictionary<Guid, string> Cursos { get; set; }
        public Guid IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public DateTime FechaEntrada { get; set; }
        public int NumeroSemanas { get; set; }
        public string TipoDeHospedaje { get; set; }
        public double PrecioCurso { get; set; }
    }
}
