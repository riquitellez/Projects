using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Clases
{
    public class ListadoClaseModel
    {
        public Guid IdClase { get; set; }
        public string CodigoAlumno { get; set; }
        public string NombreProfesor { get; set; }
        public DateTime FechaClase { get; set; }
        public Guid? IdTipoIncidencia { get; set; }
        public string TipoIncidencia { get; set; }
    }
}
