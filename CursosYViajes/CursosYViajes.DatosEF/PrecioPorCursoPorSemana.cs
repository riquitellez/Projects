using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CursosYViajes.DatosEF
{
    public class PrecioPorCursoPorSemana
    {
        public PrecioPorCursoPorSemana(Guid idCurso, int numSemana, double precio)
        {
            IdPrecioPorCursoPorSemana = Guid.NewGuid();
            IdCurso = idCurso;
            NumSemana = numSemana;
            Precio = precio;
        }

        [Key]
        public Guid IdPrecioPorCursoPorSemana { get; protected set; }
        public Guid IdCurso { get; protected set; }
        [ForeignKey("IdCurso")]
        public Curso Curso { get; protected set; }
        [Range(1, 53)]
        public int NumSemana { get; protected set; }
        public double Precio { get; protected set; }

        public void ActualizarPrecioPorSemana(double precio)
        {
            Precio = precio;
        }
    }
}
