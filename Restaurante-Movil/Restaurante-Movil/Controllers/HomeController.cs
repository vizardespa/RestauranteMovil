using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Restaurante_Movil.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modifique esta plantilla para poner en marcha su aplicación ASP.NET MVC.";
            List<Models.Ingrediente> list = GetIngredientes();
            ViewBag.table = ConvertToTable(list);

            return View();
        }
        private System.Data.DataTable ConvertToTable(List<Models.Ingrediente> list)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Cantidad");
            
            foreach (Models.Ingrediente i in list)
            {
                dt.Rows.Add(new object[4]{
                    i.Id,
                    i.Nombre,
                    i.Tipo,
                    i.Cantidad});
            }

            return dt;
        }
        public List<Models.Ingrediente> GetIngredientes()
        {
            List<Models.Ingrediente> list = new List<Models.Ingrediente>();
            list.Add(new Models.Ingrediente { Id = 30, Nombre = "juguito", Tipo = 4, Cantidad = (decimal)320.25 });
            return list;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Página de descripción de la aplicación.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contacto.";

            return View();
        }
    }
}
