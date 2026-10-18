using SistemaMaterialesConstruccion.Controlador;
using SistemaMaterialesConstruccion.Entidades;
using SistemaMaterialesConstruccion.Utilidades;
using System;
using System.Windows.Forms;

namespace SistemaMaterialesConstruccion.Formularios
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }
        private int _posicion = -1;
        private void InicializarFormulario()
        {
            cboRol.Items.Clear();
            cboRol.Items.Add("Administrador");
            cboRol.Items.Add("Vendedor");
            cboRol.SelectedIndex = 0;
            cboEstado.Items.Clear();
            cboEstado.Items.Add("Activo");
            cboEstado.Items.Add("Inactivo");
            cboEstado.SelectedIndex = 0;
            txtCodigo.Enabled = false;
            txtIntentos.Text = "0";
            GenerarCodigo();
        }
        private void Limpiar()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            txtIntentos.Text = "0";
            cboRol.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
            _posicion = -1;
            GenerarCodigo();
            txtCedula.Focus();
        }
        private bool ValidarDatos()
        {
            if (txtCedula.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la cédula");
                return false;
            }
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre");
                return false;
            }
            if (txtUsuario.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el usuario");
                return false;
            }
            if (txtClave.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la contraseña");
                return false;
            }
            return true;
        }
        private void MostrarUsuarios()
        {
            dgvUsuarios.Rows.Clear();
            foreach (Usuario item in TListaUsuarios._listaUsuarios)
            {
                dgvUsuarios.Rows.Add(
                    item.Codigo,
                    item.Identificacion,
                    item.Nombre,
                    item.Telefono,
                    item.Direccion,
                    item.NombreUsuario,
                    item.Rol,
                    item.Intentos,
                    item.Estado
                        ? "Activo"
                        : "Inactivo");
            }
        }
        private void GenerarCodigo()
        {
            txtCodigo.Text = GeneradorCodigos.GenerarUsuario();
        }
        private void GuardarUsuario()
        {
            if (!ValidarDatos())
            {
                return;
            }

            Usuario objUsuario =
                new Usuario(
                    txtCedula.Text,
                    txtNombre.Text,
                    txtTelefono.Text,
                    txtDireccion.Text,
                    cboEstado.Text == "Activo",
                    txtCodigo.Text,
                    txtUsuario.Text,
                    txtClave.Text,
                    cboRol.Text,
                    Convert.ToInt32(
                        txtIntentos.Text));
            if (TListaUsuarios.Agregar(objUsuario))
            {
                MessageBox.Show("Usuario registrado");
                MostrarUsuarios();
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo registrar");
            }
        }
        private void ModificarUsuario()
        {
            if (_posicion == -1)
            {
                MessageBox.Show("Seleccione un usuario");
                return;
            }

            Usuario objUsuario =
                new Usuario(
                    txtCedula.Text,
                    txtNombre.Text,
                    txtTelefono.Text,
                    txtDireccion.Text,
                    cboEstado.Text == "Activo",
                    txtCodigo.Text,
                    txtUsuario.Text,
                    txtClave.Text,
                    cboRol.Text,
                    Convert.ToInt32(
                        txtIntentos.Text));
            if (TListaUsuarios.Modificar(txtCodigo.Text, objUsuario))
            {
                MessageBox.Show("Usuario modificado");
                MostrarUsuarios();
                Limpiar();
            }
        }
        private void EliminarUsuario()
        {
            if (_posicion == -1)
            {
                MessageBox.Show("Seleccione un usuario");
                return;
            }
            if (MessageBox.Show("¿Eliminar usuario?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                TListaUsuarios.Eliminar(txtCodigo.Text);
                MostrarUsuarios();
                Limpiar();
            }
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            InicializarFormulario();
            MostrarUsuarios();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            _posicion = e.RowIndex;
            txtCodigo.Text = dgvUsuarios[0, e.RowIndex].Value.ToString();
            txtCedula.Text = dgvUsuarios[1, e.RowIndex].Value.ToString();
            txtNombre.Text = dgvUsuarios[2, e.RowIndex].Value.ToString();
            txtTelefono.Text = dgvUsuarios[3, e.RowIndex].Value.ToString();
            txtDireccion.Text = dgvUsuarios[4, e.RowIndex].Value.ToString();
            txtUsuario.Text = dgvUsuarios[5, e.RowIndex].Value.ToString();
            cboRol.Text = dgvUsuarios[6, e.RowIndex].Value.ToString();
            txtIntentos.Text = dgvUsuarios[7, e.RowIndex].Value.ToString();
            cboEstado.Text = dgvUsuarios[8, e.RowIndex].Value.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarUsuario();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarUsuario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarUsuario();
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
