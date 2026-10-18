namespace SistemaMaterialesConstruccion.Utilidades
{
    public class GeneradorCodigos
    {
        private static int _codigoProducto = 4;
        private static int _codigoCategoria = 4;
        private static int _codigoProveedor = 3;
        private static int _codigoUsuario = 2;
        private static int _codigoCompra = 1;
        private static int _codigoFactura = 1;

        public static string GenerarProducto()
        {
            string codigo =
                "PROD" +
                _codigoProducto.ToString("0000");

            _codigoProducto++;

            return codigo;
        }

        public static string GenerarCategoria()
        {
            string codigo =
                "CAT" +
                _codigoCategoria.ToString("0000");

            _codigoCategoria++;

            return codigo;
        }

        public static string GenerarProveedor()
        {
            string codigo =
                "PROV" +
                _codigoProveedor.ToString("0000");

            _codigoProveedor++;

            return codigo;
        }

        public static string GenerarUsuario()
        {
            string codigo =
                "USR" +
                _codigoUsuario.ToString("0000");

            _codigoUsuario++;

            return codigo;
        }

        public static string GenerarCompra()
        {
            string codigo =
                "COM" +
                _codigoCompra.ToString("0000");

            _codigoCompra++;

            return codigo;
        }

        public static string GenerarFactura()
        {
            string codigo =
                "FAC" +
                _codigoFactura.ToString("0000");

            _codigoFactura++;

            return codigo;
        }
    }
}
