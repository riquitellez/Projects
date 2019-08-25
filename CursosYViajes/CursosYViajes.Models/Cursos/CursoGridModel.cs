using System;

namespace CursosYViajes.Models.Cursos
{
    public class CursoGridModel
    {
        public Guid IdCurso{get;set;}
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public DateTime? FechaDeBaja { get; set; }

    }
}