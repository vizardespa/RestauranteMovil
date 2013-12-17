using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Persistence;

namespace Business
{
    public class Read
    {
        public bool ValidateReadEmpleadoInput(short by, object value)
        {
            bool valid = false;

            switch (by)
            {
                case 0: // ID
                    {
                        int x;
                        if (int.TryParse(value.ToString(), out x))
                            valid = true;
                        break;
                    }
                case 1: // Nombre
                    {
                        if (value is string)
                            valid = true;
                        break;
                    }
                case 2: // Apellido
                    {
                        if (value is string)
                            valid = true;
                        break;
                    }
                case 3: // Puesto
                    {
                        short x;
                        if (short.TryParse(value.ToString(), out x))
                            valid = true;
                        break;
                    }
                case 4:
                    {
                        decimal x;
                        if (decimal.TryParse(value.ToString(), out x))
                            valid = true;
                        break;
                    }
                case 5:
                    {
                        if (value is bool)
                            valid = true;
                        break;
                    }
            }

            return valid;
        }
        public List<Empleado> ReadEmpleados(short by, object value)
        {
            EmpleadoPersistence empleado_persistence = new EmpleadoPersistence();
            return empleado_persistence.Read(by, value);
        }
        public List<Empleado> GetAllEmpleados()
        {
            EmpleadoPersistence empleado_persistence = new EmpleadoPersistence();
            return empleado_persistence.GetList();
        }

        public bool ValidateReadIngredienteInput(short by, object value)
        {
            bool valid = false;

            switch (by)
            {
                case 0: // ID
                    {
                        int x;
                        if (int.TryParse(value.ToString(), out x))
                            valid = true;
                        break;
                    }
                case 1: // Nombre
                    {
                        if (value is string)
                            valid = true;
                        break;
                    }
                case 2: // Tipo
                    {
                        short x;
                        if (short.TryParse(value.ToString(), out x))
                            valid = true;
                        break;
                    }
                case 3: // Cantidad
                    {
                        decimal x;
                        if (decimal.TryParse(value.ToString(), out x))
                            valid = true;
                        break;
                    }
            }

            return valid;
        }
        public List<Ingrediente> ReadIngredientes(short by, object value)
        {
            IngredientePersistence ingrediente_persistence = new IngredientePersistence();
            return ingrediente_persistence.Read(by, value);
        }
        public List<Ingrediente> GetAllIngredientes()
        {
            IngredientePersistence ingrediente_persistence = new IngredientePersistence();
            return ingrediente_persistence.GetList();
        }

        public bool ValidateReadProveedor(short by, object value)
        {
            bool valid = false;

            switch (by)
            {
                case 0: // ID
                    {
                        int x;
                        if (int.TryParse(value.ToString(), out x))
                            valid = true;
                        break;
                    }
                case 1: // Nombre
                    {
                        if (value is string)
                            valid = true;
                        break;
                    }
                case 2: // Telefono
                    {
                        long x;
                        if (long.TryParse(value.ToString(), out x))
                            valid = true;
                        break;
                    }
                case 3: // Dedua
                    {
                        if (value is bool)
                            valid = true;
                        break;
                    }
            }

            return valid;
        }
        public List<Proveedor> ReadProveedores(short by, object value)
        {
            ProveedorPersistence proveedor_persistence = new ProveedorPersistence();
            return proveedor_persistence.Read(by, value);
        }
        public List<Proveedor> GetAllProveedores()
        {
            ProveedorPersistence proveedor_persistence = new ProveedorPersistence();
            return proveedor_persistence.GetList();
        }

    }

}
