using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Profesores
{
    public class EditarProfesorModel
    {
        public Guid IdProfesor { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        public IDictionary<Guid, string> EmpresasProfesores { get; set; }
        public Guid? IdEmpresaSeleccionada { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public DateTime? FechaDeBaja { get; set; }
        public string Mensaje { get; set; }
    }
}
