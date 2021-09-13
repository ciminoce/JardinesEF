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
    public partial class FrmOrdenDetalle : Form
    {
        public FrmOrdenDetalle()
        {
            InitializeComponent();
        }

        private Orden orden;
        private void FrmOrdenDetalle_Load(object sender, EventArgs e)
        {
            MostrarEncabezado();
            MostrarDetalle();
            MostrarTotal();
        }

        private void MostrarTotal()
        {
            TotalPedidoTextBox.Text = HelperCalculos
                .CalcularTotalOrden(orden.DetalleOrdenes).ToString();
        }

        private void MostrarDetalle()
        {
            foreach (var detalle in orden.DetalleOrdenes)
            {
                DataGridViewRow r = HelperGrid.CrearFila(PedidoDataGridView);
                HelperGrid.SetearFila(r,detalle);
                HelperGrid.AgregarFila(PedidoDataGridView,r);
            }
        }

        private void MostrarEncabezado()
        {
            NroVentaLabel.Text = orden.OrdenId.ToString();
            FechaVentaTextBox.Text = orden.FechaCompra.ToShortDateString();
            ClienteTextBox.Text = orden.Cliente.ApeNombre;
            DireccionTextBox.Text = orden.Cliente.Direccion;
            PaisTextBox.Text = orden.Cliente.Pais.NombrePais;
            CiudadTextBox.Text = orden.Cliente.Ciudad.NombreCiudad;
            CodigoPostalTextBox.Text = orden.Cliente.CodigoPostal;

        }

        public void SetOrden(Orden orden)
        {
            this.orden = orden;
        }

        private void CerrarButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
