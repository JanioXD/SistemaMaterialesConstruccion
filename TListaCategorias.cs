using SistemaMaterialesConstruccion.Entidades;
using System.Collections.Generic;

namespace SistemaMaterialesConstruccion.Controlador
{
    public class TListaCategorias
    {
        public static List<Categoria> _listaCategorias = new List<Categoria>();

        public static bool Agregar(Categoria objCategoria)
        {
            if (objCategoria == null)
            {
                return false;
            }

            if (!objCategoria.ValidarDatos())
            {
                return false;
            }

            if (Buscar(objCategoria.Codigo) != -1)
            {
                return false;
            }

            _listaCategorias.Add(objCategoria);

            return true;
        }

        public static int Buscar(string codigo)
        {
            for (int i = 0; i < _listaCategorias.Count; i++)
            {
                if (_listaCategorias[i].Codigo == codigo)
                {
                    return i;
                }
            }

            return -1;
        }

        public static Categoria Obtener(string codigo)
        {
            int posicion = Buscar(codigo);

            if (posicion == -1)
            {
                return null;
            }

            return _listaCategorias[posicion];
        }

        public static bool Modificar(string codigo, Categoria nuevaCategoria)
        {
            int posicion = Buscar(codigo);
            if (posicion == -1) return false;
            if (nuevaCategoria.Codigo != codigo) return false;
            _listaCategorias[posicion] = nuevaCategoria;
            return true;
        }

        public static bool Eliminar(string codigo)
        {
            int posicion = Buscar(codigo);

            if (posicion == -1)
            {
                return false;
            }

            _listaCategorias.RemoveAt(posicion);

            return true;
        }
    }
}
