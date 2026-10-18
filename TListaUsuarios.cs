using SistemaMaterialesConstruccion.Entidades;
using System.Collections.Generic;

namespace SistemaMaterialesConstruccion.Controlador
{
    public class TListaUsuarios
    {
        public static List<Usuario> _listaUsuarios = new List<Usuario>();

        public static bool Agregar(Usuario objUsuario)
        {
            if (objUsuario == null)
            {
                return false;
            }

            if (!objUsuario.ValidarDatos())
            {
                return false;
            }

            if (Buscar(objUsuario.Codigo) != -1)
            {
                return false;
            }

            _listaUsuarios.Add(objUsuario);

            return true;
        }

        public static int Buscar(string codigo)
        {
            for (int i = 0; i < _listaUsuarios.Count; i++)
            {
                if (_listaUsuarios[i].Codigo == codigo)
                {
                    return i;
                }
            }

            return -1;
        }

        public static Usuario Obtener(string codigo)
        {
            int posicion = Buscar(codigo);

            if (posicion == -1)
            {
                return null;
            }

            return _listaUsuarios[posicion];
        }

        public static bool Modificar(string codigo, Usuario nuevoUsuario)
        {
            int posicion = Buscar(codigo);
            if (posicion == -1) return false;
            if (nuevoUsuario.Codigo != codigo) return false;
            _listaUsuarios[posicion] = nuevoUsuario;
            return true;
        }

        public static bool Eliminar(string codigo)
        {
            int posicion = Buscar(codigo);

            if (posicion == -1)
            {
                return false;
            }

            _listaUsuarios.RemoveAt(posicion);

            return true;
        }

        public static Usuario Login(
            string usuario,
            string clave)
        {
            foreach (Usuario item in _listaUsuarios)
            {
                if (item.ValidarLogin(usuario, clave))
                {
                    return item;
                }
            }

            return null;
        }
    }
}
