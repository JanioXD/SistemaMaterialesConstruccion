using SistemaMaterialesConstruccion.Entidades;

namespace SistemaMaterialesConstruccion.Utilidades
{
    public class Sesion
    {
        public static Usuario UsuarioActual;

        public static void IniciarSesion(
            Usuario objUsuario)
        {
            UsuarioActual = objUsuario;
        }

        public static void CerrarSesion()
        {
            UsuarioActual = null;
        }

        public static bool HaySesion()
        {
            return UsuarioActual != null;
        }

        public static string NombreUsuario()
        {
            if (UsuarioActual == null)
            {
                return "";
            }

            return UsuarioActual.Nombre;
        }

        public static string RolUsuario()
        {
            if (UsuarioActual == null)
            {
                return "";
            }

            return UsuarioActual.Rol;
        }
    }
}
