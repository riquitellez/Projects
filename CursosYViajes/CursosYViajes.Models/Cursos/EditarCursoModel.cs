using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CursosYViajes.Models.Cursos
{
    public class EditarCursoModel
    {
        public Guid IdCurso { get; set; }
        public string Nombre { get; set; }
        public IDictionary<Guid, string> Paises { get; set; }
        public Guid? IdPais { get; set; }
        public string PaisNuevo { get; set; }
        public DateTime FechaDeAlta { get; set; }
        [Required]
        public double PrecioPorSemana { get; set;}
    }
}
