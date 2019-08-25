using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursosYViajes.Models.Cursos;
using CursosYViajes.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace CursosYViajes.Web.Controllers
{
    public class CursosController : Controller
    {
        private CursosServicio _servicio;
        private AlumnosServicio _servicioAlumnos;

        public CursosController()
        {
            _servicio = new CursosServicio();
            _servicioAlumnos = new AlumnosServicio();
        }

        public IActionResult Index()
        {
           var cursos = _servicio.GetCursos();
           return View(cursos);
        }

        [HttpPost]
        public IActionResult Index(IndexModel model)
        {
            IndexModel busqueda = _servicio.BuscarCursos(model.Buscador.IdPais, model.Buscador.TextoBuscador);
            return View(busqueda);
        }
        public IActionResult Create()
        {
            AnadirCursoModel curso = new AnadirCursoModel();
            curso.Paises = _servicio.VerPaises();
            return View(curso);
        }
        [HttpPost]
        public IActionResult Create(AnadirCursoModel model)
        {
            _servicio.CrearCurso(model);
            return Redirect("Index");
        }
        public IActionResult Edit(Guid idCurso)
        {
            EditarCursoModel curso = _servicio.ObtenerCursoParaEditar(idCurso);
            curso.Paises = _servicio.VerPaises();
            return View(curso);
        }
        [HttpPost]
        public IActionResult Edit(EditarCursoModel model)
        {
            _servicio.EditarCurso(model);
            return Redirect ("Index");
        }
        public IActionResult Details(Guid idCurso)
        {
            DetallesCursoModel curso = _servicio.ObtenerDetallesCurso(idCurso);
            return View(curso);
        }
        public IActionResult Reactivar(Guid idCurso)
        {
            _servicio.ReactivarAlta(idCurso);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid idCurso)
        {
            DarDeBajaCursoModel model = new DarDeBajaCursoModel
            {
                IdCurso = idCurso,
                FechaDeBaja = DateTime.Now
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(DarDeBajaCursoModel model)
        {
            _servicio.DarDeBaja(model.IdCurso, model.FechaDeBaja);
            return RedirectToAction("Index");
        }

        public IActionResult Matricular(Guid idCurso)
        {
            MatricularAlumnoCursoModel model = _servicio.ObtenerAlumnosParaMatricula(idCurso);
            return View(model);
        }

        [HttpPost]
        public IActionResult Matricular(MatricularAlumnoCursoModel model)
        {
            _servicioAlumnos.MatricularAlumno(model.IdAlumnoSeleccionado, model.IdCurso, model.FechaDeAlta);
            return RedirectToAction("Details", new
            {
                idCurso = model.IdCurso,
            });
        }

        public IActionResult DeleteMatricula(Guid idCurso, Guid idAlumno)
        {
            DeleteMatriculaModel model = _servicio.ObtenerDatosParaEliminarMatricula(idCurso, idAlumno);
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteMatricula(DeleteMatriculaModel model)
        {
            _servicio.EliminarMatricula(model.IdCursoPorAlumno, model.FechaDeBaja);
            return RedirectToAction("Details", new
            {
                idCurso = model.IdCurso
            });
        }
        public IActionResult ReactivarAltaMatricula(Guid idCursoPorAlumno, Guid idCurso)
        {
            _servicio.ReactivarAltaMatricula(idCursoPorAlumno);
            return RedirectToAction("Details", new
            {
                idCurso
            });
        }
        public IActionResult EditMatricula(Guid idCursoPorAlumno, Guid idCurso, Guid idAlumno)
        {
            var fechas = _servicio.ObtenerDetallesMatricula(idCursoPorAlumno);
            EditMatriculaModel model = new EditMatriculaModel
            {
                NombreAlumno = fechas.NombreAlumno,
                ApellidosAlumno = fechas.ApellidosAlumno,
                NombreCurso = fechas.NombreCurso,
                IdCursoPorAlumno=idCursoPorAlumno,
                IdCurso = idCurso,
                IdAlumno = idAlumno,
                FechaDeAlta = fechas.FechaDeAlta,
                FechaDeBaja = fechas.FechaDeBaja
            }; 
            return View(model);
        }
        [HttpPost]
        public IActionResult EditMatricula(EditMatriculaModel model)
        {
            _servicio.ModificarFechasMatricula(model.IdCursoPorAlumno, model.FechaDeAlta, model.FechaDeBaja);
            return RedirectToAction("Details", new
            {
                idCurso=model.IdCurso 
            });
        }

        /*public IActionResult CalcularPrecio(CalculadorPrecioModel model)
        {
            _servicio.ObtenerDatosParaCalcularPrecio(model.NombreCurso, model.IdCurso, model.FechaEntrada, model.NumeroSemanas, model.TipoDeHospedaje);
            return View(model);
        }*/
    }
}