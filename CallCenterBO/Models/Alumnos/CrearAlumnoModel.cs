using CallCenterBO.Data.Entidades;
using CallCenterBO.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Alumnos
{
    public class CrearAlumnoModel:IAlumnoModel
    {
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public IDictionary<Guid, string> Planes { get; set; }
        public Guid IdPlanSeleccionado { get; set; }
        public IDictionary<Guid, string> Niveles { get; set; }
        public Guid? IdNivelSeleccionado { get; set; }
        public IDictionary<Guid, string> Empresas { get; set; }
        public Guid? IdEmpresaSeleccionada { get; set; }
        public string NombreEmpresa { get; set; }
        public string Timetable { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public string Mensaje { get; set; }
        
    }
}
