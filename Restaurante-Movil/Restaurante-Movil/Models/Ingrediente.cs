using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante_Movil.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public short Tipo { get; set; }
        public decimal Cantidad { get; set; }
        public enum TipoIngrediente
        {
            ALCOHOL = 1,
            AVE,
            CARNE,
            CONDIMENTO,
            ESPECIA,
            FRUTA,
            GASEOSA,
            GRANO,
            JUGO,
            LACTEO,
            MARISCO,
            TUBERCULO,
            VERDURA
        }
        public static int AmountTipos { get { return 13; } }
        public string StringTipoIngrediente { get; set; }

    }

}