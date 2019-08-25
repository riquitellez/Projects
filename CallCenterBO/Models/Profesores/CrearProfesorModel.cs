using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Profesores
{
    public class CrearProfesorModel
    {
        public string Nombre { get; set; }
        public Guid IdEmpresaSeleccionda { get; set; }
        public IDictionary<Guid, string> Empresas { get; set; }
        public string NombreEmpresa { get; set; }
        public string Mensaje { get; set; }
    }
}
