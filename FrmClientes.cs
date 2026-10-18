using SistemaMaterialesConstruccion.Controlador;
using SistemaMaterialesConstruccion.Entidades;
using SistemaMaterialesConstruccion.Utilidades;
using System;
using System.Windows.Forms;

namespace SistemaMaterialesConstruccion.Formularios
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }
        private int _posicion = -1;
        private void Limpiar()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
            txtCupo.Clear();
            txtDeuda.Text = "0";
            cboCliente.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
            _posicion = -1;
            txtCedula.Focus();
        }
        private void InicializarFormulario()
        {
            cboCliente.Items.Clear();

            cboCliente.Items.Add("Frecuente");
            cboCliente.Items.Add("Mayorista");
            cboCliente.Items.Add("Minorista");
            cboCliente.SelectedIndex = 0;
            cboEstado.Items.Clear();
            cboEstado.Items.Add("Activo");
            cboEstado.Items.Add("Inactivo");
            cboEstado.SelectedIndex = 0;
            txtDeuda.Text = "0";
        }
        private bool ValidarDatos()
        {
            if (txtCedula.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la cédula");
                txtCedula.Focus();
                return false;
            }
            if (!Validaciones.LongitudCedula(txtCedula.Text))
            {
                MessageBox.Show("La cédula debe tener 10 dígitos");
                txtCedula.Focus();
                return false;
            }

            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre");
                txtNombre.Focus();
                return false;
            }

            if (txtTelefono.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el teléfono");
                txtTelefono.Focus();
                return false;
            }
            if (!Validaciones.EsCorreo(txtCorreo.Text))
            {
                MessageBox.Show("Correo incorrecto");
                txtCorreo.Focus();
                return false;
            }
            if (!Validaciones.EsNumero(txtCupo.Text))
            {
                MessageBox.Show("Crédito incorrecto");
                txtCupo.Focus();
                return false;
            }
            return true;
        }
        private void MostrarClientes()
        {
            dgvClientes.Rows.Clear();

            foreach (Cliente item
                     in TListaClientes._listaClientes)
            {
                dgvClientes.Rows.Add(
                    item.Identificacion,
                    item.Nombre,
                    item.Telefono,
                    item.Direccion,
                    item.Correo,
                    item.TipoCliente,
                    item.LimiteCredito,
                    item.SaldoPendiente,
                    item.Estado
                        ? "Activo"
                        : "Inactivo");
            }
        }
        private void GuardarCliente()
        {
            if (!ValidarDatos())
            {
                return;
            }

            Cliente objCliente =
                new Cliente(
                    txtCedula.Text.Trim(),
                    txtNombre.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    cboEstado.Text == "Activo",
                    txtCorreo.Text.Trim(),
                    cboCliente.Text,
                    Convert.ToDouble(
                        txtCupo.Text),
                    Convert.ToDouble(
                        txtDeuda.Text));
            bool respuesta = TListaClientes.Agregar(objCliente);
            if (respuesta)
            {
                MessageBox.Show("Cliente registrado");
                MostrarClientes();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Cliente ya existe");
            }
        }
        private void ModificarCliente()
        {
            if (_posicion == -1)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            Cliente objCliente =
                new Cliente(
                    txtCedula.Text.Trim(),
                    txtNombre.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    cboEstado.Text == "Activo",
                    txtCorreo.Text.Trim(),
                    cboCliente.Text,
                    Convert.ToDouble(
                        txtCupo.Text),
                    Convert.ToDouble(
                        txtDeuda.Text));

            bool respuesta = TListaClientes.Modificar(txtCedula.Text, objCliente);
            if (respuesta)
            {
                MessageBox.Show("Cliente modificado");
                MostrarClientes();
                Limpiar();
            }
        }
        private void EliminarCliente()
        {
            if (_posicion == -1)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Desea eliminar el cliente?", "Confirmación", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
            {
                TListaClientes.Eliminar(txtCedula.Text);
                MostrarClientes();
                Limpiar();
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarCliente();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            InicializarFormulario();
            MostrarClientes();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            _posicion = e.RowIndex;
            txtCedula.Text = dgvClientes[0, e.RowIndex].Value.ToString();
            txtNombre.Text = dgvClientes[1, e.RowIndex].Value.ToString();
            txtTelefono.Text = dgvClientes[2, e.RowIndex].Value.ToString();
            txtDireccion.Text = dgvClientes[3, e.RowIndex].Value.ToString();
            txtCorreo.Text = dgvClientes[4, e.RowIndex].Value.ToString();
            cboCliente.Text = dgvClientes[5, e.RowIndex].Value.ToString();
            txtCupo.Text = dgvClientes[6, e.RowIndex].Value.ToString();
            txtDeuda.Text = dgvClientes[7, e.RowIndex].Value.ToString();
            cboEstado.Text = dgvClientes[8, e.RowIndex].Value.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCliente();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarCliente();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
