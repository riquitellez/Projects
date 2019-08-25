using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Configuracion
{
    public class AnadirLineaProfesorYDisponibilidadModel
    {
        public IDictionary<Guid, string> NombreLineaPorLinea { get; set; }
        public IDictionary<Guid, string> NumeroLineaPorLinea { get; set; }
        public IDictionary<Guid, string> Profesores { get; set; }
        public IDictionary<Guid, Guid?> IdProfesorSeleccionadoPorLinea { get; set; }
        public IDictionary<Guid, DateTime?> InicioDisponibilidadPorLinea { get; set; }
        public IDictionary<Guid, DateTime?> FinDisponibilidadPorLinea { get; set; }       
    }
}
