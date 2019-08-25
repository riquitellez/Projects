using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Clases
{
    public class IniciarClaseModel
    {
        public Guid IdAlumno { get; set; }
        public string CodigoAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public IDictionary<Guid, string> LineasDisponibles { get; set; }
    }
}
