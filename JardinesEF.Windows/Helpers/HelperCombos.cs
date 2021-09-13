using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Servicios.Facades;
using JardinesEF.Windows.Ninject;

namespace JardinesEF.Windows.Helpers
{
    public class HelperCombos
    {
        public static void CargarDatosComboPaises(ref ComboBox combo)
        {
            IPaisesServicios servicio = DI.Create<IPaisesServicios>();
            List<Pais> lista = servicio.GetLista();
            var defaultPais = new Pais()
            {
                PaisId = 0,
                NombrePais = "<Seleccione País>"
            };
            lista.Insert(0,defaultPais);
            combo.DataSource = lista;
            combo.DisplayMember = "NombrePais";
            combo.ValueMember = "PaisId";
            combo.SelectedIndex = 0;

        }
        public static void CargarDatosComboCiudades(ref ComboBox combo, int paisId)
        {
            ICiudadesServicios servicio = DI.Create<ICiudadesServicios>();
            List<Ciudad> lista = servicio.Find(c=>c.PaisId==paisId,null,null);
            var defaultCiudad = new Ciudad()
            {
                CiudadId = 0,
                NombreCiudad = "<Seleccione Ciudad>"
            };
            lista.Insert(0, defaultCiudad);
            combo.DataSource = lista;
            combo.DisplayMember = "NombreCiudad";
            combo.ValueMember = "CiudadId";
            combo.SelectedIndex = 0;

        }

        public static void CargarDatosComboCategorias(ref ComboBox combo)
        {
            ICategoriasServicios servicio = DI.Create<ICategoriasServicios>();
            List<Categoria> lista = servicio.GetLista();
            var defaultCategoria = new Categoria()
            {
                CategoriaId = 0,
                NombreCategoria = "<Seleccione Categoría>"
            };
            lista.Insert(0, defaultCategoria);
            combo.DataSource = lista;
            combo.DisplayMember = "NombreCategoria";
            combo.ValueMember = "CategoriaId";
            combo.SelectedIndex = 0;


        }

        public static void CargarDatosComboProveedores(ref ComboBox combo)
        {
            IProveedoresServicios servicio = DI.Create<IProveedoresServicios>();
            List<Proveedor> lista = servicio.GetLista();
            var defaultProveedor = new Proveedor()
            {
                ProveedorId = 0,
                NombreProveedor = "<Seleccione Proveedor>"
            };
            lista.Insert(0, defaultProveedor);
            combo.DataSource = lista;
            combo.DisplayMember = "NombreProveedor";
            combo.ValueMember = "ProveedorId";
            combo.SelectedIndex = 0;
        }

        public static void CargarDatosComboClientes(ref ComboBox combo)
        {
            IClientesServicios servicio = DI.Create<IClientesServicios>();
            List<Cliente> lista = servicio.GetLista();
            var defaultCliente = new Cliente()
            {
                ClienteId = 0,
                Apellido = "<Seleccione Cliente>"
            };
            lista.Insert(0, defaultCliente);
            combo.DataSource = lista;
            combo.DisplayMember = "Apenombre";
            combo.ValueMember = "ClienteId";
            combo.SelectedIndex = 0;
        }

        public static void CargarDatosComboProductos(ref ComboBox combo, int categoriaId)
        {
            IProductosServicios servicio = DI.Create<IProductosServicios>();
            List<Producto> lista = servicio.GetLista(categoriaId);
            var defaultProducto = new Producto()
            {
                ProductoId = 0,
                NombreProducto = "<Seleccione Producto>"
            };
            lista.Insert(0, defaultProducto);
            combo.DataSource = lista;
            combo.DisplayMember = "NombreProducto";
            combo.ValueMember = "ProductoId";
            combo.SelectedIndex = 0;
        }
    }
}
