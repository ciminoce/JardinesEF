using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    public partial class FrmBuscarCiudades : Form
    {
        public FrmBuscarCiudades()
        {
            InitializeComponent();
        }

        private Pais pais;
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                pais = (Pais) PaisesComboBox.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (PaisesComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(PaisesComboBox,"Debe seleccionar un país");
            }

            return valido;
        }

        public Pais GetPais()
        {
            return pais;
        }

        private void FrmBuscarCiudades_Load(object sender, EventArgs e)
        {
            HelperCombos.CargarDatosComboPaises(ref PaisesComboBox);
        }
    }
}
