using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CursosYViajes.DatosEF
{
    public class TipoHospedaje
    {
        public TipoHospedaje() { }
        [Key]
        public int Id { get; protected set; }
        [Required]
        public string Nombre { get; protected set; }
        public string Descripcion { get; protected set; }
        public ICollection<PrecioHospedajePorCursoPorSemana> PrecioPorHospedajesPorCursosPorSemanas { get; protected set; }
    }
}
