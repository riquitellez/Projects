using CallCenterBO.Models.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Util
{
    public static class ProfesorModelExtension
    {
        public static IDictionary<Guid, ProfesorEmpresaModel> FiltrarPorEmpresa(
            this Guid? idEmpresaProfesor, 
            IDictionary<Guid, ProfesorEmpresaModel> profesores,
            bool anadirVacio = true)
        {
            IDictionary<Guid, ProfesorEmpresaModel> profesoresAuxiliar;

            if (idEmpresaProfesor == null)
            {
                profesoresAuxiliar = profesores.OrderBy(x => x.Value.NombreProfesor).ToDictionary(x => x.Key, x => x.Value);                
            }
            else
            {
                profesoresAuxiliar = profesores.Where(x => x.Value.IdEmpresaProfesor == idEmpresaProfesor).OrderBy(x=>x.Value.NombreProfesor).ToDictionary(x => x.Key, x => x.Value);                
            }

            if (anadirVacio)
            {
                var model = new ProfesorEmpresaModel
                {
                    IdEmpresaProfesor = null,
                    IdProfesor = Guid.Empty,
                    NombreEmpresa = null,
                    NombreProfesor = "Seleccione profesor"
                };
                profesoresAuxiliar.Add(model.IdProfesor, model);
            }
            return profesoresAuxiliar.Reverse().ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
