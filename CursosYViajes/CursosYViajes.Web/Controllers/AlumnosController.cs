using System;
using System.Collections.Generic;
using System.Linq;
using CursosYViajes.Models.Alumnos;
using CursosYViajes.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace CursosYViajes.Web.Controllers
{
    public class AlumnosController : Controller
    {
        private AlumnosServicio _servicio;

        public AlumnosController()
        {
            _servicio = new AlumnosServicio();
        }

        public IActionResult Index()
        {
            var models = _servicio.ObtenerAlumnos();
            return View(models);
        }
        [HttpPost]
        public IActionResult Index(IndexModel model)
        {
            IndexModel busqueda = _servicio.BuscarAlumno(model.Buscador.TextoBuscador);
            return View(busqueda);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AnadirAlumnoModel model)
        {
            _servicio.AnadirAlumno(model);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid idAlumno)
        {
            EditarAlumnoModel alumno = _servicio.ObtenerAlumnoParaEditar(idAlumno);
            return View(alumno);
        }
        [HttpPost]
        public IActionResult Edit(EditarAlumnoModel model)
        {
            _servicio.EditarAlumno(model);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid idAlumno)
        {
            DetallesAlumnoModel detalles = _servicio.ObtenerDetallesAlumno(idAlumno);
            return View(detalles);
        }

        public IActionResult DetailsCurso(Guid idCurso)
        {
            return RedirectToAction("Details", "Cursos", new { IdCurso = idCurso });
        }
        public IActionResult Delete(Guid idAlumno)
        {
            DarDeBajaAlumnoModel model = new DarDeBajaAlumnoModel
            {
                IdAlumno = idAlumno,
                FechaDeBaja = DateTime.Now
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(DarDeBajaAlumnoModel model)
        {
            _servicio.DarDeBajaAlumno(model.IdAlumno, model.FechaDeBaja);
            return RedirectToAction("Index");
        }

        public IActionResult Reactivar(Guid idAlumno)
        {
            _servicio.ReactivarAlta(idAlumno);
            return RedirectToAction("Index");
        }

        public IActionResult Matricular(Guid idAlumno)
        {             
            MatricularAlumnoModel model = _servicio.ObtenerMatriculaParaAlumno(idAlumno);
            return View(model);
        }
        //Chequear devolución de servicio True or False. Método MatricularAlumno
        [HttpPost]
        public IActionResult Matricular(MatricularAlumnoModel model)
        {
            _servicio.MatricularAlumno(model.IdAlumno, model.IdCurso, model.FechaDeAlta);
            return RedirectToAction("Details", new { idAlumno = model.IdAlumno });
        }

    }
}