using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursosYViajes.Models.Precios;
using CursosYViajes.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace CursosYViajes.Web.Controllers
{
    public class PreciosController : Controller
    {
        private PreciosServicio _servicio;

        public PreciosController()
        {
            _servicio = new PreciosServicio();
        }
        public IActionResult Index()
        {
            var cursos = _servicio.GetCursos();
            return View (cursos);
        }

        public IActionResult PreciosCurso(Guid idCurso)
        {
            var precios = _servicio.ObtenerPrecios(idCurso);
            if (precios.PrecioPorSemana == null)
            {
                precios.PrecioPorSemana = new Dictionary<int, double>();
            }
            for (int i = 1; i <= 53; i++)
            {
                if (!precios.PrecioPorSemana.ContainsKey(i))
                {
                    precios.PrecioPorSemana.Add(i, 0);
                }
            }
            return View(precios);
        }

        [HttpPost]
        public IActionResult PreciosCurso(CursoPrecioModel model)
        {
            _servicio.GuardarPreciosCurso(model.IdCurso, model.PrecioPorSemana);
            return View(model);
        }      

        public IActionResult PreciosHospedaje(Guid idCurso, int idTipoHospedaje=1)
        {
            var preciosHospedaje = _servicio.ObtenerPreciosHospedaje(idCurso, idTipoHospedaje);
            if (preciosHospedaje.PrecioPorSemana == null)
            {
                preciosHospedaje.PrecioPorSemana = new Dictionary<int, double>();
            }
            for (int i = 1; i <= 53; i++)
            {
                if (!preciosHospedaje.PrecioPorSemana.ContainsKey(i))
                {
                    preciosHospedaje.PrecioPorSemana.Add(i, 0);
                }
            }
            return View(preciosHospedaje);
        }

        [HttpPost]
        public IActionResult PreciosHospedaje (HospedajePrecioModel model)
        {
            _servicio.GuardarPreciosHospedaje(model.IdCurso, model.TipoHospedajeSeleccionado, model.PrecioPorSemana);
            return RedirectToAction ("PreciosHospedaje", new {idCurso = model.IdCurso, idTipoHospedaje = model.TipoHospedajeSeleccionado});
        }

        [HttpPost]
        public IActionResult CargarPrecioHospedaje(HospedajePrecioModel model)
        {
            return RedirectToAction("PreciosHospedaje", new { idCurso = model.IdCurso, idTipoHospedaje = model.TipoHospedajeSeleccionado });
        }

        public IActionResult CalcularPrecios()
        {
            var model = _servicio.ObtenerDatosParaCalcularPrecio();
            return View(model);
        }

        [HttpPost]
        public IActionResult CalcularPrecios(CalculadorPreciosModel model)
        {
            var modelPrecios = _servicio.CalcularPrecioTotalCurso(model.IdCursoSeleccionado, model.TipoDeHospedajeSeleccionado, model.IdSemanaInicialSeleccionada, model.IdSemanaFinalSeleccionada);
            return View(modelPrecios);
        }

    }
}