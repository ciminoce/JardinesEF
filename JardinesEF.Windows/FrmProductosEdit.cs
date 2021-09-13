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
using JardinesEF.Windows.Helpers;

namespace JardinesEF.Windows
{
    public partial class FrmProductosEdit : Form
    {
        public FrmProductosEdit(IProductosServicios servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private IProductosServicios _servicio;
        private Operacion operacion;
        private Producto producto;

        public Producto GetProducto()
        {
            return producto;
        }
        public void SetProducto(Producto producto)
        {
            this.producto = producto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HelperCombos.CargarDatosComboCategorias(ref CategoriaComboBox);
            HelperCombos.CargarDatosComboProveedores(ref ProveedorComboBox);
            if (producto!=null)
            {
                ProductoTextBox.Text = producto.NombreProducto;
                NombreLatinTextBox.Text = producto.NombreLatin;
                PrecioTextBox.Text = producto.PrecioUnitario.ToString();
                StockTextBox.Text = producto.UnidadesEnStock.ToString();
                NivelReposicionTextBox.Text = producto.NivelDeReposicion.ToString();
                SuspendidoCheckBox.Checked = producto.Suspendido;
                CategoriaComboBox.SelectedItem = producto.CategoriaId;
                ProveedorComboBox.SelectedItem = producto.ProveedorId;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (producto == null)
                {
                    producto = new Producto();
                }

                producto.NombreProducto = ProductoTextBox.Text;
                producto.NombreLatin = NombreLatinTextBox.Text;
                producto.NivelDeReposicion = int.Parse(NivelReposicionTextBox.Text);
                producto.PrecioUnitario = decimal.Parse(PrecioTextBox.Text);
                producto.UnidadesEnStock = int.Parse(StockTextBox.Text);
                producto.Suspendido = SuspendidoCheckBox.Checked;
                producto.Proveedor = (Proveedor)ProveedorComboBox.SelectedItem;
                producto.Categoria = (Categoria)CategoriaComboBox.SelectedItem;
                producto.CategoriaId= ((Categoria)CategoriaComboBox.SelectedItem).CategoriaId;
                producto.ProveedorId= ((Proveedor)ProveedorComboBox.SelectedItem).ProveedorId;
                try
                {
                    if (_servicio.Existe(producto))
                    {
                        errorProvider1.SetError(ProductoTextBox, "Producto inexistente");
                        return;
                    }
                    _servicio.Guardar(producto);
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

                    producto = null;
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
            ProductoTextBox.Clear();
            NombreLatinTextBox.Clear();
            PrecioTextBox.Clear();
            StockTextBox.Clear();
            NivelReposicionTextBox.Clear();
            SuspendidoCheckBox.Checked = false;
            CategoriaComboBox.SelectedItem = 0;
            ProveedorComboBox.SelectedItem = 0;
            ProductoTextBox.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(ProductoTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(ProductoTextBox, "Debe ingresar un nombre");
            }

            if (!decimal.TryParse(PrecioTextBox.Text,out decimal precio))
            {
                valido = false;
                errorProvider1.SetError(PrecioTextBox,"Precio no válido");
            }else if (precio<=0)
            {
                valido = false;
                errorProvider1.SetError(PrecioTextBox,"Precio debe ser positivo");
                
            }
            if (!int.TryParse(StockTextBox.Text, out int stock))
            {
                valido = false;
                errorProvider1.SetError(StockTextBox, "Stock no válido");
            }
            else if (stock <= 0)
            {
                valido = false;
                errorProvider1.SetError(StockTextBox, "Stock debe ser positivo");

            }
            if (!int.TryParse(NivelReposicionTextBox.Text, out int nivel))
            {
                valido = false;
                errorProvider1.SetError(NivelReposicionTextBox, "Nivel no válido");
            }
            else if (nivel <= 0)
            {
                valido = false;
                errorProvider1.SetError(NivelReposicionTextBox, "Nivel debe ser positivo");

            }

            if (CategoriaComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(CategoriaComboBox, "Debe seleccionar una categoría");
            }

            if (ProveedorComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ProveedorComboBox, "Debe seleccionar un proveedor");
            }
            return valido;
        }

    }
}
