using SistemaMaterialesConstruccion.Utilidades;
using System;
using System.Windows.Forms;

namespace SistemaMaterialesConstruccion.Formularios
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        private void MostrarDatosUsuario()
        {
            lblUsuarioSistema.Text = "Usuario: " + Sesion.NombreUsuario();
            lblRolSistema.Text = "Rol: " + Sesion.RolUsuario();
        }
        private void CerrarSesion()
        {
            DialogResult respuesta = MessageBox.Show("¿Desea cerrar la sesión?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Sesion.CerrarSesion();
                FrmLogin frm = new FrmLogin();
                frm.Show();
                this.Close();
            }
        }
        private void AbrirFormulario(Form formulario)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == formulario.Name)
                {
                    frm.Focus();
                    return;
                }
            }
            formulario.MdiParent = this;
            formulario.Show();
        }
        private void SalirSistema()
        {
            DialogResult respuesta = MessageBox.Show("¿Desea salir del sistema?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            MostrarDatosUsuario();
        }

        private void mnucategorías_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmCategorias());
        }

        private void mnuproductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmProductos());
        }

        private void mnuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmClientes());
        }

        private void mnuproveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmProveedores());
        }

        private void mnuusuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmUsuarios());
        }

        private void mnucompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmCompras());
        }

        private void mnuventas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmVentas());
        }

        private void mnucerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        private void mnusalir_Click(object sender, EventArgs e)
        {
            SalirSistema();
        }

        private void mnuAcercaDe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistema de Gestión de Materiales de Construcción\nVersión 1.0", "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportes frm = new FrmReportes();
            frm.ShowDialog();
        }
    }
}
