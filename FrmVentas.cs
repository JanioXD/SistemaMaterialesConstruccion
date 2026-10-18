using SistemaMaterialesConstruccion.Controlador;
using SistemaMaterialesConstruccion.Entidades;
using SistemaMaterialesConstruccion.Utilidades;
using System;
using System.Windows.Forms;

namespace SistemaMaterialesConstruccion.Formularios
{
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
        }
        private Venta _ventaActual;
        private void InicializarFormulario()
        {
            _ventaActual = new Venta();
            txtFactura.Text = GeneradorCodigos.GenerarFactura();
            txtFactura.Enabled = false;
            txtUsuario.Text = Sesion.NombreUsuario();
            txtUsuario.Enabled = false;
            dtpFecha.Value = DateTime.Now;
            txtSubtotal.Text = "0.00";
            txtDescuento.Text = "0.00";
            txtIVA.Text = "0.00";
            txtTotal.Text = "0.00";
        }
        private void CargarClientes()
        {
            cboCliente.Items.Clear();

            foreach (Cliente item in TListaClientes._listaClientes)
            {
                cboCliente.Items.Add(item.Nombre);
            }
            if (cboCliente.Items.Count > 0)
            {
                cboCliente.SelectedIndex = 0;
            }
        }
        private void CargarProductos()
        {
            cboProducto.Items.Clear();
            foreach (Producto item in TListaProductos._listaProductos)
            {
                if (item.Estado) // Solo productos activos
                    cboProducto.Items.Add(item.Nombre);
            }
            if (cboProducto.Items.Count > 0) cboProducto.SelectedIndex = 0;
        }
        private Cliente ObtenerCliente()
        {
            foreach (Cliente item in TListaClientes._listaClientes)
            {
                if (item.Nombre == cboCliente.Text)
                {
                    return item;
                }
            }
            return null;
        }
        private Producto ObtenerProducto()
        {
            foreach (Producto item in TListaProductos._listaProductos)
            {
                if (item.Nombre == cboProducto.Text)
                {
                    return item;
                }
            }
            return null;
        }
        private void CalcularTotales()
        {
            _ventaActual.ObjCliente = ObtenerCliente();
            _ventaActual.CalcularTotales();
            txtSubtotal.Text = _ventaActual.Subtotal.ToString("0.00");
            txtDescuento.Text = _ventaActual.Descuento.ToString("0.00");
            txtIVA.Text = _ventaActual.IVA.ToString("0.00");
            txtTotal.Text = _ventaActual.Total.ToString("0.00");
        }
        private void AgregarProducto()
        {
            Producto producto = ObtenerProducto();
            if (producto == null)
            {
                return;
            }
            int cantidad;
            if (!int.TryParse(txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("Cantidad incorrecta");
                return;
            }
            if (!producto.HayStock(cantidad))
            {
                MessageBox.Show("Stock insuficiente");
                return;
            }
            DetalleVenta detalle = new DetalleVenta(producto, cantidad, 0);
            bool agregado = _ventaActual.AgregarDetalle(detalle);
            if (!agregado)
            {
                MessageBox.Show("Producto repetido");
                return;
            }

            dgvDetalleVenta.Rows.Add(
                producto.Codigo,
                producto.Nombre,
                detalle.Cantidad,
                detalle.PrecioUnitario,
                detalle.Descuento,
                detalle.Subtotal);
            CalcularTotales();
        }
        private void LimpiarFormulario()
        {
            _ventaActual = new Venta();
            dgvDetalleVenta.Rows.Clear();
            txtCantidad.Clear();
            txtSubtotal.Text = "0.00";
            txtDescuento.Text = "0.00";
            txtIVA.Text = "0.00";
            txtTotal.Text = "0.00";
            txtFactura.Text = GeneradorCodigos.GenerarFactura();
        }
        private void GuardarVenta()
        {
            _ventaActual.NumeroFactura = txtFactura.Text;
            _ventaActual.Fecha = dtpFecha.Value;
            _ventaActual.ObjCliente = ObtenerCliente();
            _ventaActual.ObjUsuario = Sesion.UsuarioActual;
            _ventaActual.EstadoVenta = "PENDIENTE";
            if (!_ventaActual.ValidarVenta())
            {
                MessageBox.Show("Venta inválida");
                return;
            }
            if (!TListaVentas.Agregar(_ventaActual))
            {
                MessageBox.Show("No se pudo registrar la venta");
                return;
            }
            MessageBox.Show("Venta registrada correctamente");
            GeneradorPDF.GenerarFacturaPDF(_ventaActual);
            LimpiarFormulario();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {

            InicializarFormulario();
            CargarClientes();
            CargarProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarVenta();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
