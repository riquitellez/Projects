using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallCenterBO.Data.Repositorios;
using CallCenterBO.Models.Alumnos;
using CallCenterBO.Util.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CallCenterBO.Controllers
{
    public class AlumnosController : Controller
    {
        private RepositorioAlumnos _repositorio;

        public AlumnosController(RepositorioAlumnos reposotorio)
        {
            _repositorio = reposotorio;
        }

        public IActionResult Index()
        {
            var listadoAlumnos = _repositorio.ObtenerListadoAlumnos();
            return View(listadoAlumnos);
        }

        [HttpPost]
        public IActionResult Index(IndexModel model)
        {
            IndexModel busqueda = _repositorio.BuscarAlumno(model.Buscador.TextoBuscador);
            return View(busqueda);
        }

        public IActionResult CrearAlumno()       
        {
            var model = _repositorio.ObtenerModeloCrearAlumno();
            return View(model);
        }

        [HttpPost]
        public IActionResult CrearAlumno(CrearAlumnoModel model)
        {
            try
            {
                if (model.IdNivelSeleccionado == Guid.Empty)
                {
                    model.IdNivelSeleccionado = null;
                }
                _repositorio.CrearAlumno(model);
                return Redirect("Index");
            }
            catch (ValidationException ex)
            {
                model = (CrearAlumnoModel)_repositorio.AnadirDiccionariosAlumnos(model);
                model.Mensaje = ex.Message;
                return View(model);
            }           
        }

        public IActionResult EditarAlumno(Guid idAlumno)
        {
            var model = _repositorio.ObtenerAlumnoParaEditar(idAlumno);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditarAlumno(EditarAlumnoModel model)
        {
            _repositorio.EditarAlumno(model);
            return Redirect("Index");
        }

        public IActionResult DetallesAlumno(Guid idAlumno)
        {
            var model = _repositorio.ObtenerDetallesAlumno(idAlumno);
            return View(model);
        }
        public IActionResult DarDeBaja(Guid idAlumno)
        {
            _repositorio.DarDeBaja(idAlumno);
            return Redirect("Index");
        }

        public IActionResult Reactivar(Guid idAlumno)
        {
            _repositorio.Reactivar(idAlumno);
            return Redirect("Index");
        }
        public IActionResult DarDeBajaAlumno(Guid idAlumno)
        {
            var model = _repositorio.ObtenerAlumnoParaDarDeBaja(idAlumno);
            return View(model);
        }

        [HttpPost]
        public IActionResult DarDeBajaAlumno(DarDeBajaAlumnoModel model)
        {
            _repositorio.DarDeBajaConFecha(model.Id, model.FechaDeBaja);
            return Redirect("Index"); //Hay que redirect a detalles
        }
    }
}