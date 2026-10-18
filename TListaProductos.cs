using SistemaMaterialesConstruccion.Entidades;
using System.Collections.Generic;

namespace SistemaMaterialesConstruccion.Controlador
{
    public class TListaProductos
    {
        public static List<Producto> _listaProductos = new List<Producto>();


        public static bool Agregar(Producto objProducto)
        {
            if (objProducto == null)
            {
                return false;
            }

            if (!objProducto.ValidarDatos())
            {
                return false;
            }

            if (Buscar(objProducto.Codigo) != -1)
            {
                return false;
            }

            _listaProductos.Add(objProducto);

            return true;
        }

        public static int Buscar(string codigo)
        {
            for (int i = 0; i < _listaProductos.Count; i++)
            {
                if (_listaProductos[i].Codigo == codigo)
                {
                    return i;
                }
            }

            return -1;
        }

        public static Producto Obtener(string codigo)
        {
            int posicion = Buscar(codigo);

            if (posicion == -1)
            {
                return null;
            }

            return _listaProductos[posicion];
        }

        public static bool Modificar(string codigo, Producto nuevoProducto)
        {
            int posicion = Buscar(codigo);
            if (posicion == -1) return false;
            if (nuevoProducto.Codigo != codigo) return false;
            _listaProductos[posicion] = nuevoProducto;
            return true;
        }

        public static bool Eliminar(string codigo)
        {
            int posicion = Buscar(codigo);

            if (posicion == -1)
            {
                return false;
            }

            _listaProductos.RemoveAt(posicion);

            return true;
        }

        public static bool HayStock(string codigo, int cantidad)
        {
            Producto objProducto = Obtener(codigo);

            if (objProducto == null)
            {
                return false;
            }

            return objProducto.HayStock(cantidad);
        }

        public static void AumentarStock(string codigo, int cantidad)
        {
            Producto objProducto = Obtener(codigo);

            if (objProducto != null)
            {
                objProducto.AumentarStock(cantidad);
            }
        }

        public static void DisminuirStock(string codigo, int cantidad)
        {
            Producto objProducto = Obtener(codigo);

            if (objProducto != null)
            {
                objProducto.DisminuirStock(cantidad);
            }
        }
    }
}
