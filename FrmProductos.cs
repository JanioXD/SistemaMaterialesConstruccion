using SistemaMaterialesConstruccion.Controlador;
using SistemaMaterialesConstruccion.Entidades;
using SistemaMaterialesConstruccion.Utilidades;
using System;
using System.Windows.Forms;

namespace SistemaMaterialesConstruccion.Formularios
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }
        private int _posicion = -1;
        private void InicializarFormulario()
        {
            cboEstado.Items.Clear();
            cboEstado.Items.Add("Activo");
            cboEstado.Items.Add("Inactivo");
            cboEstado.SelectedIndex = 0;
            txtCodigo.Enabled = false;
            GenerarCodigo();
        }
        private void GenerarCodigo()
        {
            txtCodigo.Text = GeneradorCodigos.GenerarProducto();
        }
        private void CargarCategorias()
        {
            cboCategoria.Items.Clear();
            foreach (Categoria item in TListaCategorias._listaCategorias)
            {
                cboCategoria.Items.Add(item.Nombre);
            }
            if (cboCategoria.Items.Count > 0)
            {
                cboCategoria.SelectedIndex = 0;
            }
        }
        private void Limpiar()
        {
            txtNombre.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtStockMin.Clear();
            cboEstado.SelectedIndex = 0;
            if (cboCategoria.Items.Count > 0)
            {
                cboCategoria.SelectedIndex = 0;
            }
            _posicion = -1;
            GenerarCodigo();
            txtNombre.Focus();
        }
        private bool ValidarDatos()
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre");
                txtNombre.Focus();
                return false;
            }
            if (txtMarca.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la marca");
                txtMarca.Focus();
                return false;
            }

            if (!Validaciones.EsNumero(txtPrecio.Text))
            {
                MessageBox.Show("Precio incorrecto");
                txtPrecio.Focus();
                return false;
            }

            if (!Validaciones.EsEntero(txtStock.Text))
            {
                MessageBox.Show("Stock incorrecto");
                txtStock.Focus();
                return false;
            }

            if (!Validaciones.EsEntero(txtStockMin.Text))
            {
                MessageBox.Show("Stock mínimo incorrecto");
                txtStockMin.Focus();
                return false;
            }
            return true;
        }
        private Categoria ObtenerCategoria()
        {
            foreach (Categoria item in TListaCategorias._listaCategorias)
            {
                if (item.Nombre == cboCategoria.Text)
                {
                    return item;
                }
            }
            return null;
        }
        private void MostrarProductos()
        {
            dgvProductos.Rows.Clear();

            foreach (Producto item
                     in TListaProductos._listaProductos)
            {
                dgvProductos.Rows.Add(item.Codigo, item.Nombre, item.Marca, item.ObjCategoria.Nombre, item.Precio, item.Stock, item.StockMinimo, item.Estado ? "Activo" : "Inactivo");
            }
        }
        private void GuardarProducto()
        {
            if (!ValidarDatos())
            {
                return;
            }
            Producto objProducto = new Producto(
                    txtCodigo.Text,
                    txtNombre.Text.Trim(),
                    txtMarca.Text.Trim(),
                    Convert.ToDouble(
                        txtPrecio.Text),
                    Convert.ToInt32(
                        txtStock.Text),
                    Convert.ToInt32(
                        txtStockMin.Text),
                    ObtenerCategoria(),
                    cboEstado.Text ==
                        "Activo");

            bool respuesta = TListaProductos.Agregar(objProducto);
            if (respuesta)
            {
                MessageBox.Show("Producto registrado");
                MostrarProductos();
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo registrar");
            }
        }
        private void ModificarProducto()
        {
            if (_posicion == -1)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }
            Producto objProducto =
                new Producto(
                    txtCodigo.Text,
                    txtNombre.Text.Trim(),
                    txtMarca.Text.Trim(),
                    Convert.ToDouble(
                        txtPrecio.Text),
                    Convert.ToInt32(
                        txtStock.Text),
                    Convert.ToInt32(
                        txtStockMin.Text),
                    ObtenerCategoria(),
                    cboEstado.Text ==
                        "Activo");

            bool respuesta = TListaProductos.Modificar(txtCodigo.Text, objProducto);
            if (respuesta)
            {
                MessageBox.Show("Producto modificado");
                MostrarProductos();
                Limpiar();
            }
        }
        private void EliminarProducto()
        {
            if (_posicion == -1)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }
            DialogResult respuesta = MessageBox.Show("¿Desea eliminar?", "Confirmación", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
            {
                TListaProductos.Eliminar(txtCodigo.Text);
                MostrarProductos();
                Limpiar();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarProducto();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarProducto();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarProducto();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            InicializarFormulario();
            CargarCategorias();
            MostrarProductos();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            _posicion = e.RowIndex;
            txtCodigo.Text = dgvProductos[0, e.RowIndex].Value.ToString();
            txtNombre.Text = dgvProductos[1, e.RowIndex].Value.ToString();
            txtMarca.Text = dgvProductos[2, e.RowIndex].Value.ToString();
            cboCategoria.Text = dgvProductos[3, e.RowIndex].Value.ToString();
            txtPrecio.Text = dgvProductos[4, e.RowIndex].Value.ToString();
            txtStock.Text = dgvProductos[5, e.RowIndex].Value.ToString();
            txtStockMin.Text = dgvProductos[6, e.RowIndex].Value.ToString();
            cboEstado.Text = dgvProductos[7, e.RowIndex].Value.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
