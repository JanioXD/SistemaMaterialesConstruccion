using SistemaMaterialesConstruccion.Entidades;
using System.Collections.Generic;

namespace SistemaMaterialesConstruccion.Controlador
{
    public class TListaProveedores
    {
        public static List<Proveedor> _listaProveedores = new List<Proveedor>();

        public static bool Agregar(
            Proveedor objProveedor)
        {
            if (objProveedor == null)
            {
                return false;
            }

            if (!objProveedor.ValidarDatos())
            {
                return false;
            }

            if (Buscar(objProveedor.Codigo) != -1)
            {
                return false;
            }

            _listaProveedores.Add(objProveedor);

            return true;
        }

        public static int Buscar(string codigo)
        {
            for (int i = 0;
                 i < _listaProveedores.Count;
                 i++)
            {
                if (_listaProveedores[i].Codigo
                    == codigo)
                {
                    return i;
                }
            }

            return -1;
        }

        public static Proveedor Obtener(
            string codigo)
        {
            int posicion = Buscar(codigo);

            if (posicion == -1)
            {
                return null;
            }

            return _listaProveedores[posicion];
        }

        public static bool Modificar(string codigo, Proveedor nuevoProveedor)
        {
            int posicion = Buscar(codigo);
            if (posicion == -1) return false;
            if (nuevoProveedor.Codigo != codigo) return false;
            _listaProveedores[posicion] = nuevoProveedor;
            return true;
        }

        public static bool Eliminar(
            string codigo)
        {
            int posicion = Buscar(codigo);

            if (posicion == -1)
            {
                return false;
            }

            _listaProveedores.RemoveAt(posicion);

            return true;
        }
    }
}
