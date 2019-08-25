using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Alumnos
{
    public class ListadoAlumnoModel
    {
        public Guid IdAlumno { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NombreEmpresa { get; set; }
        public string TimeTable { get; set; }
        public int ClasesDadasEnLaSemana { get; set; }
        public DateTime? FechaDeBaja { get; set; }
    }
}
