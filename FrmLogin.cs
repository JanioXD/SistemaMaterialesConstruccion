using SistemaMaterialesConstruccion.Controlador;
using SistemaMaterialesConstruccion.Entidades;
using SistemaMaterialesConstruccion.Utilidades;
using System;
using System.Windows.Forms;

namespace SistemaMaterialesConstruccion.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private bool ValidarCampos()
        {
            if (txtUsuario.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese el usuario");

                txtUsuario.Focus();

                return false;
            }

            if (txtClave.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese la contraseña");

                txtClave.Focus();

                return false;
            }

            return true;
        }
        private void IniciarSesion()
        {
            if (!ValidarCampos())
            {
                return;
            }

            Usuario objUsuario =
                TListaUsuarios.Login(
                    txtUsuario.Text.Trim(),
                    txtClave.Text.Trim());

            if (objUsuario == null)
            {
                MessageBox.Show(
                    "Usuario o contraseña incorrectos");

                txtClave.Clear();

                txtClave.Focus();

                return;
            }

            Sesion.IniciarSesion(objUsuario);

            FrmPrincipal frm =
                new FrmPrincipal();

            frm.Show();

            this.Hide();
        }
        private void SalirSistema()
        {
            DialogResult respuesta =
                MessageBox.Show(
                    "¿Desea salir del sistema?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (respuesta ==
                DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            SalirSistema();
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IniciarSesion();
            }
        }
    }
}
