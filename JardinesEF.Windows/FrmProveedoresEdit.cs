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
    public partial class FrmProveedoresEdit : Form
    {
        public FrmProveedoresEdit(IProveedoresServicios servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private Proveedor proveedor;
        private Operacion operacion;
        private IProveedoresServicios _servicio;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            operacion = Operacion.Nuevo;
            HelperCombos.CargarDatosComboPaises(ref PaisesComboBox);
            if (proveedor != null)
            {
                HelperCombos.CargarDatosComboCiudades(ref CiudadesComboBox, proveedor.PaisId);
                CompaniaTextBox.Text = proveedor.NombreProveedor;
                CalleTextBox.Text = proveedor.Direccion;
                CodPostalTextBox.Text = proveedor.CodigoPostal;
                PaisesComboBox.SelectedValue = proveedor.PaisId;
                CiudadesComboBox.SelectedValue = proveedor.CiudadId;
                operacion = Operacion.Editar;
            }
        }

        public void SetProveedor(Proveedor proveedor)
        {
            this.proveedor = proveedor;
        }

        public Proveedor GetProveedor()
        {
            return proveedor;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (proveedor == null)
                {
                    proveedor = new Proveedor();
                }

                proveedor.Pais = pais;
                proveedor.PaisId = pais.PaisId;
                proveedor.NombreProveedor = CompaniaTextBox.Text;
                proveedor.Direccion = CalleTextBox.Text;
                proveedor.Ciudad = (Ciudad)CiudadesComboBox.SelectedItem;
                proveedor.CiudadId = ((Ciudad)CiudadesComboBox.SelectedItem).CiudadId;

                try
                {
                    if (_servicio.Existe(proveedor))
                    {
                        errorProvider1.SetError(CompaniaTextBox, "Proveedor inexistente");
                        return;
                    }
                    _servicio.Guardar(proveedor);
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

                    proveedor = null;
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
            CompaniaTextBox.Clear();
            CalleTextBox.Clear();
            CodPostalTextBox.Clear();
            PaisesComboBox.SelectedIndex = 0;
            CiudadesComboBox.DataSource = null;
            pais = null;
            CompaniaTextBox.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(CompaniaTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(CompaniaTextBox, "Debe ingresar un nombre");
            }

            if (string.IsNullOrWhiteSpace(CalleTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(CalleTextBox, "Debe ingresar una dirección");

            }

            if (PaisesComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(PaisesComboBox, "Debe seleccionar un país");
            }

            if (CiudadesComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(CiudadesComboBox, "Debe seleccionar una ciudad");
            }
            return valido;
        }
        private Pais pais;

        private void PaisesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaisesComboBox.SelectedIndex != 0)
            {
                pais = (Pais)PaisesComboBox.SelectedItem;
                HelperCombos.CargarDatosComboCiudades(ref CiudadesComboBox, pais.PaisId);
            }
            else
            {
                CiudadesComboBox.DataSource = null;
                pais = null;

            }
        }

    }
}
