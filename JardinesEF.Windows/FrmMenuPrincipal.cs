using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JardinesEF.Servicios.Facades;
using JardinesEF.Windows.Ninject;

namespace JardinesEF.Windows
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void PaisesButton_Click(object sender, EventArgs e)
        {
            frmPaises frm = new frmPaises(DI.Create<IPaisesServicios>());
            frm.ShowDialog(this);
        }

        private void CategoriasButton_Click(object sender, EventArgs e)
        {
            FrmCategorias frm = new FrmCategorias(DI.Create<ICategoriasServicios>());
            frm.ShowDialog(this);
        }

        private void CiudadesButton_Click(object sender, EventArgs e)
        {
            FrmCiudades frm = new FrmCiudades(DI.Create<ICiudadesServicios>());
            frm.ShowDialog(this);
        }

        private void CerrarButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClientesButton_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes(DI.Create<IClientesServicios>());
            frm.ShowDialog(this);
        }

        private void ProveedoresButton_Click(object sender, EventArgs e)
        {
            FrmProveedores frm = new FrmProveedores(DI.Create<IProveedoresServicios>());
            frm.ShowDialog(this);
        }

        private void ProductosButton_Click(object sender, EventArgs e)
        {
            FrmProductos frm = new FrmProductos(DI.Create<IProductosServicios>());
            frm.ShowDialog(this);
        }

        private void VentasButton_Click(object sender, EventArgs e)
        {
            FrmOrdenes frm = new FrmOrdenes(DI.Create<IOrdenesServicios>());
            frm.ShowDialog(this);
        }
    }
}
