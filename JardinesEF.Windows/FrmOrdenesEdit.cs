using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Windows.Forms;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Servicios.Facades;
using JardinesEF.Windows.Classes;
using JardinesEF.Windows.Helpers;

namespace JardinesEF.Windows
{
    public partial class FrmOrdenesEdit : Form
    {
        public FrmOrdenesEdit(IProductosServicios servicio, IOrdenesServicios servicioOrdenes)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioOrdenes = servicioOrdenes;
        }

        private IProductosServicios _servicio;
        private IOrdenesServicios _servicioOrdenes;
        private Orden orden;
        private Producto producto;
        private Categoria categoria;
        private List<DetalleOrden> detalle;
        private DetalleOrden detalleOrden;
        private Cliente cliente;
        private void FrmOrdenesEdit_Load(object sender, EventArgs e)
        {
            HelperCombos.CargarDatosComboClientes(ref ClientesComboBox);
            HelperCombos.CargarDatosComboCategorias(ref CategoriaComboBox);
            FechaPedidoDatePicker.Value = DateTime.Now;
        }

        private void CategoriaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoriaComboBox.SelectedIndex>0)
            {
                categoria = (Categoria) CategoriaComboBox.SelectedItem;
                HelperCombos.CargarDatosComboProductos(ref ProductoComboBox, categoria.CategoriaId);
            }
            else
            {
                categoria = null;
                ProductoComboBox.DataSource = null;
            }
        }

        private void ProductoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (ProductoComboBox.SelectedIndex > 0)
            {
                producto = (Producto) ProductoComboBox.SelectedItem;
                if (producto.Suspendido)
                {
                    errorProvider1.SetError(ProductoComboBox,"Producto suspendido");
                }else if (producto.UnidadesEnStock==0 ||producto.UnidadesEnStock-producto.UnidadesEnPedido==0)
                {
                    errorProvider1.SetError(ProductoComboBox,"Producto sin stock disponible");
                }
                else
                {
                    PrecioUnitTextBox.Text = producto.PrecioUnitario.ToString("C");
                    StockTextBox.Text = producto.UnidadesEnStock.ToString();
                    EnPedidoTextBox.Text = producto.UnidadesEnPedido.ToString();
                    CantidadUpDown.Enabled = true;
                }
            }
            else
            {
                producto = null;
                CantidadUpDown.Enabled = false;
            }
        }

        private void CantidadUpDown_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (producto!=null)
            {
                if (CantidadUpDown.Value <= producto.UnidadesEnStock-producto.UnidadesEnPedido)
                {
                    decimal precioTotal = HelperCalculos.CalcularTotal(producto.PrecioUnitario, CantidadUpDown.Value);
                    PrecioTotalTextoBox.Text = precioTotal.ToString("C");
                }
                else
                {
                    errorProvider1.SetError(CantidadUpDown, "Cantidad superior al stock!!!");
                }

            }
        }

        private void CancelarProductoButton_Click(object sender, EventArgs e)
        {
            InicializarControles();
        }

        private void InicializarControles()
        {
            CategoriaComboBox.SelectedIndex = 0;
            CantidadUpDown.Value = 0;
            PrecioTotalTextoBox.Clear();
            PrecioUnitTextBox.Clear();
            StockTextBox.Clear();
            EnPedidoTextBox.Clear();
            CategoriaComboBox.Focus();

        }

        private void AceptarProductoButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                detalleOrden = new DetalleOrden()
                {
                    Producto = producto,
                    ProductoId = producto.ProductoId,
                    PrecioUnitario = producto.PrecioUnitario,
                    Cantidad = (int) CantidadUpDown.Value

                };
                if (Carrito.GetInstancia().ExisteDetalleOrden(detalleOrden))
                {
                    DialogResult dr = MessageBox.Show("Producto obrante en el pedido...Incrementa su cantidad?",
                        "Pregunta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.No)
                    {
                        return;
                    }
                    Carrito.GetInstancia().Agregar(detalleOrden);
                    RecargarGrilla();
                }
                else
                {
                    Carrito.GetInstancia().Agregar(detalleOrden);
                    DataGridViewRow r = HelperGrid.CrearFila(PedidoDataGridView);
                    HelperGrid.SetearFila(r, detalleOrden);
                    HelperGrid.AgregarFila(PedidoDataGridView, r);
                    
                }

                _servicio.SetearReservarProducto(detalleOrden.ProductoId, detalleOrden.Cantidad);

                MessageBox.Show("Producto agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

                InformarTotal(Carrito.GetInstancia().listaItemsCompra);

                InicializarControles();
            }
        }

        private void RecargarGrilla()
        {
            PedidoDataGridView.Rows.Clear();
            foreach (var item in Carrito.GetInstancia().listaItemsCompra)
            {
                DataGridViewRow r = HelperGrid.CrearFila(PedidoDataGridView);
                HelperGrid.SetearFila(r,item);
                HelperGrid.AgregarFila(PedidoDataGridView,r);
            }
        }

        private void InformarTotal(List<DetalleOrden> listaItemsCompra)
        {
            TotalPedidoTextBox.Text = listaItemsCompra
                .Sum(i => i.PrecioUnitario * (decimal) i.Cantidad).ToString("C");
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (CategoriaComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(CategoriaComboBox,"Seleccione una categoría");
            }else if (ProductoComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(ProductoComboBox,"Seleccione un producto");
            }else if (producto.Suspendido)
            {
                valido = false;
                errorProvider1.SetError(ProductoComboBox, "Producto suspendido");
            }
            else if (producto.UnidadesEnStock == 0)
            {
                valido = false;
                errorProvider1.SetError(ProductoComboBox, "Producto sin Stock");
            }else if (CantidadUpDown.Value > producto.UnidadesEnStock)
            {
                valido = false;
                errorProvider1.SetError(CantidadUpDown, "Cantidad superior al stock!!!");
            }else if (CantidadUpDown.Value == 0)
            {
                valido = false;
                errorProvider1.SetError(CantidadUpDown,"Debe ingresar una cantidad");
            }

            return valido;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (Carrito.GetInstancia().GetCantidadItems()>0)
            {
                _servicioOrdenes.CancelarReservas(Carrito.GetInstancia().listaItemsCompra);
            }
            DialogResult = DialogResult.Cancel;
        }

        private void PedidoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==4)
            {
                DialogResult dr = MessageBox.Show("¿Desea eliminar del pedido el item seleccionado?", "Pregunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr==DialogResult.No)
                {
                    return;
                }

                DataGridViewRow r = PedidoDataGridView.SelectedRows[0];
                DetalleOrden detalleABorrar = (DetalleOrden) r.Tag;

                Carrito.GetInstancia().QuitarDelCarrito(detalleABorrar);
                _servicio.SetearReservarProducto(detalleABorrar.ProductoId, -detalleABorrar.Cantidad);

                HelperGrid.BorrarFila(PedidoDataGridView,r);
                
                InformarTotal(Carrito.GetInstancia().listaItemsCompra);
                MessageBox.Show("Item eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarOrden())
            {
                orden = new Orden()
                {
                    Cliente = cliente,
                    ClienteId = cliente.ClienteId,
                    FechaCompra = FechaPedidoDatePicker.Value,
                    DetalleOrdenes = Carrito.GetInstancia().listaItemsCompra
                };

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarOrden()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (Carrito.GetInstancia().GetCantidadItems()==0)
            {
                valido = false;
                errorProvider1.SetError(ProductoComboBox,"Debe ingresar al menos un producto");
            }

            if (ClientesComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(ClientesComboBox,"Debe seleccionar un cliente");
            }

            if (FechaPedidoDatePicker.Value>DateTime.Now)
            {
                valido = false;
                errorProvider1.SetError(FechaPedidoDatePicker,"La fecha no puede ser superior a la actual");
            }

            return valido;
        }

        private void ClientesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClientesComboBox.SelectedIndex>0)
            {
                cliente = (Cliente) ClientesComboBox.SelectedItem;
                DireccionTextBox.Text = cliente.Direccion;
                PaisTextBox.Text = cliente.Pais.NombrePais;
                CiudadTextBox.Text = cliente.Ciudad.NombreCiudad;
                CodigoPostalTextBox.Text = cliente.CodigoPostal;
            }
            else
            {
                cliente = null;
                InicializarControlesCliente();
            }
        }

        private void InicializarControlesCliente()
        {
            DireccionTextBox.Clear();
            PaisTextBox.Clear();
            CiudadTextBox.Clear();
            CodigoPostalTextBox.Clear();
        }

        public Orden GetOrden()
        {
            return orden;
        }
    }
}
