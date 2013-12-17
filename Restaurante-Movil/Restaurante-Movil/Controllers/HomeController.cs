using Restaurante_Movil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Business;

namespace Restaurante_Movil.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Ingrediente> list = GetIngredientes();
            ViewBag.table = ConvertToTable(list);
            // Opciones para hacer busquedas por Tipo de Ingrediente.
            List<SelectListItem> tipos_ingrediente = new List<SelectListItem>();
            SetTiposIngrediente(tipos_ingrediente);
            ViewBag.Tipos = tipos_ingrediente;

            return View();
        }
        [HttpPost]
        public ActionResult Index(Consulta model)
        {
            List<Ingrediente> list = SearchIngredientes(model);
            ViewBag.table = ConvertToTable(list);
            // Opciones para hacer busquedas por Tipo de Ingrediente.
            List<SelectListItem> tipos_ingrediente = new List<SelectListItem>();
            SetTiposIngrediente(tipos_ingrediente);
            ViewBag.Tipos = tipos_ingrediente;

            return View();
        }

        private System.Data.DataTable ConvertToTable(List<Ingrediente> list)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Cantidad");

            foreach (Ingrediente i in list)
            {
                dt.Rows.Add(new object[4]{
                    i.Id,
                    i.Nombre,
                    i.Tipo,
                    i.Cantidad});
            }

            return dt;
        }
        private List<Ingrediente> GetIngredientes()
        {
            List<Ingrediente> list = new List<Ingrediente>();

            var ingredientes = new Read().GetAllIngredientes();
            foreach (var i in ingredientes)
                list.Add(new Ingrediente
                {
                    Id = i.Id,
                    Nombre = i.Nombre,
                    Tipo = i.Tipo,
                    StringTipoIngrediente = i.StringTipoIngrediente,
                    Cantidad = i.Cantidad
                });
            
            return list;
        }
        private List<Ingrediente> SearchIngredientes(Consulta model)
        {
            List<Ingrediente> list = new List<Ingrediente>();
            
            object value;
            int x;
            if (model.by == 0 && int.TryParse(model.keyword, out x))
                value = x;
            else if (model.by == 2)
                value = model.type;
            else
                value = model.keyword as string;

            var ingredientes = new Read().ReadIngredientes((short)model.by, value);
            foreach (var i in ingredientes)
                list.Add(new Ingrediente
                {
                    Id = i.Id,
                    Nombre = i.Nombre,
                    Tipo = i.Tipo,
                    StringTipoIngrediente = i.StringTipoIngrediente,
                    Cantidad = i.Cantidad
                });
            
            return list;
        }
        private void SetTiposIngrediente(List<SelectListItem> list)
        {
            for (int i = 1; i <= Ingrediente.AmountTipos; i++)
            {
                list.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = ((Ingrediente.TipoIngrediente)i).ToString()
                });
            }
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
