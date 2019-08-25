using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Alumnos
{
    public class DetallesAlumnoModel
    {
        public Guid IdAlumno { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string NombrePlan { get; set; }
        public string NombreNivel { get; set; }
        
        public string NombreEmpresa { get; set; }
        public string Timetable { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public DateTime? FechaDeBaja { get; set; }
        public IEnumerable<ClaseDadaGridModel> ClasesDadas { get; set; }
    }
}
