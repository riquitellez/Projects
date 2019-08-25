using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Configuracion
{
    public class ListadoLineaAsignadaModel
    {
        public IDictionary<Guid, EstadoRealLineaModel> EstadoRealPorLinea { get; set; }
    }

    public class EstadoRealLineaModel
    {
        public Guid IdDisponibilidad { get; set; }
        public string NombreLinea { get; set; }
        public string NumeroLinea { get; set; }
        public string NombreProfesor { get; set; }
        public bool EnClase { get; set; }
        public bool EnBreak { get; set; }
        public bool ConIncidencia { get; set; }
    }
}
