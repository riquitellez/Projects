using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursosYViajes.DatosEF
{
    public class ContextoCursoYViajes:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=ELIANA-PC\SQLEXPRESS;Database=CursosYViajes;Trusted_Connection=True;");
            }
        }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursoPorAlumno> CursosPorAlumno { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<PrecioHospedajePorCursoPorSemana> PrecioHospedajePorCursoPorSemanas { get; set; }
        public DbSet<PrecioPorCursoPorSemana> PrecioPorCursoPorSemana { get; set; }
        public DbSet<TipoHospedaje> TipoHospedaje { get; set;   }



    }
}
