using CallCenterBO.Data.Entidades;
using CallCenterBO.Models.Alumnos;
using CallCenterBO.Models.Interfaces;
using CallCenterBO.Util;
using CallCenterBO.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenterBO.Data.Repositorios
{
    public class RepositorioAlumnos
    {
        private ApplicationDbContext _contexto;

        public RepositorioAlumnos(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }       

        public IndexModel ObtenerListadoAlumnos(int numAlumnos = 100)
        {
            var dias = DateTime.Now.GetMondayDateTime();
            BuscadorAlumnoModel modeloBuscador = new BuscadorAlumnoModel();
            var alumnos = _contexto.Alumnos.Select(x => new
            {
                x.Codigo,
                x.Nombre,
                x.Apellidos,
                empresaNombre = x.Empresa.Nombre,
                x.Timetable,
                clasesDadas = x.ClasesDadas.Where(y => y.FechaHoraInicio > dias).Count(),
                x.FechaDeBaja,
                x.IdAlumno
            }).Select(x => new ListadoAlumnoModel
            {
                IdAlumno = x.IdAlumno,
                Codigo = x.Codigo,
                Nombre = x.Nombre,
                Apellidos = x.Apellidos,
                NombreEmpresa = x.empresaNombre,
                TimeTable = x.Timetable,
                ClasesDadasEnLaSemana = x.clasesDadas, //Se necesitaría las últimas de la semana en curso
                FechaDeBaja = x.FechaDeBaja
                
            }).Take(numAlumnos);         

            IndexModel indexModel = new IndexModel
            {
                Buscador = modeloBuscador,
                Alumnos = alumnos
            };
            return indexModel;
        }

        public IndexModel BuscarAlumno(string textoBuscador)
        {
            var dias = DateTime.Now.GetMondayDateTime();
            var alumnos = _contexto.Alumnos.Where(x => x.Codigo.Contains(textoBuscador) ||
                x.Nombre.Contains(textoBuscador) ||
                x.Apellidos.Contains(textoBuscador) ||
                x.Email.Contains(textoBuscador))
                .Select(x => new
                    {
                        x.IdAlumno,
                        x.Codigo,
                        x.Nombre,
                        x.Apellidos,
                        nombreEmpresa = x.Empresa.Nombre,
                        clasesDadas = x.ClasesDadas.Where(y=>y.FechaHoraInicio>dias).Count(),
                        x.Timetable,
                        x.FechaDeBaja
                    }).Select(x => new ListadoAlumnoModel
                    {
                        IdAlumno = x.IdAlumno,
                        Codigo = x.Codigo,
                        Nombre = x.Nombre,
                        Apellidos = x.Apellidos,
                        NombreEmpresa = x.nombreEmpresa,
                        TimeTable = x.Timetable,
                        ClasesDadasEnLaSemana = x.clasesDadas, 
                        FechaDeBaja = x.FechaDeBaja
                    });

            BuscadorAlumnoModel modeloBuscador = new BuscadorAlumnoModel
            {
                TextoBuscador = textoBuscador
            };

            IndexModel indexModel = new IndexModel
            {
                Buscador = modeloBuscador,
                Alumnos = alumnos
            };
            return indexModel;

        }



        public void CrearAlumno(CrearAlumnoModel model)
        {
            if (ValidateModel(model, out string error))
            {
                Alumno alumno = null;
                if (model.IdEmpresaSeleccionada != Guid.Empty && string.IsNullOrWhiteSpace(model.NombreEmpresa))
                {
                    alumno = new Alumno(
                        model.Codigo,
                        model.Nombre,
                        model.Apellidos,
                        model.Email,
                        model.Timetable,
                        model.FechaDeAlta,
                        model.IdNivelSeleccionado == Guid.Empty ? null : model.IdNivelSeleccionado,
                        model.IdEmpresaSeleccionada == Guid.Empty ? null : model.IdEmpresaSeleccionada,
                        model.IdPlanSeleccionado);
                }
                else if (!string.IsNullOrWhiteSpace(model.NombreEmpresa))
                {
                    Empresa empresa = new Empresa(model.NombreEmpresa);
                    alumno = new Alumno(model.Codigo, model.Nombre, model.Apellidos, model.Email, model.Timetable, model.FechaDeAlta, empresa, model.IdNivelSeleccionado, model.IdPlanSeleccionado);
                }
                else
                {
                    alumno = new Alumno(model.Codigo, model.Nombre, model.Apellidos, model.Email, model.Timetable, model.FechaDeAlta, model.IdNivelSeleccionado, model.IdPlanSeleccionado);
                }
                    
                _contexto.Alumnos.Add(alumno);
                _contexto.SaveChanges();
            }
            else
            {
                throw new ValidationException(error);
            }
        }

        public void Reactivar(Guid idAlumno)
        {
            var alumno = _contexto.Alumnos.Find(idAlumno);
            alumno.ReactivarAlta();
            _contexto.SaveChanges();
        }

        public void DarDeBaja(Guid idAlumno)
        {
            var alumno = _contexto.Alumnos.Find(idAlumno);
            alumno.DarDeBaja();
            _contexto.SaveChanges();
        }
        public DarDeBajaAlumnoModel ObtenerAlumnoParaDarDeBaja(Guid idAlumno)
        {
            var alumno = _contexto.Alumnos.Where(x => x.IdAlumno == idAlumno).Select(x => new
            {
                x.IdAlumno,
                x.Codigo,
                x.Nombre,
                x.Apellidos,
                x.FechaDeBaja
            }).Single();
            return new DarDeBajaAlumnoModel
            {
                Id = idAlumno,
                Nombre = alumno.Nombre,
                Apellidos = alumno.Apellidos,
                Codigo = alumno.Codigo,
                FechaDeBaja = DateTime.Now
            };
        }
        public void DarDeBajaConFecha(Guid idAlumno, DateTime fechaDeBaja)
        {
            var alumno = _contexto.Alumnos.Find(idAlumno);
            alumno.DarDeBaja(fechaDeBaja);
            _contexto.SaveChanges();
        }

        public DetallesAlumnoModel ObtenerDetallesAlumno(Guid idAlumno, int numClasesDadas=5)
        {
            var alumno = _contexto.Alumnos.Where(x => x.IdAlumno == idAlumno).Select(x => new
            {
                x.IdAlumno,
                x.Codigo,
                x.Nombre,
                x.Apellidos,
                x.Email,
                x.Nivel,
                x.Empresa,
                x.Plan,
                x.Timetable,
                x.FechaDeAlta,
                x.FechaDeBaja,
                clasesDadas = x.ClasesDadas.OrderByDescending(y => y.FechaHoraInicio).Take(numClasesDadas).Select(y=>new
                {
                    y.Id,
                    y.FechaHoraInicio,
                    y.FechaHoraFin,
                    nombreProfesor =  y.Profesor.Nombre,
                    TipoIncidencia = y.TipoDeIncidencia==null?string.Empty:y.TipoDeIncidencia.Nombre,
                    nombreLinea = y.Linea.Nombre
                })
            }).Single();
            return new DetallesAlumnoModel
            {
                IdAlumno = idAlumno,
                Codigo = alumno.Codigo,
                Nombre = alumno.Nombre,
                Apellidos = alumno.Apellidos,
                Email = alumno.Email,
                NombreEmpresa = alumno.Empresa==null?string.Empty:alumno.Empresa.Nombre,
                NombrePlan = alumno.Plan.Nombre,
                NombreNivel = alumno.Nivel == null ? string.Empty : alumno.Nivel.Nombre,
                Timetable = alumno.Timetable,
                FechaDeAlta = alumno.FechaDeAlta,
                FechaDeBaja = alumno.FechaDeBaja,
                ClasesDadas = alumno.clasesDadas.Select(x=>new ClaseDadaGridModel
                {
                    Id=x.Id,
                    FechaHoraInicio = x.FechaHoraInicio,
                    FechaHoraFin = x.FechaHoraFin,
                    NombreProfesor = x.nombreProfesor,
                    Linea = x.nombreLinea,
                    TipoDeIncidencia = x.TipoIncidencia
                })
            };
        }

        public EditarAlumnoModel ObtenerAlumnoParaEditar(Guid idAlumno)
        {
            var model = (EditarAlumnoModel)AnadirDiccionariosAlumnos(new EditarAlumnoModel());
            var alumno = _contexto.Alumnos.Where(x => x.IdAlumno == idAlumno).Select(x => new
              {
                x.Codigo,
                x.Nombre,
                x.Apellidos,
                x.Email,
                x.IdEmpresa,
                x.FechaDeAlta,
                x.FechaDeBaja,
                x.IdPlan,
                x.IdNivel 
              }).Single();

            model.IdAlumno = idAlumno;
            model.Codigo = alumno.Codigo;
            model.Nombre = alumno.Nombre;
            model.Apellidos = alumno.Apellidos;
            model.Email = alumno.Email;
            model.IdEmpresaSeleccionada = alumno.IdEmpresa == null? Guid.Empty : alumno.IdEmpresa;
            model.IdPlanSeleccionado = alumno.IdPlan;
            model.FechaDeAlta = alumno.FechaDeAlta;
            model.IdNivelSeleccionado = alumno.IdNivel == null? Guid.Empty : alumno.IdNivel;
            model.FechaDeBaja = alumno.FechaDeBaja;

            return model;
            
        }

        public void EditarAlumno(EditarAlumnoModel model)
        {
            var alumno = _contexto.Alumnos.Find(model.IdAlumno);
            alumno.ModificarDatos(
                model.Nombre, 
                model.Apellidos, 
                model.Email, 
                model.Timetable,  
                model.Codigo, 
                model.IdPlanSeleccionado,
                model.IdEmpresaSeleccionada == Guid.Empty ? null : model.IdEmpresaSeleccionada, 
                model.IdNivelSeleccionado == Guid.Empty ? null : model.IdNivelSeleccionado,
                model.FechaDeAlta, 
                model.FechaDeBaja);

            _contexto.SaveChanges();
        }

        public IAlumnoModel AnadirDiccionariosAlumnos(IAlumnoModel model)
        {
            var empresas = _contexto.Empresas.ToDictionary(x => x.IdEmpresa, x => x.Nombre);
            empresas.Add(Guid.Empty, "Seleccione una empresa");
            empresas = empresas.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            var idEmpresa = empresas.First().Key;
            var niveles = _contexto.Niveles.ToDictionary(x => x.Id, x => x.Nombre);
            niveles.Add(Guid.Empty, "Seleccione nivel");
            niveles = niveles.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            var idNivel = niveles.First().Key;
            var planes = _contexto.Planes.ToDictionary(x => x.Id, x => x.Nombre);
            Guid idPlan = planes.First().Key;
            model.IdEmpresaSeleccionada = idEmpresa;
            model.IdNivelSeleccionado = idNivel;
            model.IdPlanSeleccionado = idPlan;
            model.Empresas = empresas;
            model.Niveles = niveles;
            model.Planes = planes;
            return model;
        }

        private bool ValidateModel(CrearAlumnoModel model, out string error)
        {
            error = string.Empty;
            if (model.IdEmpresaSeleccionada != Guid.Empty && !string.IsNullOrWhiteSpace(model.NombreEmpresa))
            {
                error = "No introduzca nombre si ha escogido una empresa existente";
                return false;
            }
            if (_contexto.Alumnos.Any(x=>x.Codigo==model.Codigo))
            {
                error = "Este código ya existe";
                return false;
            }

            if (_contexto.Alumnos.Any(x => x.Email == model.Email))
            {
                error = "Este email(alumno) ya existe";
                return false;
            }

            if (_contexto.Empresas.Any(x => x.Nombre == model.NombreEmpresa))
            {
                error = "Esta empresa ya existe";
                return false;
            }

            return true;
        }

        public IAlumnoModel ObtenerModeloCrearAlumno()
        {
            IAlumnoModel model = new CrearAlumnoModel       
            {               
                FechaDeAlta = DateTime.Now
            };

            model = AnadirDiccionariosAlumnos(model);
            return model;
        }        
    }
}
