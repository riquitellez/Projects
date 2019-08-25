using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallCenterBO.Data.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace CallCenterBO.Controllers
{
    public class ClasesController : Controller
    {

        private RepositorioClases _repositorio;

        public ClasesController(RepositorioClases reposotorio)
        {
            _repositorio = reposotorio;
        }
        public IActionResult Index()
        {
            var model = _repositorio.ObtenerClasesParaIndex();
            return View(model);
        }
    }
}