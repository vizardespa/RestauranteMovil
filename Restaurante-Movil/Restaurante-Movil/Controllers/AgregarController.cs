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
            /*ServiciosReference.ServiciosClient client = new ServiciosReference.ServiciosClient();
            bool valid_inputs = false, success = false;
            string nombre = model.Nombre;
            short tipo = (short)(model.Tipo + 1);
            decimal cantidad = model.Cantidad;
            if (valid_inputs = client.ValidarNuevoIngredienteAsync(nombre, tipo, cantidad).Result)
                success = client.AgregarIngredienteAsync(nombre, tipo, cantidad).Result;*/
            return View();
        }
    }
}
