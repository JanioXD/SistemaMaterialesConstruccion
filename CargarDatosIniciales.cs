using SistemaMaterialesConstruccion.Controlador;
using SistemaMaterialesConstruccion.Entidades;

namespace SistemaMaterialesConstruccion.Utilidades
{
    public class CargarDatosIniciales
    {
        public static void CargarTodo()
        {
            CargarUsuarios();
            CargarCategorias();
            CargarProductos();
            CargarClientes();
            CargarProveedores();
        }

        private static void CargarUsuarios()
        {
            Usuario objUsuario = new Usuario("0912345678", "Administrador General", "0999999999", "Guayaquil", true, "USR0001", "admin", "123", "Administrador", 0);
            TListaUsuarios.Agregar(objUsuario);
        }
        private static void CargarCategorias()
        {
            Categoria cat1 = new Categoria("CAT0001", "Cemento", "Materiales de cemento", true);
            Categoria cat2 = new Categoria("CAT0002", "Pintura", "Pinturas y esmaltes", true);
            Categoria cat3 = new Categoria("CAT0003", "Herramientas", "Herramientas manuales", true);
            TListaCategorias.Agregar(cat1);
            TListaCategorias.Agregar(cat2);
            TListaCategorias.Agregar(cat3);
        }
        private static void CargarProductos()
        {
            Producto prod1 = new Producto("PROD0001", "Cemento Holcim", "Holcim", 9.50, 100, 10, TListaCategorias.Obtener("CAT0001"), true);
            Producto prod2 = new Producto("PROD0002", "Pintura Blanca", "Unidas", 18.75, 50, 5, TListaCategorias.Obtener("CAT0002"), true);
            Producto prod3 = new Producto("PROD0003", "Martillo", "Truper", 12.50, 30, 5, TListaCategorias.Obtener("CAT0003"), true);
            TListaProductos.Agregar(prod1);
            TListaProductos.Agregar(prod2);
            TListaProductos.Agregar(prod3);
        }

        private static void CargarClientes()
        {
            Cliente cli1 = new Cliente("0955555555", "Juan Perez", "0981111111", "Guayaquil", true, "juan@gmail.com", "Frecuente", 1000, 0);
            Cliente cli2 = new Cliente("0966666666", "Maria Lopez", "0982222222", "Duran", true, "maria@gmail.com", "Mayorista", 2000, 0);
            TListaClientes.Agregar(cli1);
            TListaClientes.Agregar(cli2);
        }
        private static void CargarProveedores()
        {
            Proveedor prov1 = new Proveedor("0999999999", "Carlos Torres", "0983333333", "Guayaquil", true, "PROV0001", "Holcim Ecuador", "ventas@holcim.com", "0999999999001", "Carlos Torres", 0);
            Proveedor prov2 = new Proveedor("0888888888", "Luis Vera", "0984444444", "Quito", true, "PROV0002", "Pinturas Unidas", "info@unidas.com", "0888888888001", "Luis Vera", 0);
            TListaProveedores.Agregar(prov1);
            TListaProveedores.Agregar(prov2);
        }
    }
}
