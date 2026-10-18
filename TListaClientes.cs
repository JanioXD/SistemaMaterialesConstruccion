using SistemaMaterialesConstruccion.Entidades;
using System.Collections.Generic;

namespace SistemaMaterialesConstruccion.Controlador
{
    public class TListaClientes
    {
        public static List<Cliente> _listaClientes = new List<Cliente>();


        public static bool Agregar(Cliente objCliente)
        {
            if (objCliente == null)
            {
                return false;
            }

            if (!objCliente.ValidarDatos())
            {
                return false;
            }

            if (Buscar(objCliente.Identificacion)
                != -1)
            {
                return false;
            }

            _listaClientes.Add(objCliente);

            return true;
        }

        public static int Buscar(string identificacion)
        {
            for (int i = 0; i < _listaClientes.Count; i++)
            {
                if (_listaClientes[i].Identificacion == identificacion)
                {
                    return i;
                }
            }

            return -1;
        }

        public static Cliente Obtener(string identificacion)
        {
            int posicion = Buscar(identificacion);

            if (posicion == -1)
            {
                return null;
            }

            return _listaClientes[posicion];
        }

        public static bool Modificar(string identificacion, Cliente nuevoCliente)
        {
            int posicion = Buscar(identificacion);
            if (posicion == -1) return false;
            if (nuevoCliente.Identificacion != identificacion) return false;
            _listaClientes[posicion] = nuevoCliente;
            return true;
        }

        public static bool Eliminar(string identificacion)
        {
            int posicion = Buscar(identificacion);

            if (posicion == -1)
            {
                return false;
            }

            _listaClientes.RemoveAt(posicion);

            return true;
        }
    }
}

