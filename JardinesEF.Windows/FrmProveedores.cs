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
using JardinesEF.Windows.Properties;

namespace JardinesEF.Windows
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores(IProveedoresServicios servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        const int cantidadPorPagina = 20;
        private bool filtroOn = false;

        private int cantidadPaginas;
        private int paginaActual;

        private readonly IProveedoresServicios _servicio;
        private List<Proveedor> lista;
        private int cantidadRegistros;
        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            try
            {
                filtroOn = false;
                cantidadRegistros = _servicio.GetCantidad();

                cantidadPaginas =HelperCalculos.CalcularCantidadDePaginas(cantidadRegistros, cantidadPorPagina);
                HelperForm.CrearBotonesPaginas(BotonesPanel, cantidadPaginas);
                paginaActual = 1;
                MostrarPaginado(cantidadPorPagina, paginaActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    ((Button)control).Click += Miclick;
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
            lista =filtroOn?_servicio.Find(predicate, cantidadPorPagina, paginaActual): _servicio.GetLista(cantidadPorPagina, paginaActual);
            MostrarDatosEnGrilla();

        }


        private void MostrarDatosEnGrilla()
        {
            HelperGrid.LimpiarGrilla(DatosDataGridView);
            foreach (var proveedor in lista)
            {
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);

                HelperGrid.SetearFila(r, proveedor);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
            //CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();
            //CantidadDePaginasLabel.Text = cantidadPaginas.ToString();
            //PaginaActualLabel.Text = paginaActual.ToString();
            HelperForm.MostrarInfoPaginas(this.splitContainer1.Panel2, cantidadRegistros, cantidadPaginas, paginaActual);

        }




        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmProveedoresEdit frm = new FrmProveedoresEdit(_servicio) { Text = "Nuevo Proveedor" };
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Proveedor proveedor = (Proveedor)r.Tag;
            FrmProveedoresEdit frm = new FrmProveedoresEdit(_servicio) { Text = "Editar Proveedor" };
            frm.SetProveedor(proveedor);
            DialogResult dr = frm.ShowDialog(this);
            MostrarPaginado(cantidadPaginas, paginaActual);
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Proveedor proveedor = (Proveedor)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro de {proveedor.NombreProveedor}?",
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
                _servicio.Borrar(proveedor.ProveedorId);
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

        private Func<Proveedor, bool> predicate;
        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarPersonas frm = new FrmBuscarPersonas() { Text = "Buscar Proveedores" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Pais paisSeleccionado = frm.GetPais();
                    Ciudad ciudadSeleccionada = frm.GetCiudad();
                    tsbBuscar.Image = Resources.BuscarActivado;
                    if (ciudadSeleccionada == null)
                    {
                        predicate = p => p.PaisId == paisSeleccionado.PaisId;
                    }
                    else
                    {
                        predicate = p => p.PaisId == paisSeleccionado.PaisId && p.CiudadId == ciudadSeleccionada.CiudadId;
                    }

                    cantidadRegistros = _servicio.GetCantidad(predicate);
                    cantidadPaginas = HelperCalculos.CalcularCantidadDePaginas(cantidadRegistros, cantidadPorPagina);
                    HelperForm.CrearBotonesPaginas(BotonesPanel, cantidadPaginas);
                    AsignarEventHandler(BotonesPanel);
                    paginaActual = 1;
                    filtroOn = true;
                    MostrarPaginado(cantidadPorPagina, paginaActual);

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
