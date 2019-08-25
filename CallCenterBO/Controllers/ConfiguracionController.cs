using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallCenterBO.Data.Repositorios;
using CallCenterBO.Models.Configuracion;
using Microsoft.AspNetCore.Mvc;

namespace CallCenterBO.Controllers
{
    public class ConfiguracionController : Controller
    {
        private RepositorioConfiguracion _repositorio;

        public ConfiguracionController(RepositorioConfiguracion reposotorio)
        {
            _repositorio = reposotorio;
        }
        public IActionResult Index()
        {
            return RedirectToAction("ListadoLineaYDisponibilidad");
        }

        public IActionResult ListadoLineaYDisponibilidad()
        {
            var listadoLineaYDisponibilidad = _repositorio.ObtenerModeloListadoLineaYDisponibilidad();
            return View(listadoLineaYDisponibilidad);
        }

        /*[HttpPost]
        public IActionResult ListadoLineaYDisponibilidad(ListadoDisponibilidadModel model)
        {
            _repositorio.GuardarAsignacionDeLineas(model);
            return RedirectToAction("ListadoLineaYDisponibilidad")
        }*/

        public IActionResult ListadoLineaAsignada()
        {
            var listadoLineaAsignadaModel = _repositorio.ObtenerModeloListadoLineaAsignada();
            return View(listadoLineaAsignadaModel);
        }

        public IActionResult CrearLinea()
        {
            var model = _repositorio.ObtenerModeloParaCrearLinea();
            return View(model);          
        }

        [HttpPost]
        public IActionResult CrearLinea(CrearLineaModel model)
        {
            if (model.IdEmpresaProfesorSeleccionada == Guid.Empty)
            {
                model.IdEmpresaProfesorSeleccionada = null;
            }
            _repositorio.CrearLinea(model);
            return RedirectToAction("Index");
        }

    }
}