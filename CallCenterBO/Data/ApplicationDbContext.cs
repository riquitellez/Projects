using System;
using System.Collections.Generic;
using System.Text;
using CallCenterBO.Data.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CallCenterBO.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<CancelacionDisponibilidad> CancelacionesDisponibilidad { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Disponibilidad> Disponibilidades { get; set; }
        public DbSet<Duracion> Duraciones { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EmpresaProfesor> EmpresasProfesor { get; set; }
        public DbSet<Linea> Lineas { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<TipoDeCancelacion> TiposDeCancelacion { get; set; }
        public DbSet<TipoDeIncidencia> TiposDeIncidencia { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<SemanaTopics> SemanasTopics { get; set; }
        public DbSet<TopicSemanaTopics> TopicsSemanasTopics { get; set; }
        public DbSet<Nivel> Niveles { get; set; }

    }
}
