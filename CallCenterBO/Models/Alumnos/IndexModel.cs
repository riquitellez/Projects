using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Alumnos
{
    public class IndexModel
    {
        public IEnumerable<ListadoAlumnoModel> Alumnos { get; set; }
        public BuscadorAlumnoModel Buscador { get; set; }
    }
}
