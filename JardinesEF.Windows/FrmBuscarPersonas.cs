using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Windows.Helpers;

namespace JardinesEF.Windows
{
    public partial class FrmBuscarPersonas : Form
    {
        public FrmBuscarPersonas()
        {
            InitializeComponent();
        }

        private void FrmBuscarClientes_Load(object sender, EventArgs e)
        {
            HelperCombos.CargarDatosComboPaises(ref PaisesComboBox);
        }

        private Pais pais=null;
        private Ciudad ciudad=null;
        private void PaisesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaisesComboBox.SelectedIndex!=0)
            {
                pais = (Pais) PaisesComboBox.SelectedItem;
                HelperCombos.CargarDatosComboCiudades(ref CiudadesComboBox, pais.PaisId);
            }
            else
            {
                pais = null;
                ciudad = null;
                CiudadesComboBox.DataSource = null;
            }
        }

        public Pais GetPais()
        {
            return pais;
        }

        public Ciudad GetCiudad()
        {
            return ciudad;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if(CiudadesComboBox.SelectedIndex>0)
                    ciudad =(Ciudad) CiudadesComboBox.SelectedItem;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (PaisesComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(PaisesComboBox, "Debe seleccionar un país");
            }

            return valido;
        }
    }
}
