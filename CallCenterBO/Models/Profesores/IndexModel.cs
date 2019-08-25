using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Profesores
{
    public class IndexModel
    {
        public BuscadorProfesorModel Buscador { get; set; }
        public IEnumerable<ListadoProfesorModel> ListadoProfesores { get; set; }
    }
}
