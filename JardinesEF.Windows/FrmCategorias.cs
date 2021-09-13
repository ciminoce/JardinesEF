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
using JardinesEF.Reportes;
using JardinesEF.Reportes.Reportes;
using JardinesEF.Servicios.Facades;
using JardinesEF.Windows.Helpers;
using JardinesEF.Windows.Ninject;

namespace JardinesEF.Windows
{
    public partial class FrmCategorias : Form
    {
        public FrmCategorias(ICategoriasServicios servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private int cantidadPaginas;
        private int cantidadPorPagina = 20;
        private int paginaActual;

        private readonly ICategoriasServicios _servicio;
        private List<Categoria> lista;
        private int cantidadRegistros;
        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        //private void CrearBotonesPaginas(int paginas)
        //{
        //    BotonesPanel.Controls.Clear();
        //    for (int i = 0; i < paginas; i++)
        //    {
        //        Button b = new Button()
        //        {
        //            Text = (i + 1).ToString(),
        //            Location = new Point(16 + (35 * i), 16),
        //            Size = new Size(32, 32)

        //        };
        //        b.Click += Miclick;//Le agrego un manejador al evento clic de los botones
        //        BotonesPanel.Controls.Add(b);//Agregro el botón a la colección de controles del panel
        //    }
        //}
        private void AsignarEventHandler(Panel botonesPanel)
        {
            foreach (var control in botonesPanel.Controls)
            {
                if (control is Button)
                {
                    ((Button) control).Click += Miclick;
                }
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
            foreach (var categoria in lista)
            {
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);

                HelperGrid.SetearFila(r, categoria);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
            //CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();
            //CantidadDePaginasLabel.Text = cantidadPaginas.ToString();
            //PaginaActualLabel.Text = paginaActual.ToString();
            HelperForm.MostrarInfoPaginas(this.splitContainer1.Panel2,cantidadRegistros,cantidadPaginas,paginaActual);

        }




        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmCategoriasEdit frm = new FrmCategoriasEdit(_servicio ) { Text = "Nueva Categoría" };
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();

        }

        private void RecargarGrilla()
        {
            try
            {

                cantidadRegistros = _servicio.GetCantidad();

                cantidadPaginas =HelperCalculos.CalcularCantidadDePaginas(cantidadRegistros, cantidadPorPagina);
                HelperForm.CrearBotonesPaginas(this.BotonesPanel, cantidadPaginas);
                AsignarEventHandler(this.BotonesPanel);
                paginaActual = 1;
                MostrarPaginado(cantidadPorPagina, paginaActual);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Categoria categoria = (Categoria)r.Tag;
            FrmCategoriasEdit frm = new FrmCategoriasEdit(_servicio) { Text = "Editar País" };
            frm.SetTipo(categoria);
            DialogResult dr = frm.ShowDialog(this);
            MostrarPaginado(cantidadPaginas,paginaActual);
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Categoria categoria = (Categoria)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro de {categoria.NombreCategoria}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                _servicio.Borrar(categoria.CategoriaId);
                HelperGrid.BorrarFila(DatosDataGridView, r);

                cantidadRegistros = _servicio.GetCantidad();
                CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();

                MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Registro relacionado... Baja denegada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            FrmVisorReportes frm = new FrmVisorReportes();
            ReporteCategorias rpt = DI.Create<IManejadorDeReportes>().GetReporteCategorias(lista);
            frm.SetReporte(rpt);
            frm.ShowDialog(this);

        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var listaGrupos = _servicio.GetGrupo();
                FrmProductosPorCategoria frm = new FrmProductosPorCategoria(DI.Create<ICategoriasServicios>());
                frm.SetGrupo(listaGrupos);
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
