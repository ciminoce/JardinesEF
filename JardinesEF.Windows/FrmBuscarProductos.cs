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
using JardinesEF.Windows.Helpers;

namespace JardinesEF.Windows
{
    public partial class FrmBuscarProductos : Form
    {
        public FrmBuscarProductos()
        {
            InitializeComponent();
        }

        private Categoria categoria = null;
        private Proveedor proveedor = null;
        private void FrmBuscarProductos_Load(object sender, EventArgs e)
        {
            HelperCombos.CargarDatosComboCategorias(ref CategoriaComboBox);
            HelperCombos.CargarDatosComboProveedores(ref ProveedorComboBox);
        }

        private void ProveedorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProveedorComboBox.SelectedIndex==0)
            {
                proveedor = null;
                return;
            }

            proveedor = (Proveedor) ProveedorComboBox.SelectedItem;
        }

        public Categoria GetCategoria()
        {
            return categoria;
        }

        public Proveedor GetProveedor()
        {
            return proveedor;
        }
        private void CategoriaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoriaComboBox.SelectedIndex == 0)
            {
                categoria = null;
                return;
            }

            categoria = (Categoria)CategoriaComboBox.SelectedItem;

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (ProveedorComboBox.SelectedIndex==0 && CategoriaComboBox.SelectedIndex==0)
            {
                string error = "Debe seleccionar una categoría y/o proveedor para consultar";
                errorProvider1.SetError(ProveedorComboBox,error);
                errorProvider1.SetError(CategoriaComboBox,error);
                valido = false;
            }

            return valido;

        }
    }
}
