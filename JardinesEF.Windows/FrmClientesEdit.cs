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
    public partial class FrmClientesEdit : Form
    {
        public FrmClientesEdit(IClientesServicios servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Cliente cliente;
        private Operacion operacion;
        private IClientesServicios _servicio;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            operacion = Operacion.Nuevo;
            HelperCombos.CargarDatosComboPaises(ref PaisesComboBox);
            if (cliente!=null)
            {
                HelperCombos.CargarDatosComboCiudades(ref CiudadesComboBox, cliente.PaisId);
                NombreTextBox.Text = cliente.Nombres;
                ApellidoTextBox.Text = cliente.Apellido;
                CalleTextBox.Text = cliente.Direccion;
                CodPostalTextBox.Text = cliente.CodigoPostal;
                PaisesComboBox.SelectedValue = cliente.PaisId;
                CiudadesComboBox.SelectedValue = cliente.CiudadId;
                operacion = Operacion.Editar;
            }
        }

        public void SetCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public Cliente GetCliente()
        {
            return cliente;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cliente==null)
                {
                    cliente = new Cliente();
                }

                cliente.Pais = pais;
                cliente.PaisId = pais.PaisId;
                cliente.Apellido = ApellidoTextBox.Text;
                cliente.Nombres = NombreTextBox.Text;
                cliente.Direccion = CalleTextBox.Text;
                cliente.Ciudad = (Ciudad) CiudadesComboBox.SelectedItem;
                cliente.CiudadId = ((Ciudad) CiudadesComboBox.SelectedItem).CiudadId;

                try
                {
                    if (_servicio.Existe(cliente))
                    {
                        errorProvider1.SetError(NombreTextBox, "Cliente inexistente");
                        return;
                    }
                    _servicio.Guardar(cliente);
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

                    cliente = null;
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
            NombreTextBox.Clear();
            ApellidoTextBox.Clear();
            CalleTextBox.Clear();
            CodPostalTextBox.Clear();
            PaisesComboBox.SelectedIndex=0;
            CiudadesComboBox.DataSource=null;
            pais = null;
            NombreTextBox.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(NombreTextBox,"Debe ingresar un nombre");
            }

            if (string.IsNullOrWhiteSpace(ApellidoTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(ApellidoTextBox,"Debe ingresar un apellido");
                
            }
            if (string.IsNullOrWhiteSpace(CalleTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(CalleTextBox, "Debe ingresar una dirección");

            }

            if (PaisesComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(PaisesComboBox,"Debe seleccionar un país");
            }

            if (CiudadesComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(CiudadesComboBox,"Debe seleccionar una ciudad");
            }
            return valido;
        }
        private Pais pais;

        private void PaisesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaisesComboBox.SelectedIndex!=0)
            {
                pais = (Pais) PaisesComboBox.SelectedItem;
                HelperCombos.CargarDatosComboCiudades(ref CiudadesComboBox,pais.PaisId);
            }
            else
            {
                CiudadesComboBox.DataSource = null;
                pais = null;

            }
        }
    }
}
