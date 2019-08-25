using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CursosYViajes.DatosEF
{
    //Corresponde a hospedaje por curso por semana en el calendario por tipo de hospedaje para después sacar precio
    public class PrecioHospedajePorCursoPorSemana
    {
        public PrecioHospedajePorCursoPorSemana(Guid idCurso, int idTipoDeHospedaje, int numSemana, double precio)
        {
            IdPrecioHospedajePorCursoPorSemana = Guid.NewGuid();
            IdCurso = idCurso;
            IdTipoDeHospedaje = idTipoDeHospedaje;
            NumSemana = numSemana;
            Precio = precio;
        }

        [Key]
        public Guid IdPrecioHospedajePorCursoPorSemana { get; protected set; }

        public Guid IdCurso { get; protected set; }
        [ForeignKey("IdCurso")]
        public Curso Curso { get; protected set; }
        public int IdTipoDeHospedaje { get; protected set; }
        [ForeignKey("IdTipoDeHospedaje")]
        public TipoHospedaje TipoHospedaje { get; protected set; }
        [Range(1,53)]
        public int NumSemana { get; protected set; }
        public double Precio { get; protected set; }

        public void ActualizarPrecioPorSemana(double precio)
        {
            Precio = precio;
        }
    }
}
