using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Configuracion
{
    public class ListadoLineaDisponibilidadModel
    {
        public IDictionary<Guid, ListadoDisponibilidadModel> DisponibilidadesPorLinea { get; set; }
        public IDictionary<Guid, ProfesorEmpresaModel> Profesores { get; set; }
    }

    public class ListadoDisponibilidadModel
    {
        public Guid IdLinea { get; set; }
        public string NombreLinea { get; set; }
        public string NumeroLinea { get; set; }  
        public Guid? IdProfesorSeleccionado { get; set; }
        public Guid? IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
    }

    public class ProfesorEmpresaModel
    {
        public Guid IdProfesor { get; set; }
        public string NombreProfesor { get; set; }
        public Guid? IdEmpresaProfesor { get; set; }
        public string NombreEmpresa { get; set; }
    }

    
}
