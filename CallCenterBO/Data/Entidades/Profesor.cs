using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallCenterBO.Data.Entidades
{
    public class Profesor
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [ForeignKey("EmpresaProfesor")]
        public Guid? IdEmpresaProfesor { get; set; }
        public EmpresaProfesor EmpresaProfesor { get; set; }
        public ICollection<Disponibilidad> Disponibilidades{ get; set; }
        public ICollection<Clase> ClasesDadas { get; set; }
        //He añadido estos dos campos faltaría migrar
        public DateTime FechaDeAlta { get; set; }
        public DateTime? FechaDeBaja { get; set; }

        public void ModificarDatos(string nombre, Guid? idEmpresaProfesor, DateTime fechaDeAlta, DateTime? fechaDeBaja)
        {
            Nombre = nombre;
            IdEmpresaProfesor = idEmpresaProfesor;
            FechaDeAlta = fechaDeAlta;
            FechaDeBaja = fechaDeBaja;
        }
        public void DarDeBaja()
        {
            FechaDeBaja = DateTime.Now;
        }
        public void DarDeBaja(DateTime fechaDeBaja)
        {
            FechaDeBaja = fechaDeBaja;
        }

        public void Reactivar()
        {
            FechaDeBaja = null;
        }
    }
}