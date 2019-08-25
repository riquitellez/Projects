using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallCenterBO.Data.Entidades
{
    public class Clase
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Alumno")]
        public Guid IdAlumno { get; set; }
        public Alumno Alumno { get; set; }
        [ForeignKey("Profesor")]
        public Guid IdProfesor { get; set; }
        public Profesor Profesor { get; set; }
        [ForeignKey("Linea")]
        public Guid IdLinea { get; set; }
        public Linea Linea { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        [ForeignKey("TipoDeIncidencia")]
        public Guid? IdTipoDeIncidencia { get; set; }
        public TipoDeIncidencia TipoDeIncidencia { get; set; }
        [ForeignKey("Duracion")]
        public Guid IdDuracion { get; set; }
        public Duracion Duracion { get; set; }
        [ForeignKey("Topic")]
        public Guid IdTopic {get;set;}
        public Topic Topic { get; set; }

    }

}