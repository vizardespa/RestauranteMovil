using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Interfaces;

namespace Data
{

    public class EmpleadoPersistence : IPersistence<Empleado>
    {
        /// Se utiliza el Store Procedure correspondiente.
        /// ya que se requiere insertar un registro en la tabla Entidad, antes de hacerlo en Empleado.
        public bool Create(Empleado Entity)
        {
            bool response;

            try
            {
                response = ProgAvanzada_ArqSoftware_RestauranteEntities.Insert_Empleado(Entity.Nombre, Entity.Apellido, Entity.Puesto, Entity.Sueldo, Entity.Contratacion, Entity.Activo) > 0 ? true : false;
            }
            catch (Exception e) { response = false; }

            return response;
        }

        // Realiza un SELECT de un Empleado en particular en base al Id.
        public List<Empleado> Read(short by, object value)
        {
            List<Empleado> response = null;

            try
            {
                var BDD = new ProgAvanzada_ArqSoftware_RestauranteEntities();

                switch (by)
                {
                    case 0: // ID
                        {
                            var data = BDD.Empleadoes;
                            int int_value = int.Parse(value.ToString());
                            response = data.Where(x => x.Id == int_value).ToList();
                            break;
                        }
                    case 1: // Nombre
                        {
                            var data = BDD.Empleadoes;
                            string value_string = value.ToString();
                            response = data.Where(x => x.Nombre.Contains(value_string)).ToList();
                            break;
                        }
                    case 2: // Apellido
                        {
                            var data = BDD.Empleadoes;
                            string value_string = value.ToString();
                            response = data.Where(x => x.Apellido.Contains(value_string)).ToList();
                            break;
                        }
                    case 3: // Puesto.
                        {
                            var data = BDD.Empleadoes;
                            short value_short = (short)value;
                            response = data.Where(x => x.Puesto == value_short).ToList();
                            break;
                        }
                    case 4: // Sueldo.
                        {
                            var data = BDD.Empleadoes;
                            decimal value_decimal = (decimal)value;
                            response = data.Where(x => x.Sueldo >= value_decimal).ToList();
                            break;
                        }
                    case 5: // Activo
                        {
                            var data = BDD.Empleadoes;
                            bool value_bool = (bool)value;
                            response = data.Where(x => x.Activo == value_bool).ToList();
                            break;
                        }
                }
            }
            catch (Exception e) { response = new List<Empleado>(); }

            return response;
        }

        // Se actualiza la Entidad recibida como parámetro, y se devuelve el mismo si la operación tiene éxito.
        public bool Update(Empleado Entity)
        {
            bool response;
            
            try
            {
                using (var BDD = new ProgAvanzada_ArqSoftware_RestauranteEntities())
                {
                    var tmp = new Empleado { Id = Entity.Id };
                    BDD.Empleadoes.Attach(tmp);
                    BDD.Empleadoes.ApplyCurrentValues(Entity);
                    BDD.SaveChanges();
                    response = true; // Si el proceso tuvo éxito, se devuelve la Entidad con los valores nuevos.
                }
            }
            catch (Exception e) { response = false; } // Si ocurre un error, se devuelve núlo.

            return response;
        }

        /// LINQ
        /// Realiza un SELECT de todos los datoas de la tabla Empleado.
        public List<Empleado> GetList()
        {
            List<Empleado> response;
            
            try
            {
                var BDD = new ProgAvanzada_ArqSoftware_RestauranteEntities();
                var data = BDD.Empleadoes;
                
                response = data.ToList();
            }
            catch(Exception e) { response = new List<Empleado>(); }

            return response;
        }

    }
}
