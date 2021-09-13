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
    public partial class FrmPaisesEdit : Form
    {
        public FrmPaisesEdit(IPaisesServicios servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Operacion operacion;
        private IPaisesServicios _servicio;
        private Pais pais;
        public Pais GetTipo()
        {
            return pais;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (pais == null)
                {
                    pais = new Pais();
                }

                pais.NombrePais = PaisTextBox.Text;
                try
                {
                    if (_servicio.Existe(pais))
                    {
                        //if (operacion == Operacion.Editar)
                        //{
                        //    pais = paisCopia;

                        //}

                        errorProvider1.SetError(PaisTextBox, "País inexistente");
                        return;
                    }
                    _servicio.Guardar(pais);
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

                    pais = null;
                    InicializarControles();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        private void InicializarControles()
        {
            PaisTextBox.Clear();
            PaisTextBox.Focus();
        }

        private bool ValidarDatos()
        {
            bool esValido = true;
            if (string.IsNullOrEmpty(PaisTextBox.Text))
            {
                esValido = false;
                errorProvider1.SetError(PaisTextBox, "Debe ingresar un país");

            }

            return esValido;
        }

        public void SetTipo(Pais pais)
        {
            this.pais = pais;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            operacion = Operacion.Nuevo;
            if (pais != null)
            {
                PaisTextBox.Text = pais.NombrePais;
                operacion = Operacion.Editar;

            }
        }

    }
}
