using SistemaMaterialesConstruccion.Controlador;
using SistemaMaterialesConstruccion.Entidades;
using SistemaMaterialesConstruccion.Utilidades;
using System;
using System.Windows.Forms;

namespace SistemaMaterialesConstruccion.Formularios
{
    public partial class FrmCompras : Form
    {
        public FrmCompras()
        {
            InitializeComponent();
        }
        private int _posicion = -1;
        private Compra _compraActual;

        private void InicializarFormulario()
        {
            _compraActual = new Compra();
            txtNumero.Text = GeneradorCodigos.GenerarCompra();
            txtNumero.Enabled = false;
            txtUsuario.Text = Sesion.NombreUsuario();
            txtUsuario.Enabled = false;
            dtpFecha.Value = DateTime.Now;
            txtSubtotal.Text = "0.00";
            txtIVA.Text = "0.00";
            txtTotal.Text = "0.00";
        }
        private void CargarProveedores()
        {
            cboProveedor.Items.Clear();
            foreach (Proveedor item in TListaProveedores._listaProveedores)
            {
                cboProveedor.Items.Add(item.Empresa);
            }
            if (cboProveedor.Items.Count > 0)
            {
                cboProveedor.SelectedIndex = 0;
            }
        }
        private void CargarProductos()
        {
            cboProducto.Items.Clear();
            foreach (Producto item in TListaProductos._listaProductos)
            {
                cboProducto.Items.Add(item.Nombre);
            }
            if (cboProducto.Items.Count > 0)
            {
                cboProducto.SelectedIndex = 0;
            }
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
        private Proveedor ObtenerProveedor()
        {
            foreach (Proveedor item in TListaProveedores._listaProveedores)
            {
                if (item.Empresa == cboProveedor.Text)
                {
                    return item;
                }
            }

            return null;
        }
        private void CalcularTotales()
        {
            _compraActual.CalcularTotales();
            txtSubtotal.Text = _compraActual.Subtotal.ToString("0.00");
            txtIVA.Text = _compraActual.IVA.ToString("0.00");
            txtTotal.Text = _compraActual.Total.ToString("0.00");
        }
        private void AgregarProducto()
        {
            Producto producto = ObtenerProducto();
            if (producto == null)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }
            int cantidad;
            if (!int.TryParse(txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("Cantidad incorrecta");
                return;
            }
            if (cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida");
                return;
            }
            DetalleVenta detalle = new DetalleVenta(producto, cantidad, 0);
            _compraActual.AgregarDetalle(detalle);
            dgvDetalleCompra.Rows.Add(producto.Codigo, producto.Nombre, detalle.Cantidad, detalle.PrecioUnitario, detalle.Subtotal);
            CalcularTotales();
            txtCantidad.Clear();
        }

        private void LimpiarFormulario()
        {
            _compraActual = new Compra();
            dgvDetalleCompra.Rows.Clear();
            txtCantidad.Clear();
            txtSubtotal.Text = "0.00";
            txtIVA.Text = "0.00";
            txtTotal.Text = "0.00";
            txtNumero.Text = GeneradorCodigos.GenerarCompra();
        }

        private void GuardarCompra()
        {
            _compraActual.NumeroCompra = txtNumero.Text;
            _compraActual.Fecha = dtpFecha.Value;
            _compraActual.ObjProveedor = ObtenerProveedor();  // Toma el proveedor actual del combo
            _compraActual.ObjUsuario = Sesion.UsuarioActual;
            _compraActual.Estado = "PENDIENTE";
            if (!_compraActual.ValidarCompra())
            {
                MessageBox.Show("Compra inválida: Verifique proveedor y detalles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!TListaCompras.Agregar(_compraActual))
            {
                MessageBox.Show("No se pudo registrar la compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Compra registrada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
        }
        private void FrmCompras_Load(object sender, EventArgs e)
        {

            InicializarFormulario();
            CargarProveedores();
            CargarProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCompra();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_compraActual != null)
                _compraActual.ObjProveedor = ObtenerProveedor();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
