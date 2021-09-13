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

namespace JardinesEF.Windows
{
    public partial class FrmProductos : Form
    {
        public FrmProductos(IProductosServicios servicio)
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

        private readonly IProductosServicios _servicio;
        private List<Producto> lista;
        private int cantidadRegistros;
        private void FrmProductos_Load(object sender, EventArgs e)
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
                HelperForm.CrearBotonesPaginas(BotonesPanel,cantidadPaginas);
                
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
            lista =filtroOn?_servicio.Find(predicate,cantidadPorPagina,paginaActual):_servicio.GetLista(cantidadPorPagina, paginaActual);
            MostrarDatosEnGrilla();

        }


        private void MostrarDatosEnGrilla()
        {
            HelperGrid.LimpiarGrilla(DatosDataGridView);
            foreach (var producto in lista)
            {
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);

                HelperGrid.SetearFila(r, producto);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
            //CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();
            //CantidadDePaginasLabel.Text = cantidadPaginas.ToString();
            //PaginaActualLabel.Text = paginaActual.ToString();
            HelperForm.MostrarInfoPaginas(this.splitContainer1.Panel2, cantidadRegistros, cantidadPaginas, paginaActual);

        }




        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmProductosEdit frm = new FrmProductosEdit(_servicio) { Text = "Nuevo Producto" };
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
            Producto producto = (Producto)r.Tag;
            FrmProductosEdit frm = new FrmProductosEdit(_servicio) { Text = "Editar Producto" };
            frm.SetProducto(producto);
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
            Producto producto = (Producto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro de {producto.NombreProducto}?",
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
                _servicio.Borrar(producto.ProveedorId);
                HelperGrid.BorrarFila(DatosDataGridView, r);

                cantidadRegistros = _servicio.GetCantidad();
                //CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();
                HelperForm.MostrarInfoPaginas(this.splitContainer1.Panel2,cantidadRegistros,cantidadPaginas,paginaActual);

                MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Registro relacionado... Baja denegada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Func<Producto, bool> predicate;
        private void porCategoríaYProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarProductos frm = new FrmBuscarProductos() {Text = "Seleccionar Categoría y/o Proveedor"};
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                try
                {
                    var categoria = frm.GetCategoria();
                    var proveedor = frm.GetProveedor();
                    if (categoria!=null && proveedor!=null)
                    {
                        predicate = c =>
                            c.CategoriaId == categoria.CategoriaId && c.ProveedorId == proveedor.ProveedorId;
                    }else if (categoria==null)
                    {
                        predicate = c => c.ProveedorId == proveedor.ProveedorId;
                    }
                    else
                    {
                        predicate = c => c.CategoriaId == categoria.CategoriaId;
                    }

                    filtroOn = true;
                    cantidadRegistros = _servicio.GetCantidad(predicate);

                    if (cantidadRegistros>0)
                    {
                        cantidadPaginas = HelperCalculos.CalcularCantidadDePaginas(cantidadRegistros, cantidadPorPagina);
                        paginaActual = 1;
                        HelperForm.CrearBotonesPaginas(BotonesPanel, cantidadPaginas);
                        AsignarEventHandler(BotonesPanel);
                        MostrarPaginado(cantidadPorPagina, paginaActual);

                    }
                    else
                    {
                        MessageBox.Show("No hay registros con ese criterio", "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void suspendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                predicate = c => c.Suspendido;
                filtroOn = true;
                cantidadRegistros = _servicio.GetCantidad(predicate);
                cantidadPaginas = HelperCalculos.CalcularCantidadDePaginas(cantidadRegistros, cantidadPorPagina);
                paginaActual = 1;
                HelperForm.CrearBotonesPaginas(BotonesPanel, cantidadPaginas);
                AsignarEventHandler(BotonesPanel);
                MostrarPaginado(cantidadPorPagina, paginaActual);


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enNivelDeReposiciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                predicate = c => c.UnidadesEnStock<= c.NivelDeReposicion;
                filtroOn = true;
                cantidadRegistros = _servicio.GetCantidad(predicate);
                cantidadPaginas = HelperCalculos.CalcularCantidadDePaginas(cantidadRegistros, cantidadPorPagina);
                paginaActual = 1;
                HelperForm.CrearBotonesPaginas(BotonesPanel, cantidadPaginas);
                AsignarEventHandler(BotonesPanel);
                MostrarPaginado(cantidadPorPagina, paginaActual);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
        }
    }
}
