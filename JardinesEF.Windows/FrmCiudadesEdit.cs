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
    public partial class FrmCiudadesEdit : Form
    {
        public FrmCiudadesEdit(ICiudadesServicios servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private ICiudadesServicios _servicio;
        private Operacion operacion;
        private Ciudad ciudad;
        public void SetCiudad(Ciudad ciudad)
        {
            this.ciudad = ciudad;
        }

        public Ciudad GetCiudad()
        {
            return ciudad;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            operacion = Operacion.Nuevo;
            HelperCombos.CargarDatosComboPaises(ref PaisesComboBox);
            if (ciudad!=null)
            {
                CiudadTextBox.Text = ciudad.NombreCiudad;
                PaisesComboBox.SelectedValue = ciudad.Pais.PaisId;
                operacion = Operacion.Editar;
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
                if (ciudad==null)
                {
                    ciudad = new Ciudad();
                }

                ciudad.NombreCiudad = CiudadTextBox.Text;
                ciudad.Pais = (Pais)PaisesComboBox.SelectedItem;
                ciudad.PaisId = ((Pais)PaisesComboBox.SelectedItem).PaisId;

                try
                {
                    if (_servicio.Existe(ciudad))
                    {
                        errorProvider1.SetError(CiudadTextBox, "Ciudad inexistente");
                        return;
                    }
                    _servicio.Guardar(ciudad);
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

                    ciudad = null;
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
            CiudadTextBox.Clear();
            PaisesComboBox.SelectedIndex = 0;
            CiudadTextBox.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(CiudadTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(CiudadTextBox,"Debe ingresar una ciudad");
            }

            if (PaisesComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(PaisesComboBox,"Debe seleccionar una país");
            }

            return valido;
        }
    }
}
