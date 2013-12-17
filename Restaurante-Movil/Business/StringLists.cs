using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class StringLists
    {
        public List<string> GetEmpleadoTypes()
        {
            List<string> catalog = new List<string>();

            for (int i = 1; i <= Empleado.AmountTipos; i++)
                catalog.Add(((Empleado.Tipo)i).ToString());

            return catalog;
        }

        public List<string> GetIngredientesTypes()
        {
            List<string> catalog = new List<string>();

            for (int i = 1; i <= Ingrediente.AmountTipos; i++)
                catalog.Add(((Ingrediente.TipoIngrediente)i).ToString());

            return catalog;
        }

    }
}
