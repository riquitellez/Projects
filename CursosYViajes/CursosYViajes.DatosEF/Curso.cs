using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CursosYViajes.DatosEF
{
    public class Curso
    {
        public Curso() { }
        public Curso(string nombre, Pais pais, double precioPorSemana)
        {
            IdCurso = Guid.NewGuid();
            Nombre = nombre;
            Pais = pais;
            FechaDeAlta = DateTime.Now;
            FechaDeBaja = null;
            PrecioPorSemana = precioPorSemana;
        }
        public Curso(string nombre, Guid idPais, double precioPorSemana)
        {
            IdCurso = Guid.NewGuid();
            Nombre = nombre;
            IdPais = idPais;
            FechaDeAlta = DateTime.Now;
            FechaDeBaja = null;
            PrecioPorSemana = precioPorSemana;
        }

        [Key]
        public Guid IdCurso { get; protected set; }
        [Required]
        [MaxLength (50)]
        public string Nombre { get; protected set; }
        [ForeignKey("IdPais")]        
        public Pais Pais { get; protected set; } 
        [Required]
        public Guid IdPais { get; protected set; }        
        public ICollection<CursoPorAlumno> AlumnosPorCurso { get; protected set; }
        [Required]
        public DateTime FechaDeAlta { get; protected set; }
        public DateTime? FechaDeBaja { get; protected set; }
        public double PrecioPorSemana { get; protected set; }
        public ICollection<PrecioHospedajePorCursoPorSemana> PrecioPorHospedajesPorCursosPorSemanas { get; protected set; }      
        public ICollection<PrecioPorCursoPorSemana> PrecioPorCursosPorSemanas { get; protected set; }

        public void CambiarDatos(string nombre, Pais pais, DateTime fechaDeAlta, double precioPorSemana)
        {
            Nombre = nombre;
            Pais = pais;
            FechaDeAlta = fechaDeAlta;
            PrecioPorSemana = precioPorSemana;
        }
        public void CambiarDatos(string nombre, Guid idPais, DateTime fechaDeAlta, double precioPorSemana)
        {
            Nombre = nombre;
            IdPais = idPais;
            FechaDeAlta = fechaDeAlta;
            PrecioPorSemana = precioPorSemana;
        }
        public void DarDeBaja(DateTime? fechaDeBaja)
        {
            FechaDeBaja = fechaDeBaja;
        }

        public void ReactivarAlta()
        {
            FechaDeBaja = null;
        }
        
    }
}
