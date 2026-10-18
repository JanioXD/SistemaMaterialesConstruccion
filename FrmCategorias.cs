using SistemaMaterialesConstruccion.Controlador;
using SistemaMaterialesConstruccion.Entidades;
using SistemaMaterialesConstruccion.Utilidades;
using System;
using System.Windows.Forms;

namespace SistemaMaterialesConstruccion.Formularios
{
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
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
            txtCodigo.Text = GeneradorCodigos.GenerarCategoria();
        }
        private void Limpiar()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            cboEstado.SelectedIndex = 0;
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
            if (txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la descripción");
                txtDescripcion.Focus();
                return false;
            }
            return true;
        }
        private void GuardarCategoria()
        {
            if (!ValidarDatos())
            {
                return;
            }

            Categoria objCategoria = new Categoria(txtCodigo.Text, txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), cboEstado.Text == "Activo");
            if (TListaCategorias.Agregar(objCategoria))
            {
                MessageBox.Show("Categoría registrada");
                MostrarCategorias();
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo registrar");
            }
        }
        private void ModificarCategoria()
        {
            if (_posicion == -1)
            {
                MessageBox.Show("Seleccione una categoría");
                return;
            }

            Categoria objCategoria = new Categoria(txtCodigo.Text, txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), cboEstado.Text == "Activo");
            bool respuesta = TListaCategorias.Modificar(txtCodigo.Text, objCategoria);
            if (respuesta)
            {
                MessageBox.Show("Categoría modificada");
                MostrarCategorias();
                Limpiar();
            }
        }
        private void MostrarCategorias()
        {
            dgvCategorias.Rows.Clear();

            foreach (Categoria item in TListaCategorias._listaCategorias)
            {
                dgvCategorias.Rows.Add(item.Codigo, item.Nombre, item.Descripcion, item.Estado ? "Activo" : "Inactivo");
            }
        }
        private void EliminarCategoria()
        {
            if (_posicion == -1)
            {
                MessageBox.Show("Seleccione una categoría");
                return;
            }
            DialogResult respuesta = MessageBox.Show("¿Desea eliminar?", "Confirmación", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
            {
                TListaCategorias.Eliminar(txtCodigo.Text);
                MostrarCategorias();
                Limpiar();
            }
        }
        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            InicializarFormulario();
            MostrarCategorias();
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            _posicion = e.RowIndex;
            txtCodigo.Text = dgvCategorias[0, e.RowIndex].Value.ToString();
            txtNombre.Text = dgvCategorias[1, e.RowIndex].Value.ToString();
            txtDescripcion.Text = dgvCategorias[2, e.RowIndex].Value.ToString();
            cboEstado.Text = dgvCategorias[3, e.RowIndex].Value.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCategoria();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarCategoria();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarCategoria();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
