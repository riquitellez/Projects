using System;
using System.Collections;
using System.Collections.Generic;

namespace CursosYViajes.Models.Cursos
{
    public class BuscadorCursosModel
    {
        public IDictionary<Guid, string> ComboPaises { get; set; }
        public Guid IdPais { get; set; }
        public string TextoBuscador { get; set; }
    }
}