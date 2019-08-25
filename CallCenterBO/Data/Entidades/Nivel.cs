using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Data.Entidades
{
    public class Nivel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public ICollection<Alumno> Alumnos { get; set; }
        public string Descripcion { get; set; }

    }
}
