using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Persistence;

namespace Business
{
    public class Create
    {
        private EmpleadoPersistence empleado_persistence;
        private IngredientePersistence ingrediente_persistence;
        private ProveedorPersistence proveedor_persistence;

        public Create()
        {
            this.empleado_persistence = new EmpleadoPersistence();
            this.ingrediente_persistence = new IngredientePersistence();
            this.proveedor_persistence = new ProveedorPersistence();
        }

        public bool CreateEmpleado(string nombre, string apellido, short puesto, decimal sueldo, DateTime contratacion, bool activo)
        {
            Empleado newEmpleado = new Empleado
            {
                Nombre = nombre,
                Apellido = apellido,
                Puesto = puesto,
                Sueldo = sueldo,
                Contratacion = contratacion,
                Activo = activo
            };
            return this.empleado_persistence.Create(newEmpleado);
        }
        public bool ValidateNewEmpleado(string nombre, string apellido, short puesto, decimal sueldo, DateTime contratacion, bool activo)
        {
            Empleado e=new Empleado
            {
                Nombre = nombre,
                Apellido = apellido,
                Puesto = puesto,
                Sueldo = sueldo,
                Contratacion = contratacion,
                Activo = activo
            };

            bool valid = !string.IsNullOrEmpty(e.Nombre) ? true : false;
            bool tmp = !string.IsNullOrEmpty(e.Apellido) ? true : false;
            valid = valid && tmp;
            tmp = e.Puesto > 0 ? true : false;
            valid = valid && tmp;
            tmp = e.Sueldo > 0 ? true : false;
            valid = valid && tmp;
            tmp = e.Contratacion != null ? true : false;
            valid = valid && tmp;
            tmp = e.Activo != null ? true : false;
            valid = valid && tmp;

            return valid;
        }

        public bool CreateIngrediente(string nombre, short tipo, decimal cantidad)
        {
            Ingrediente newIngrediente = new Ingrediente
            {
                Nombre = nombre,
                Tipo = tipo,
                Cantidad = cantidad
            };

            return ingrediente_persistence.Create(newIngrediente);
        }
        public bool ValidateNewIngrediente(string nombre,short tipo,decimal cantidad)
        {
            Ingrediente i=new Ingrediente
            {
                Nombre = nombre,
                Tipo = tipo,
                Cantidad = cantidad
            };

            bool valid = !string.IsNullOrEmpty(i.Nombre) ? true : false;
            bool tmp = i.Tipo > 0 ? true : false;
            valid = valid && tmp;
            tmp = i.Cantidad > 0 ? true : false;
            valid = valid && tmp;

            return valid;
        }

        public bool CreateProveedor(string nombre, long telefono, decimal deuda)
        {
            Proveedor newProveedor = new Proveedor
            {
                Nombre = nombre,
                Telefono = telefono,
                Deuda = deuda
            };

            return proveedor_persistence.Create(newProveedor);
        }
        public bool ValidateNewProveedor(string nombre,long telefono,decimal deuda)
        {
            Proveedor p = new Proveedor
            {
                Nombre = nombre,
                Telefono = telefono,
                Deuda = deuda
            };

            bool valid = !string.IsNullOrEmpty(p.Nombre) ? true : false;
            bool tmp = p.Telefono > 0 ? true : false;
            valid = valid && tmp;

            // No se toma en cuenta la deuda, ya puede ser cero.

            return valid;
        }

    }

}
