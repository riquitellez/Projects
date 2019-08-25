using System;
using System.Collections.Generic;
using System.Text;

namespace CursosYViajes.Models.Cursos
{
    public class IndexModel
    {
        public IEnumerable<CursoGridModel> Cursos { get; set; }
        public BuscadorCursosModel Buscador { get; set; }
    }
}
