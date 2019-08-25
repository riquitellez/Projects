using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Data.Entidades
{
    public class Alumno
    {
        private Alumno(string codigo, string nombre, string apellidos, string email, string timetable, DateTime fechaDeAlta)
        {
            IdAlumno = Guid.NewGuid();
            Codigo = codigo;
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            Timetable = timetable;
            FechaDeAlta = fechaDeAlta;
        }
        public Alumno() { }
        public Alumno(string codigo, string nombre, string apellidos, string email, string timetable, DateTime fechaDeAlta, Guid? idNivel, Guid? idEmpresa, Guid idPlan)
            : this(codigo, nombre, apellidos, email, timetable, fechaDeAlta)
        {
            IdEmpresa = idEmpresa;
            IdPlan = idPlan;
            IdNivel = idNivel;
        }
        public Alumno(string codigo, string nombre, string apellidos, string email, string timetable, DateTime fechaDeAlta, Empresa empresa, Guid? idNivel, Guid idPlan)
            : this(codigo, nombre, apellidos, email, timetable, fechaDeAlta)
        {
            Empresa = empresa;
            IdPlan = idPlan;
            IdNivel = idNivel;
        }
        public Alumno(string codigo, string nombre, string apellidos, string email, string timetable, DateTime fechaDeAlta, Guid? idNivel, Guid idPlan)
            : this(codigo, nombre, apellidos, email, timetable, fechaDeAlta)
        {
            IdPlan = idPlan;
            IdNivel = idNivel;
        }
        public Alumno(string codigo, string nombre, string apellidos, string email, string timetable, DateTime fechaDeAlta, Guid? idEmpresa, Guid? idNivel, Plan plan)
            : this(codigo, nombre, apellidos, email, timetable, fechaDeAlta)
        {
            IdEmpresa = idEmpresa;
            Plan = plan;
            IdNivel = idNivel;
        }
        public Alumno(string codigo, string nombre, string apellidos, string email, string timetable, DateTime fechaDeAlta, Empresa empresa, Guid? idNivel, Plan plan)
             : this(codigo, nombre, apellidos, email, timetable, fechaDeAlta)
        {
            Empresa = empresa;
            Plan = plan;
            IdNivel = idNivel;
        }

        [Key]
        public Guid IdAlumno { get; set; }
        [Required]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string Apellidos { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [ForeignKey("Empresa")]
        public Guid? IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
        public string Timetable { get; set; }
        public ICollection<Clase> ClasesDadas { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public DateTime? FechaDeBaja { get; set; }
        //Habíamos puesto solo un string. Lo he cambiado a una clase Plan
        [ForeignKey("Plan")]
        public Guid IdPlan { get; set; }
        public Plan Plan { get; set; }

        [ForeignKey("Nivel")]
        public Guid? IdNivel { get; set; }
        public Nivel Nivel { get; set; }

        //Modifica los datos del alumno
        public void ModificarDatos(string nombre, string apellidos, string email, DateTime fechaDeAlta)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            FechaDeAlta = fechaDeAlta;
        }

        //Da de baja al alumno con DateTime.Now
        public void DarDeBaja()
        {
            FechaDeBaja = DateTime.Now;
        }

        //Da de baja al alumno con una fecha específica
        public void DarDeBaja(DateTime fechaDeBaja)
        {
            FechaDeBaja = fechaDeBaja;
        }

        //Modifica la fecha de alta del alumno
        public void ModificarFechaDeAlta(DateTime fechaDeAlta)
        {
            FechaDeAlta = fechaDeAlta;
        }

        //Elimina fecha de baja para que aparezca como alumno activo
        public void ReactivarAlta()
        {
            FechaDeBaja = null;
        }

        public void ModificarDatos(string nombre, string apellidos, string email, string timetable, string codigo, Guid idPlanSeleccionado, Guid? idEmpresaSeleccionada, Guid? idNivelSeleccionado, DateTime fechaDeAlta, DateTime? fechaDeBaja)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            Timetable = timetable;
            Codigo = codigo;
            IdPlan = idPlanSeleccionado;
            IdNivel = idNivelSeleccionado;
            IdEmpresa = idEmpresaSeleccionada;
            FechaDeAlta = fechaDeAlta;
            FechaDeBaja = fechaDeBaja;
        }
    }
}
