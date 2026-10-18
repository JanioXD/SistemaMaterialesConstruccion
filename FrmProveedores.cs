using SistemaMaterialesConstruccion.Controlador;
using SistemaMaterialesConstruccion.Entidades;
using SistemaMaterialesConstruccion.Utilidades;
using System;
using System.Windows.Forms;

namespace SistemaMaterialesConstruccion.Formularios
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
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
            txtSaldo.Text = "0";
            GenerarCodigo();
        }
        private void Limpiar()
        {
            txtEmpresa.Clear();
            txtRuc.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
            txtSaldo.Text = "0";
            cboEstado.SelectedIndex = 0;
            _posicion = -1;
            GenerarCodigo();
            txtEmpresa.Focus();
        }
        private bool ValidarDatos()
        {
            if (txtEmpresa.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la empresa");
                return false;
            }
            if (txtRuc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el RUC");
                return false;
            }
            if (!Validaciones.LongitudRuc(txtRuc.Text))
            {
                MessageBox.Show("RUC incorrecto");
                return false;
            }
            if (!Validaciones.EsCorreo(txtCorreo.Text))
            {
                MessageBox.Show("Correo incorrecto");
                return false;
            }
            return true;
        }
        private void MostrarProveedores()
        {
            dgvProveedores.Rows.Clear();
            foreach (Proveedor item in TListaProveedores._listaProveedores)
            {
                dgvProveedores.Rows.Add(
                    item.Codigo,
                    item.Empresa,
                    item.Ruc,
                    item.Contacto,
                    item.Telefono,
                    item.Direccion,
                    item.Correo,
                    item.SaldoPendiente,
                    item.Estado
                        ? "Activo"
                        : "Inactivo");
            }
        }
        private void GenerarCodigo()
        {
            txtCodigo.Text = GeneradorCodigos.GenerarProveedor();
        }
        private void GuardarProveedor()
        {
            if (!ValidarDatos())
            {
                return;
            }

            Proveedor objProveedor = new Proveedor(
            txtRuc.Text,          // Identificación
            txtContacto.Text,     // Nombre (persona de contacto)
            txtTelefono.Text,     // Teléfono
            txtDireccion.Text,    // Dirección
            cboEstado.Text == "Activo",
            txtCodigo.Text,       // Código interno
            txtEmpresa.Text,      // Empresa
            txtCorreo.Text,       // Correo
            txtRuc.Text,          // RUC
            txtContacto.Text,     // Contacto (se repite, pero es intencional según constructor)
            Convert.ToDouble(txtSaldo.Text)
);
            bool respuesta = TListaProveedores.Agregar(objProveedor);
            if (respuesta)
            {
                MessageBox.Show("Proveedor registrado");
                MostrarProveedores();
                Limpiar();
            }
        }
        private void ModificarProveedor()
        {
            if (_posicion == -1)
            {
                MessageBox.Show("Seleccione un proveedor");
                return;
            }
            Proveedor objProveedor =
                new Proveedor(
                    txtRuc.Text,
                    txtContacto.Text,
                    txtTelefono.Text,
                    txtDireccion.Text,
                    cboEstado.Text == "Activo",
                    txtCodigo.Text,
                    txtEmpresa.Text,
                    txtCorreo.Text,
                    txtRuc.Text,
                    txtContacto.Text,
                    Convert.ToDouble(
                        txtSaldo.Text));
            if (TListaProveedores.Modificar(txtCodigo.Text, objProveedor))
            {
                MessageBox.Show("Proveedor modificado");
                MostrarProveedores();
                Limpiar();
            }
        }
        private void EliminarProveedor()
        {
            if (_posicion == -1)
            {
                MessageBox.Show("Seleccione un proveedor");
                return;
            }
            if (MessageBox.Show("¿Eliminar proveedor?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                TListaProveedores.Eliminar(txtCodigo.Text);
                MostrarProveedores();
                Limpiar();
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            InicializarFormulario();
            MostrarProveedores();
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            _posicion = e.RowIndex;
            txtCodigo.Text = dgvProveedores[0, e.RowIndex].Value.ToString();
            txtEmpresa.Text = dgvProveedores[1, e.RowIndex].Value.ToString();
            txtRuc.Text = dgvProveedores[2, e.RowIndex].Value.ToString();
            txtContacto.Text = dgvProveedores[3, e.RowIndex].Value.ToString();
            txtTelefono.Text = dgvProveedores[4, e.RowIndex].Value.ToString();
            txtDireccion.Text = dgvProveedores[5, e.RowIndex].Value.ToString();
            txtCorreo.Text = dgvProveedores[6, e.RowIndex].Value.ToString();
            txtSaldo.Text = dgvProveedores[7, e.RowIndex].Value.ToString();
            cboEstado.Text = dgvProveedores[8, e.RowIndex].Value.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarProveedor();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarProveedor();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarProveedor();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
