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
using JardinesEF.Windows.Helpers;
using JardinesEF.Windows.Ninject;

namespace JardinesEF.Windows
{
    public partial class FrmOrdenes : Form
    {
        private readonly IOrdenesServicios _servicio;
        public FrmOrdenes(IOrdenesServicios servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private List<Orden> lista;
        private int cantidadPorPagina = 20;
        private int cantidadRegistros;
        private int cantidadPaginas;
        private int paginaActual = 1;
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmOrdenes_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            try
            {
                cantidadRegistros = _servicio.GetCantidad();

                cantidadPaginas = HelperCalculos.CalcularCantidadDePaginas(cantidadRegistros, cantidadPorPagina);
                HelperForm.CrearBotonesPaginas(this.BotonesPanel,cantidadPaginas);
                AsignarEventHandler(this.BotonesPanel);
                MostrarPaginado(cantidadPorPagina, paginaActual);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AsignarEventHandler(Panel botonesPanel)
        {
            foreach (Button b in botonesPanel.Controls)
            {
                b.Click += Miclick;
            }
        }

        private void Miclick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            paginaActual = int.Parse(b.Text);
            MostrarPaginado(cantidadPorPagina, paginaActual);
        }

        private void MostrarPaginado(int cantidadPorPagina, int paginaActual)
        {
            lista = _servicio.GetLista(cantidadPorPagina, paginaActual);
            MostrarDatosEnGrilla();

        }



        private void MostrarDatosEnGrilla()
        {
            HelperGrid.LimpiarGrilla(DatosDataGridView);
            foreach (var orden in lista)
            {
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);

                HelperGrid.SetearFila(r, orden);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
            //CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();
            //CantidadDePaginasLabel.Text = cantidadPaginas.ToString();
            //PaginaActualLabel.Text = paginaActual.ToString();
            HelperForm.MostrarInfoPaginas(this.splitContainer1.Panel2, cantidadRegistros,cantidadPaginas, paginaActual);
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmOrdenesEdit frm = new FrmOrdenesEdit(DI.Create<IProductosServicios>(),
                DI.Create<IOrdenesServicios>());
            DialogResult dr=frm.ShowDialog(this);
            if (dr==DialogResult.Cancel)
            {
                return;
            }

            try
            {
                var orden = frm.GetOrden();
                _servicio.Guardar(orden);
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);
                HelperGrid.SetearFila(r, orden);
                HelperGrid.AgregarFila(DatosDataGridView, r);
                HelperForm.MostrarInfoPaginas(this.splitContainer1.Panel2, cantidadRegistros, cantidadPaginas, paginaActual);

                MessageBox.Show("Venta guardada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDetalle_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count==0)
            {
                return;
            }

            try
            {
                DataGridViewRow r = DatosDataGridView.SelectedRows[0];
                var orden = (Orden) r.Tag;
                FrmOrdenDetalle frm = new FrmOrdenDetalle() {Text = "Detalle de la Venta"};
                frm.SetOrden(orden);
                frm.ShowDialog(this);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
