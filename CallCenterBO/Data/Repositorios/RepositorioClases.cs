using CallCenterBO.Models.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Data.Repositorios
{
    public class RepositorioClases
    {
        private ApplicationDbContext _contexto;

        public RepositorioClases(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IndexModel ObtenerClasesParaIndex(int numDeRegistros = 20)
        {
            CalculadorNumeroDeClasesModel model = new CalculadorNumeroDeClasesModel();
            var listadoDeClases = _contexto.Clases.Select(x => new
            {
                x.Alumno.Codigo,
                x.Profesor.Nombre,
                x.FechaHoraInicio,
                x.Id,
                x.TipoDeIncidencia
            }).Select(x => new ListadoClaseModel
            {
                CodigoAlumno = x.Codigo,
                NombreProfesor = x.Nombre,
                IdClase = x.Id,
                IdTipoIncidencia = x.TipoDeIncidencia.Id,
                TipoIncidencia = x.TipoDeIncidencia.Nombre,
                FechaClase = x.FechaHoraInicio
            }).Take(numDeRegistros).ToList();           

            return new IndexModel
            {
                CalculadorDeClasesDadas = model,
                ListadoDeClasesDadas = listadoDeClases
            };
        }
    }
}
