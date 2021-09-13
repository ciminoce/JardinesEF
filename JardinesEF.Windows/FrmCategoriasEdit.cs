using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Servicios.Facades;
using JardinesEF.Windows.Enums;

namespace JardinesEF.Windows
{
    public partial class FrmCategoriasEdit : Form
    {
        public FrmCategoriasEdit(ICategoriasServicios servicio)
        {
            InitializeComponent();
            _servicio = servicio;

        }

        private ICategoriasServicios _servicio;
        private Categoria categoria;
        private Operacion operacion;
        public Categoria GetTipo()
        {
            return categoria;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (categoria == null)
                {
                    categoria = new Categoria();
                }

                categoria.NombreCategoria = CategoriaTextBox.Text;

                try
                {
                    if (_servicio.Existe(categoria))
                    {
                        errorProvider1.SetError(CategoriaTextBox, "Categoría inexistente");
                        return;
                    }
                    _servicio.Guardar(categoria);
                    MessageBox.Show("Registro guardado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (operacion == Operacion.Editar)
                    {
                        DialogResult = DialogResult.OK;
                        return;

                    }
                    DialogResult dr = MessageBox.Show("¿Desea dar de alta otro registro?", "Confirmar",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.No)
                    {
                        DialogResult = DialogResult.Cancel;
                    }

                    categoria = null;
                    InicializarControles();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void InicializarControles()
        {
            CategoriaTextBox.Clear();
            CategoriaTextBox.Focus();

        }

        private bool ValidarDatos()
        {
            bool esValido = true;
            if (string.IsNullOrEmpty(CategoriaTextBox.Text))
            {
                esValido = false;
                errorProvider1.SetError(CategoriaTextBox, "Debe ingresar un país");

            }

            return esValido;
        }

        public void SetTipo(Categoria categoria)
        {
            this.categoria = categoria;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            operacion = Operacion.Nuevo;
            if (categoria != null)
            {
                CategoriaTextBox.Text = categoria.NombreCategoria;
                DescripcionTextBox.Text = categoria.Descripcion;
                operacion = Operacion.Editar;
            }
        }


    }
}
