using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Interfaces
{
    public interface IAlumnoModel
    {
        IDictionary<Guid, string> Planes { get; set; }
        Guid IdPlanSeleccionado { get; set; }
        IDictionary<Guid, string> Niveles { get; set; }
        Guid? IdNivelSeleccionado { get; set; }
        IDictionary<Guid, string> Empresas { get; set; }
        Guid? IdEmpresaSeleccionada { get; set; }
    }
}
