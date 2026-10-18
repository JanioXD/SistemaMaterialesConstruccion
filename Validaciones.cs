using System.Text.RegularExpressions;

namespace SistemaMaterialesConstruccion.Utilidades
{
    public class Validaciones
    {
        public static bool CampoVacio(string texto)
        {
            return string.IsNullOrWhiteSpace(texto);
        }

        public static bool EsNumero(string texto)
        {
            double numero;

            return double.TryParse(texto, out numero);
        }

        public static bool EsEntero(string texto)
        {
            int numero;

            return int.TryParse(texto, out numero);
        }

        public static bool EsCorreo(string correo)
        {
            string patron =
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(correo, patron);
        }

        public static bool LongitudCedula(
            string cedula)
        {
            return cedula.Length == 10;
        }

        public static bool LongitudRuc(
            string ruc)
        {
            return ruc.Length == 13;
        }

        public static bool PrecioValido(
            double precio)
        {
            return precio > 0;
        }

        public static bool StockValido(
            int stock)
        {
            return stock >= 0;
        }

        public static bool CantidadValida(
            int cantidad)
        {
            return cantidad > 0;
        }
    }
}
