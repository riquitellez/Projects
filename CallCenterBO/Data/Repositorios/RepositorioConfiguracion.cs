using System;
using CallCenterBO.Models.Configuracion;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallCenterBO.Data.Entidades;

namespace CallCenterBO.Data.Repositorios
{
    public class RepositorioConfiguracion
    {
        private ApplicationDbContext _contexto;

        public RepositorioConfiguracion(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public ListadoLineaDisponibilidadModel ObtenerModeloListadoLineaYDisponibilidad()
        {
            var lineas = _contexto.Lineas.Where(x => x.FechaDeBaja == null).Select(x => new
            {
                x.Id,
                x.Nombre,
                x.Numero,
                x.IdEmpresa,
                empresa = x.Empresa != null ? x.Empresa.Nombre : string.Empty 
            });
            var profesores = _contexto.Profesores.Where(x => x.FechaDeBaja == null).Select(x => new
            {
                x.Id,
                x.Nombre,
                x.IdEmpresaProfesor,
                nombreEmpresa = x.EmpresaProfesor != null ? x.EmpresaProfesor.Nombre : string.Empty
            }).ToDictionary(x => x.Id, x => new ProfesorEmpresaModel
            {
                IdProfesor = x.Id,
                NombreProfesor = x.Nombre,
                IdEmpresaProfesor = x.IdEmpresaProfesor,
                NombreEmpresa = x.nombreEmpresa
            });
            //profesores.Add(Guid.Empty, "Seleccione Linea y profesor");
            return new ListadoLineaDisponibilidadModel
            {
                DisponibilidadesPorLinea = lineas.ToDictionary(x => x.Id, x => new ListadoDisponibilidadModel
                {
                    IdLinea = x.Id,
                    NombreLinea = x.Nombre,
                    NumeroLinea = x.Numero,
                    IdEmpresa = x.IdEmpresa,
                    IdProfesorSeleccionado = Guid.Empty,
                    FechaHoraInicio = DateTime.Now,
                    FechaHoraFin = DateTime.Now,
                    NombreEmpresa = x.empresa
                }),
                Profesores = profesores //A los porfes hay que añadir elemento vacío. Hecho???? ver linea 28
            };
        }

        /*public void GuardarAsignacionDeLineas(ListadoDisponibilidadModel model)
        {
            IList<Disponibilidad> disponibilidades = new List
            {
                    foreach (item in model)
                {
                   
                }
            }
        }*/

        public void CrearLinea(CrearLineaModel model)
        {
            Linea linea = new Linea(model.Nombre, model.Numero, model.IdEmpresaProfesorSeleccionada);
            _contexto.Add(linea);
            _contexto.SaveChanges();
        }

        public CrearLineaModel ObtenerModeloParaCrearLinea()
        {
            var empresasProfes = _contexto.EmpresasProfesor.ToDictionary(x=>x.Id, x=>x.Nombre);
            //empresasProfes.Add(Guid.Empty, "Seleccione empresa");
            empresasProfes.OrderBy(x=>x.Value);
            empresasProfes.Add(Guid.Empty, "Seleccione empresa");
            empresasProfes = empresasProfes.Reverse().ToDictionary(x=>x.Key, x=>x.Value);
            return new CrearLineaModel
            {
                EmpresasProfesores = empresasProfes,
                FechaDeAlta = DateTime.Now
            };
        }

        public ListadoLineaAsignadaModel ObtenerModeloListadoLineaAsignada()
        {
            return new ListadoLineaAsignadaModel();
        }
    }
}
