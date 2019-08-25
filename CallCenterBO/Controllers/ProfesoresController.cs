using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallCenterBO.Data.Repositorios;
using CallCenterBO.Models.Profesores;
using CallCenterBO.Util.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CallCenterBO.Controllers
{
    public class ProfesoresController : Controller
    {
        private RepositorioProfesores _repositorio;

        public ProfesoresController(RepositorioProfesores reposotorio)
        {
            _repositorio = reposotorio;
        }
        public IActionResult Index()
        {
            var model = _repositorio.ObtenerListadoProfesores();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(IndexModel model)
        {
            IndexModel busqueda = _repositorio.BuscarProfesor(model.Buscador.TextoBuscador);
            return View(busqueda);
        }

        public IActionResult CrearProfesor()
        {
            var model = _repositorio.ObtenerModeloCrearProfesor();
            return View(model);
        }

        
        [HttpPost]
        public IActionResult CrearProfesor(CrearProfesorModel model)
        {
            try
            {
                var idProfesor = _repositorio.InsertarProfesor(model);
                return RedirectToAction("DetallesProfesor", new { idProfesor });
            }

            catch (ValidationException vex)
            {
                model.Empresas = _repositorio.ObtenerListadoEmpresas();
                model.Mensaje = vex.ToString();
                return View(model);
            }

            catch
            {
                model.Empresas = _repositorio.ObtenerListadoEmpresas();
                model.Mensaje = "¡Ha ocurrido un error inesperado! Estamos trabajando en ello";
                return View(model);
            }
        }

            // Riqui solo
        public IActionResult DetallesProfesor(Guid idProfesor)
        {
            var model = _repositorio.ObtenerDetallesProfesor(idProfesor);
            return View(model);
        }

        public IActionResult EditarProfesor(Guid idProfesor)
        {
            var model = _repositorio.ObtenerProfesorParaEditar(idProfesor);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditarProfesor(EditarProfesorModel model)
        {
            if(model.IdEmpresaSeleccionada == Guid.Empty)
            {
                model.IdEmpresaSeleccionada = null;
            }
            _repositorio.EditarProfesor(model);
            return Redirect("Index"); //Da error cuando el IdEmpresa es null porque es FK.
        }

        public IActionResult DarDeBajaProfesor(Guid idProfesor)
        {
            var model = _repositorio.ObtenerModeloDarDeBaja(idProfesor);
            return View(model);
        }
        [HttpPost]
        public IActionResult DarDeBajaProfesor(DarDeBajaProfesorModel model) // No muestra la fecha de baja
        {            
            _repositorio.DarDeBaja(model.Id, model.FechaDeBaja);
            return Redirect("Index");
        }

        public IActionResult Reactivar(Guid idProfesor) //Aunque el profesor tenga fecha de baja no se muestra.
        {
            _repositorio.Reactivar(idProfesor);
            return Redirect("Index");
        }
    } 

}