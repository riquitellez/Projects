using CallCenterBO.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CallCenterBO.Data.Repositorios
{
    public class EditarAlumnoModel:IAlumnoModel
    {
        public Guid IdAlumno{ get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellidos { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Timetable { get; set; }
        [Required]
        [MaxLength(10)]
        public string Codigo { get; set; }
        public IDictionary<Guid, string> Planes { get; set; }
        public Guid IdPlanSeleccionado { get; set; }
        public IDictionary<Guid, string> Niveles { get; set; }
        public Guid? IdNivelSeleccionado { get; set; }
        public IDictionary<Guid, string> Empresas { get; set; }
        public Guid? IdEmpresaSeleccionada { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public DateTime? FechaDeBaja { get; set; }
        public string Mensaje { get; set; }
    }
}