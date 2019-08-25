using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Configuracion
{
    public class CrearLineaModel
    {
        public Guid IdLinea { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Numero { get; set; }
        //Estas son las empresas que podrían ser las dueñas de las lineas
        public IDictionary<Guid, string> EmpresasProfesores { get; set; }
        public Guid? IdEmpresaProfesorSeleccionada { get; set; }
        public string NombreEmpresa { get; set; }
        [Required]
        public DateTime FechaDeAlta { get; set; }
    }
}
