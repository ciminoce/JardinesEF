using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Servicios.Facades;
using JardinesEF.Web.Classes;
using JardinesEF.Web.Models.Producto;

namespace JardinesEF.Web.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        private readonly IProductosServicios _servicio;
        private readonly IProveedoresServicios _servicioProveedores;
        private readonly ICategoriasServicios _servicioCategorias;

        public ProductosController(IProductosServicios servicio, IProveedoresServicios servicioProveedores, ICategoriasServicios servicioCategorias)
        {
            _servicio = servicio;
            _servicioProveedores = servicioProveedores;
            _servicioCategorias = servicioCategorias;
        }


        public ActionResult Index()
        {
            var lista = _servicio.GetLista();
            var listaVm = Mapeador.ConstruirListaProductoListVm(lista);
            return View(listaVm);
        }

        public ActionResult Create()
        {
            var productoVm = new ProductoEditVm()
            {
                Proveedores = Mapeador.ConstruirListaComboProveedores(_servicioProveedores.GetLista()),
                Categorias = Mapeador.ConstruirListaCategoriasListVm(_servicioCategorias.GetLista())
            };
            return View(productoVm);
        }

        [HttpPost]
        public ActionResult Create(ProductoEditVm productoVm)
        {
            if (!ModelState.IsValid)
            {
                productoVm.Proveedores = Mapeador.ConstruirListaComboProveedores(_servicioProveedores.GetLista());
                productoVm.Categorias = Mapeador.ConstruirListaCategoriasListVm(_servicioCategorias.GetLista());

                return View(productoVm);
            }

            Producto producto = Mapeador.ConstruirProducto(productoVm);
            try
            {
                if (_servicio.Existe(producto))
                {
                    ModelState.AddModelError(string.Empty,"Producto existente!!!");
                    productoVm.Proveedores = Mapeador.ConstruirListaComboProveedores(_servicioProveedores.GetLista());
                    productoVm.Categorias = Mapeador.ConstruirListaCategoriasListVm(_servicioCategorias.GetLista());

                    return View(productoVm);

                }
                _servicio.Guardar(producto);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                productoVm.Proveedores = Mapeador.ConstruirListaComboProveedores(_servicioProveedores.GetLista());
                productoVm.Categorias = Mapeador.ConstruirListaCategoriasListVm(_servicioCategorias.GetLista());

                return View(productoVm);
            }
        }
    }
}