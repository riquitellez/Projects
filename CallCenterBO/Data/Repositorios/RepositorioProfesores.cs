using CallCenterBO.Data.Entidades;
using CallCenterBO.Models.Profesores;
using CallCenterBO.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Data.Repositorios
{
    public class RepositorioProfesores
    {
        private ApplicationDbContext _contexto;

        public RepositorioProfesores(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IndexModel ObtenerListadoProfesores()
        {
            BuscadorProfesorModel buscador = new BuscadorProfesorModel();
            IEnumerable<ListadoProfesorModel> profesores = _contexto.Profesores.Select(x => new
            {
                x.Id,
                x.Nombre,
                empresa = x.EmpresaProfesor.Nombre,
                x.FechaDeBaja
            }).Select(x => new ListadoProfesorModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                NombreEmpresa = x.empresa,
                FechaDeBaja = x.FechaDeBaja
            });
            return new IndexModel
            {
                Buscador = buscador,
                ListadoProfesores = profesores
            };
        }

        public IndexModel BuscarProfesor(string textoBuscador)
        {
            var profesores = _contexto.Profesores.Where(x => x.Nombre.Contains(textoBuscador)).Select(x => new
            {
                x.Id,
                x.Nombre,
                nombreEmpresa = x.EmpresaProfesor.Nombre,
                x.FechaDeBaja
            }).Select(x => new ListadoProfesorModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                NombreEmpresa = x.nombreEmpresa,
                FechaDeBaja = x.FechaDeBaja
            });

            BuscadorProfesorModel buscador = new BuscadorProfesorModel
            {
                TextoBuscador = textoBuscador
            };

            IndexModel model = new IndexModel
            {
                Buscador = buscador,
                ListadoProfesores = profesores
            };
            return model;
        }

        public CrearProfesorModel ObtenerModeloCrearProfesor()
        {
            var diccionarioEmpresas = MostrarListadoEmpresas();
            var model = new CrearProfesorModel
            {
                 Empresas = diccionarioEmpresas,
                 IdEmpresaSeleccionda = Guid.Empty
            };

            return model;
        }

        public IDictionary<Guid, string> ObtenerListadoEmpresas()
        {
            return MostrarListadoEmpresas();
        }

        //Retorna Guid para redirigir a detalles profesor tras creación
        public Guid InsertarProfesor(CrearProfesorModel model)
        {
            if (ValidateModel(model, out string error))
            {
                Profesor profesor;
                if ((model.IdEmpresaSeleccionda == null || model.IdEmpresaSeleccionda == Guid.Empty) && (!string.IsNullOrWhiteSpace(model.NombreEmpresa)))
                {
                    var empresa = new EmpresaProfesor
                    {
                        Id = Guid.NewGuid(),
                        Nombre = model.NombreEmpresa
                    };
                    profesor = new Profesor
                    {
                        Id = Guid.NewGuid(),
                        Nombre = model.Nombre,
                        EmpresaProfesor = empresa,
                        FechaDeAlta = DateTime.Now,
                    };
                }
                else
                {
                    profesor = new Profesor
                    {
                        Id = Guid.NewGuid(),
                        Nombre = model.Nombre,
                        IdEmpresaProfesor = model.IdEmpresaSeleccionda == Guid.Empty ? null : (Guid?)model.IdEmpresaSeleccionda,
                        FechaDeAlta = DateTime.Now
                    };
                }

                _contexto.Add(profesor);
                _contexto.SaveChanges();
                return profesor.Id;
            }
            else
            {
                throw new ValidationException(error);
            }

        }

        public void Reactivar(Guid idProfesor)
        {
            var profesor = _contexto.Profesores.Find(idProfesor);
            profesor.Reactivar();
            _contexto.SaveChanges();
        }

        public DarDeBajaProfesorModel ObtenerModeloDarDeBaja(Guid idProfesor)
        {
            var profesor = _contexto.Profesores.Where(x => x.Id == idProfesor).Select(x => new
            {
                x.Id,
                x.Nombre,
                x.FechaDeBaja
            }).Single();

            return new DarDeBajaProfesorModel
            {
                Id = idProfesor,
                Nombre = profesor.Nombre,
                FechaDeBaja = DateTime.Now
            };
        }
        public void DarDeBaja(Guid idProfesor, DateTime fechaDeBaja)
        {
            var profesor = _contexto.Profesores.Find(idProfesor);
            profesor.DarDeBaja(fechaDeBaja);
            _contexto.SaveChanges();
        }

        public void EditarProfesor(EditarProfesorModel model)
        {
            var alumno = _contexto.Profesores.Find(model.IdProfesor);
            alumno.ModificarDatos(model.Nombre, model.IdEmpresaSeleccionada, model.FechaDeAlta, model.FechaDeBaja);
            _contexto.SaveChanges();
        }

        public DetallesProfesorModel ObtenerDetallesProfesor(Guid idProfesor, int numClasesDadas = 5)
        {
            var profesor = _contexto.Profesores.Where(x=>x.Id==idProfesor).Select(x=> new
            {
                x.Id,
                x.Nombre,
                x.EmpresaProfesor,
                x.FechaDeAlta,
                x.FechaDeBaja,
                clasesDadas = x.ClasesDadas.OrderByDescending(y => y.FechaHoraInicio).Take(numClasesDadas).Select(y => new
                {
                    y.Id,
                    y.FechaHoraInicio,
                    y.FechaHoraFin,
                    y.Alumno.Codigo,
                    TipoIncidencia = y.TipoDeIncidencia == null ? string.Empty : y.TipoDeIncidencia.Nombre,
                    nombreLinea = y.Linea.Nombre
                })            
            }).Single();
            return new DetallesProfesorModel
            {
                Id = idProfesor,
                Nombre = profesor.Nombre,
                NombreEmpresa = profesor.EmpresaProfesor == null ? string.Empty : profesor.EmpresaProfesor.Nombre,
                FechaDeAlta = profesor.FechaDeAlta,
                FechaDeBaja = profesor.FechaDeBaja,
                ClasesDadas = profesor.clasesDadas.Select(x => new ClaseDadaProfesorGridModel
                {
                    Id = x.Id,
                    CodigoAlumno = x.Codigo,
                    Linea = x.nombreLinea,
                    FechaHoraInicio = x.FechaHoraInicio,
                    FechaHoraFin = x.FechaHoraFin,
                    TipoDeIncidencia = x.TipoIncidencia
                })
            };
        }

        private IDictionary<Guid, string> MostrarListadoEmpresas()
        {
            var diccionario = _contexto.EmpresasProfesor.ToDictionary(x => x.Id, x => x.Nombre);
            diccionario.Add(Guid.Empty, "Seleccione empresa");
            diccionario = diccionario.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            return diccionario;
        }
        public EditarProfesorModel ObtenerProfesorParaEditar(Guid idProfesor)
        {
            var diccionarioEmpresas = MostrarListadoEmpresas();
            var profesor = _contexto.Profesores.Where(x => x.Id == idProfesor).Select(x => new
            {
                x.Nombre,
                x.IdEmpresaProfesor,
                x.FechaDeAlta,
                x.FechaDeBaja
            }).Single();

            return new EditarProfesorModel
            {
                IdProfesor = idProfesor,
                Nombre = profesor.Nombre,
                IdEmpresaSeleccionada = profesor.IdEmpresaProfesor,
                EmpresasProfesores = diccionarioEmpresas,
                FechaDeAlta = profesor.FechaDeAlta,
                FechaDeBaja = profesor.FechaDeBaja
            };
        }

        private bool ValidateModel(CrearProfesorModel model, out string error)
        {
            error = string.Empty;
            if (model.IdEmpresaSeleccionda != Guid.Empty && !string.IsNullOrWhiteSpace(model.NombreEmpresa))
            {
                error = "No introduzca nombre si ha escogido una empresa existente";
                return false;
            }

            if (_contexto.EmpresasProfesor.Any(x => x.Nombre == model.NombreEmpresa))
            {
                error = "Esta empresa ya existe";
                return false;
            }

            return true;
        }
    }
}
