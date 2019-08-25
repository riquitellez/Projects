using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Models.Profesores
{
    public class ClaseDadaProfesorGridModel
    {
        public Guid Id { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public string CodigoAlumno { get; set; }
        public string Linea { get; set; }
        public string TipoDeIncidencia { get; set; }
    }
}
