using SistemaMaterialesConstruccion.Controlador;
using SistemaMaterialesConstruccion.Entidades;
using System;
using System.Windows.Forms;

namespace SistemaMaterialesConstruccion.Formularios
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void GenerarReporte()
        {
            switch (cboReporte.Text)
            {
                case "Productos":
                    ReporteProductos();
                    break;

                case "Clientes":
                    ReporteClientes();
                    break;

                case "Proveedores":
                    ReporteProveedores();
                    break;

                case "Usuarios":
                    ReporteUsuarios();
                    break;

                case "Compras":
                    ReporteCompras();
                    break;


                case "Ventas":
                    ReporteVentas();
                    break;

                case "Categorias":
                    ReporteCategorias();
                    break;

                case "Stock Bajo":
                    ReporteStockBajo();
                    break;

                case "Cliente Mayorista":
                    ReporteClienteMayorista();
                    break;

                case "Venta Mayor Valor":
                    ReporteVentaMayorValor();
                    break;

            }
        }
        private void ReporteCategorias()
        {
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();
            dgvReporte.Columns.Add("Codigo", "Código");
            dgvReporte.Columns.Add("Nombre", "Nombre");
            dgvReporte.Columns.Add("Descripcion", "Descripción");
            dgvReporte.Columns.Add("Estado", "Estado");
            foreach (Categoria item in TListaCategorias._listaCategorias)
            {
                dgvReporte.Rows.Add(
                    item.Codigo,
                    item.Nombre,
                    item.Descripcion,
                    item.Estado ? "Activa" : "Inactiva");
            }
            txtTotalRegistros.Text = dgvReporte.Rows.Count.ToString();
        }
        private void ReporteProductos()
        {
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();

            dgvReporte.Columns.Add(
                "Codigo",
                "Código");

            dgvReporte.Columns.Add(
                "Nombre",
                "Nombre");

            dgvReporte.Columns.Add(
                "Stock",
                "Stock");

            dgvReporte.Columns.Add(
                "Precio",
                "Precio");

            foreach (Producto item
                     in TListaProductos._listaProductos)
            {
                dgvReporte.Rows.Add(
                    item.Codigo,
                    item.Nombre,
                    item.Stock,
                    item.Precio);
            }

            txtTotalRegistros.Text =
                dgvReporte.Rows.Count.ToString();
        }
        private void ReporteClientes()
        {
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();

            dgvReporte.Columns.Add(
                "Cedula",
                "Cédula");

            dgvReporte.Columns.Add(
                "Nombre",
                "Nombre");

            dgvReporte.Columns.Add(
                "Tipo",
                "Tipo");

            foreach (Cliente item
                     in TListaClientes._listaClientes)
            {
                dgvReporte.Rows.Add(
                    item.Identificacion,
                    item.Nombre,
                    item.TipoCliente);
            }

            txtTotalRegistros.Text =
                dgvReporte.Rows.Count.ToString();
        }
        private void ReporteProveedores()
        {
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();

            dgvReporte.Columns.Add(
                "Codigo",
                "Código");

            dgvReporte.Columns.Add(
                "Empresa",
                "Empresa");

            dgvReporte.Columns.Add(
                "Saldo",
                "Saldo");

            foreach (Proveedor item
                     in TListaProveedores._listaProveedores)
            {
                dgvReporte.Rows.Add(
                    item.Codigo,
                    item.Empresa,
                    item.SaldoPendiente);
            }

            txtTotalRegistros.Text =
                dgvReporte.Rows.Count.ToString();
        }

        private void ReporteCompras()
        {
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();

            // Definir columnas más descriptivas
            dgvReporte.Columns.Add("Numero", "N° Compra");
            dgvReporte.Columns.Add("Fecha", "Fecha");
            dgvReporte.Columns.Add("Proveedor", "Proveedor");
            dgvReporte.Columns.Add("Usuario", "Usuario");
            dgvReporte.Columns.Add("CantProd", "Cant. Productos");
            dgvReporte.Columns.Add("Subtotal", "Subtotal");
            dgvReporte.Columns.Add("IVA", "IVA (15%)");
            dgvReporte.Columns.Add("Total", "Total");
            dgvReporte.Columns.Add("Estado", "Estado");

            // Formato de moneda para las columnas numéricas
            dgvReporte.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            dgvReporte.Columns["IVA"].DefaultCellStyle.Format = "C2";
            dgvReporte.Columns["Total"].DefaultCellStyle.Format = "C2";

            foreach (Compra item in TListaCompras._listaCompras)
            {
                dgvReporte.Rows.Add(
                    item.NumeroCompra,
                    item.Fecha.ToShortDateString(),
                    item.ObjProveedor?.Empresa ?? "N/A",
                    item.ObjUsuario?.Nombre ?? "N/A",
                    item.ListaDetalleCompra.Count,
                    item.Subtotal,
                    item.IVA,
                    item.Total,
                    item.Estado
                );
            }

            txtTotalRegistros.Text = dgvReporte.Rows.Count.ToString();
        }
        private void ReporteVentas()
        {
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();

            // Agregar columnas descriptivas
            dgvReporte.Columns.Add("Factura", "N° Factura");
            dgvReporte.Columns.Add("Fecha", "Fecha");
            dgvReporte.Columns.Add("Cliente", "Cliente");
            dgvReporte.Columns.Add("TipoCliente", "Tipo Cliente");
            dgvReporte.Columns.Add("Usuario", "Usuario");
            dgvReporte.Columns.Add("CantProd", "Cant. Productos");
            dgvReporte.Columns.Add("Subtotal", "Subtotal");
            dgvReporte.Columns.Add("Descuento", "Descuento");
            dgvReporte.Columns.Add("IVA", "IVA (15%)");
            dgvReporte.Columns.Add("Total", "Total");
            dgvReporte.Columns.Add("Estado", "Estado");

            // Formato de moneda para columnas numéricas
            dgvReporte.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            dgvReporte.Columns["Descuento"].DefaultCellStyle.Format = "C2";
            dgvReporte.Columns["IVA"].DefaultCellStyle.Format = "C2";
            dgvReporte.Columns["Total"].DefaultCellStyle.Format = "C2";

            // Recorrer todas las ventas
            foreach (Venta item in TListaVentas._listaVentas)
            {
                dgvReporte.Rows.Add(
                    item.NumeroFactura,
                    item.Fecha.ToShortDateString(),
                    item.ObjCliente?.Nombre ?? "N/A",
                    item.ObjCliente?.TipoCliente ?? "N/A",
                    item.ObjUsuario?.Nombre ?? "N/A",
                    item.ListaDetalleVenta.Count,
                    item.Subtotal,
                    item.Descuento,
                    item.IVA,
                    item.Total,
                    item.EstadoVenta
                );
            }

            txtTotalRegistros.Text = dgvReporte.Rows.Count.ToString();
        }
        private void ReporteStockBajo()
        {
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();
            dgvReporte.Columns.Add("Codigo", "Código");
            dgvReporte.Columns.Add("Nombre", "Producto");
            dgvReporte.Columns.Add("Stock", "Stock");
            dgvReporte.Columns.Add("Minimo", "Stock Mínimo");
            foreach (Producto item in TListaProductos._listaProductos)
            {
                if (item.StockBajo())
                {
                    dgvReporte.Rows.Add(
                        item.Codigo,
                        item.Nombre,
                        item.Stock,
                        item.StockMinimo);
                }
            }

            txtTotalRegistros.Text = dgvReporte.Rows.Count.ToString();
        }
        private void ReporteClienteMayorista()
        {
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();

            dgvReporte.Columns.Add(
                "Cedula",
                "Cédula");

            dgvReporte.Columns.Add(
                "Nombre",
                "Nombre");

            foreach (Cliente item
                     in TListaClientes._listaClientes)
            {
                if (item.TipoCliente ==
                    "Mayorista")
                {
                    dgvReporte.Rows.Add(
                        item.Identificacion,
                        item.Nombre);
                }
            }

            txtTotalRegistros.Text =
                dgvReporte.Rows.Count.ToString();
        }

        private void ReporteVentaMayorValor()
        {
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();

            dgvReporte.Columns.Add(
                "Factura",
                "Factura");

            dgvReporte.Columns.Add(
                "Cliente",
                "Cliente");

            dgvReporte.Columns.Add(
                "Total",
                "Total");

            Venta mayor = null;

            foreach (Venta item
                     in TListaVentas._listaVentas)
            {
                if (mayor == null)
                {
                    mayor = item;
                }
                else if (item.Total > mayor.Total)
                {
                    mayor = item;
                }
            }

            if (mayor != null)
            {
                dgvReporte.Rows.Add(
                    mayor.NumeroFactura,
                    mayor.ObjCliente.Nombre,
                    mayor.Total);
            }

            txtTotalRegistros.Text =
                dgvReporte.Rows.Count.ToString();
        }
        private void ReporteUsuarios()
        {
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();
            dgvReporte.Columns.Add("Codigo", "Código");
            dgvReporte.Columns.Add("Nombre", "Nombre");
            dgvReporte.Columns.Add("Usuario", "Usuario");
            dgvReporte.Columns.Add("Rol", "Rol");
            dgvReporte.Columns.Add("Estado", "Estado");
            foreach (Usuario item in TListaUsuarios._listaUsuarios)
            {
                dgvReporte.Rows.Add(
                    item.Codigo,
                    item.Nombre,
                    item.NombreUsuario,
                    item.Rol,
                    item.Estado ? "Activo" : "Inactivo");
            }

            txtTotalRegistros.Text = dgvReporte.Rows.Count.ToString();
        }
        private void FrmReportes_Load(object sender, EventArgs e)
        {
            cboReporte.Items.Clear();
            cboReporte.Items.Add("Productos");
            cboReporte.Items.Add("Clientes");
            cboReporte.Items.Add("Proveedores");
            cboReporte.Items.Add("Usuarios");
            cboReporte.Items.Add("Compras");
            cboReporte.Items.Add("Ventas");
            cboReporte.Items.Add("Stock Bajo");
            cboReporte.Items.Add("Cliente Mayorista");
            cboReporte.Items.Add("Venta Mayor Valor");
            cboReporte.Items.Add("Categorias");
            cboReporte.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void cboReporte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
