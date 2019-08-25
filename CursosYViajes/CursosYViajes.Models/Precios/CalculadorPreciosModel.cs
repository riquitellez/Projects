using System;
using System.Collections.Generic;
using System.Text;

namespace CursosYViajes.Models.Precios
{
    public class CalculadorPreciosModel
    {
        public IDictionary<Guid, string> Cursos { get; set; }
        public Guid IdCursoSeleccionado { get; set; }
        public IDictionary<int, string> SemanasIniciales { get; set; }
        public int IdSemanaInicialSeleccionada { get; set; }
        public IDictionary<int, string> SemanasFinales { get; set; }
        public int IdSemanaFinalSeleccionada { get; set; }
        public IDictionary<int, string> TiposDeHospedaje { get; set; }
        public int TipoDeHospedajeSeleccionado { get; set; }
        public double PrecioCurso { get; set; }
        public double PrecioHospedaje { get; set; }
        public double PrecioTotal{ get; set; }
    }
}
