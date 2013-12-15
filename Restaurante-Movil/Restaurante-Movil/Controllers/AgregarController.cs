using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurante_Movil.Models;

namespace Restaurante_Movil.Controllers
{
    public class AgregarController : Controller
    {
        //
        // GET: /Agregar/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Ingrediente model)
        {
            // enviar model a Services
            return View();
        }
    }
}
