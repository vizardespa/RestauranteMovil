using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Interfaces;

namespace Data.Persistence
{
    public class IngredientePersistence : IPersistence<Ingrediente>
    {
        /// Se utiliza el Store Procedure correspondiente.
        /// ya que se requiere insertar un registro en la tabla Entidad, antes de hacerlo en Empleado.
        public bool Create(Ingrediente Entity)
        {
            bool response;

            try
            {
                response = ProgAvanzada_ArqSoftware_RestauranteEntities.Insert_Ingrediente(Entity.Nombre, Entity.Tipo, Entity.Cantidad) > 0 ? true : false;
            }
            catch (Exception e) { response = false; }

            return response;
        }

        public List<Ingrediente> Read(short by, object value)
        {
            List<Ingrediente> response = null;

            try
            {
                var BDD = new ProgAvanzada_ArqSoftware_RestauranteEntities();

                switch (by)
                {
                    case 0: // ID
                        {
                            var data = BDD.Ingredientes;
                            int value_int = int.Parse(value.ToString());
                            response = data.Where(x => x.Id == value_int).ToList();
                            break;
                        }
                    case 1: // Nombre
                        {
                            var data = BDD.Ingredientes;
                            string value_string = value.ToString();
                            response = data.Where(x => x.Nombre.Contains(value_string)).ToList();
                            break;
                        }
                    case 2: // Tipo
                        {
                            var data = BDD.Ingredientes;
                            short value_short = (short)value;
                            response = data.Where(x => x.Tipo == value_short).ToList();
                            break;
                        }
                    case 3: // Cantidad.
                        {
                            var data = BDD.Ingredientes;
                            decimal value_decimal = decimal.Parse(value.ToString());
                            response = data.Where(x => x.Cantidad >= value_decimal).ToList();
                            break;
                        }
                }
            }
            catch (Exception e) { response = new List<Ingrediente>(); }

            return response;
        }

        public bool Update(Ingrediente Entity)
        {
            bool response;
            
            try
            {
                using (var BDD = new ProgAvanzada_ArqSoftware_RestauranteEntities())
                {
                    var tmp = new Ingrediente { Id = Entity.Id };
                    BDD.Ingredientes.Attach(tmp);
                    BDD.Ingredientes.ApplyCurrentValues(Entity);
                    BDD.SaveChanges();
                    response = true; // Si el proceso tuvo éxito, se devuelve la Entidad con los valores nuevos.
                }
            }
            catch (Exception e) { response = false; } // Si ocurre un error, se devuelve núlo.

            return response;
        }

        /// LINQ
        /// Obtiene todas las entidades de tipo Ingrediente.
        public List<Ingrediente> GetList()
        {
            List<Ingrediente> response = null;

            try
            {
                var BDD = new ProgAvanzada_ArqSoftware_RestauranteEntities();
                response = BDD.Ingredientes.ToList();
            }
            catch (Exception e) { response = new List<Ingrediente>(); }

            return response;
        }

    }
}
