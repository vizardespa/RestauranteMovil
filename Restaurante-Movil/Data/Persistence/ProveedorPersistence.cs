using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Interfaces;

namespace Data.Persistence
{
    public class ProveedorPersistence : IPersistence<Proveedor>
    {
        /// Se utiliza el Store Procedure correspondiente.
        /// ya que se requiere insertar un registro en la tabla Entidad, antes de hacerlo en Empleado.
        public bool Create(Proveedor Entity)
        {
            bool response;

            try
            {
                response = ProgAvanzada_ArqSoftware_RestauranteEntities.Insert_Proveedor(Entity.Nombre, Entity.Telefono, Entity.Deuda) > 0 ? true : false;
            }
            catch (Exception e) { response = false; }

            return response;
        }

        public List<Proveedor> Read(short by, object value)
        {
            List<Proveedor> response = null;

            try
            {
                var BDD = new ProgAvanzada_ArqSoftware_RestauranteEntities();

                switch (by)
                {
                    case 0: // ID
                        {
                            var data = BDD.Proveedors;
                            int value_int = int.Parse(value.ToString());
                            response = data.Where(x => x.Id == value_int).ToList();
                            break;
                        }
                    case 1: // Nombre
                        {
                            var data = BDD.Proveedors;
                            string value_string = value.ToString();
                            response = data.Where(x => x.Nombre.Contains(value_string)).ToList();
                            break;
                        }
                    case 2: // Telefono
                        {
                            var data = BDD.Proveedors;
                            long value_long = long.Parse(value.ToString());
                            response = data.Where(x => x.Telefono == value_long).ToList();
                            break;
                        }
                    case 3: // Deuda
                        {
                            var data = BDD.Proveedors;
                            if ((bool)value)
                                response = data.Where(x => x.Deuda > 0).ToList();
                            else
                                response = data.Where(x => x.Deuda == 0).ToList();
                            break;
                        }
                }
            }
            catch (Exception e) { response = new List<Proveedor>(); }

            return response;
        }

        public bool Update(Proveedor Entity)
        {
            bool response;
            
            try
            {
                using (var BDD = new ProgAvanzada_ArqSoftware_RestauranteEntities())
                {
                    var tmp = new Proveedor { Id = Entity.Id };
                    BDD.Proveedors.Attach(tmp);
                    BDD.Proveedors.ApplyCurrentValues(Entity);
                    BDD.SaveChanges();
                    response = true; // Si el proceso tuvo éxito, se devuelve la Entidad con los valores nuevos.
                }
            }
            catch (Exception e) { response = false; } // Si ocurre un error, se devuelve núlo.

            return response;
        }

        /// LINQ
        /// Obtiene todas las entidades de tipo Proveedor.
        public List<Proveedor> GetList()
        {
            List<Proveedor> response = null;

            try
            {
                var BDD = new ProgAvanzada_ArqSoftware_RestauranteEntities();
                response = BDD.Proveedors.ToList();
            }
            catch (Exception e) { response = new List<Proveedor>(); }

            return response;
        }
    }

}
