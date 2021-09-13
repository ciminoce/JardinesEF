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
    public partial class FrmCiudades : Form
    {
        public FrmCiudades(ICiudadesServicios servicio)
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

        private readonly ICiudadesServicios _servicio;
        private List<Ciudad> lista;
        private int cantidadRegistros;
        private Func<Ciudad, bool> predicate;

        private void FrmCiudades_Load(object sender, EventArgs e)
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
                AsignarEventHandler(BotonesPanel);
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

        private Pais paisSeleccionado;
        private void MostrarPaginado(int cantidadPorPagina, int paginaActual)
        {
            lista = filtroOn ? _servicio.Find(predicate, cantidadPorPagina, paginaActual) : _servicio.GetLista(cantidadPorPagina, paginaActual);
            MostrarDatosEnGrilla();
        }


        private void MostrarDatosEnGrilla()
        {
            HelperGrid.LimpiarGrilla(DatosDataGridView);
            foreach (var ciudad in lista)
            {
                DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);

                HelperGrid.SetearFila(r, ciudad);
                HelperGrid.AgregarFila(DatosDataGridView, r);
            }
            //CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();
            //CantidadDePaginasLabel.Text = cantidadPaginas.ToString();
            //PaginaActualLabel.Text = paginaActual.ToString();
            HelperForm.MostrarInfoPaginas(this.splitContainer1.Panel2, cantidadRegistros, cantidadPaginas, paginaActual);

        }




        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmCiudadesEdit frm = new FrmCiudadesEdit(_servicio) { Text = "Nueva Ciudad" };
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();
            if (dr == DialogResult.OK)
            {
                try
                {
                    Ciudad ciudad = frm.GetCiudad();
                    if (_servicio.Existe(ciudad))
                    {
                        MessageBox.Show("Categoría existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(ciudad);
                    DataGridViewRow r = HelperGrid.CrearFila(DatosDataGridView);
                    HelperGrid.SetearFila(r, ciudad);
                    HelperGrid.AgregarFila(DatosDataGridView, r);

                    cantidadRegistros = _servicio.GetCantidad();

                    CantidadDeRegistrosLabel.Text = cantidadRegistros.ToString();

                    MessageBox.Show("Registro guardado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = DatosDataGridView.SelectedRows[0];
            Ciudad ciudad = (Ciudad)r.Tag;
            FrmCiudadesEdit frm = new FrmCiudadesEdit(_servicio) { Text = "Editar Ciudad" };
            frm.SetCiudad(ciudad);
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
            Ciudad ciudad = (Ciudad)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro de {ciudad.NombreCiudad}?",
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
                _servicio.Borrar(ciudad.CiudadId);
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

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarCiudades frm = new FrmBuscarCiudades() { Text = "Seleccionar País" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;

            }

            try
            {
                tsbBuscar.Image = Resources.BuscarActivado;
                paisSeleccionado = frm.GetPais();
                predicate = c => c.PaisId == paisSeleccionado.PaisId;

                cantidadRegistros = _servicio.GetCantidad(predicate);
                cantidadPaginas = HelperCalculos.CalcularCantidadDePaginas(cantidadRegistros, cantidadPorPagina);
                HelperForm.CrearBotonesPaginas(BotonesPanel, cantidadPaginas);
                AsignarEventHandler(BotonesPanel);
                paginaActual = 1;
                filtroOn = true;
                MostrarPaginado(cantidadPorPagina, paginaActual);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                tsbBuscar.Image = Resources.search_property_30px;
                filtroOn = false;
                RecargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
