using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Clases
{
    public class CalculadorNumeroDeClasesModel
    {
        public Guid? IdEmpresaSeleccionada { get; set; }
        public string NombreEmpresaSeleccionada { get; set; }
        public DateTime FechaRangoInicio {get;set;}
        //Aquí como hago para que me tome un solo día?
        public DateTime FechaRangoFin { get; set; }
        //Ojo, no debe contar las que tuvieron incidencia
        public int NumeroTotalDeClases { get; set; }
        public IEnumerable<ListadoClaseModel> ClasesDadas { get; set; }       
    }
}
