using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Servicios.Facades;
using JardinesEF.Web.Classes;
using JardinesEF.Web.Models.Carrito;
using JardinesEF.Web.Models.Producto;

namespace JardinesEF.Web.Controllers
{
    public class CarritoController : Controller
    {
        private readonly IProductosServicios _servicio;
        private readonly IPaisesServicios _servicioPaises;
        private readonly ICiudadesServicios _servicioCiudades;
        private readonly IClientesServicios _servicioClientes;
        private readonly IOrdenesServicios _servicioOrdnes;

        public CarritoController(IProductosServicios servicio, IPaisesServicios servicioPaises, ICiudadesServicios servicioCiudades, IClientesServicios servicioClientes, IOrdenesServicios servicioOrdnes)
        {
            _servicio = servicio;
            _servicioPaises = servicioPaises;
            _servicioCiudades = servicioCiudades;
            _servicioClientes = servicioClientes;
            _servicioOrdnes = servicioOrdnes;
        }

        // GET: Carrito
        public CarritoController()
        {
        }

        public ViewResult Index(string returnUrl)
        {
            if (GetCart().Items.Any())
            {
                return View(new CarritoViewModel
                {
                    Carrito = GetCart(),
                    ReturnUrl = returnUrl
                });
                
            }
            else
            {
                return View("EmptyCart");
            }
        }

        public RedirectToRouteResult AddToCart(int productoId, string returnUrl)
        {
            ProductoListVm productoVm = Mapeador.ConstruirProductoListVm(_servicio.GetEntityPorId(productoId));

            if (productoVm != null)
            {
                GetCart().AddItem(productoVm, 1);
                _servicio.SetearReservarProducto(productoVm.ProductoId,1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productoId, int cantidad, string returnUrl)
        {
            GetCart().RemoveItem(productoId);
            _servicio.SetearReservarProducto(productoId,-cantidad);
            return RedirectToAction("Index", new { returnUrl });
        }

        private CarritoModel GetCart()
        {
            CarritoModel carrito = (CarritoModel)Session["Carrito"];
            if (carrito == null)
            {
                carrito = new CarritoModel();
                Session["Carrito"] = carrito;
            }
            return carrito;
        }
        public PartialViewResult ResumenCarrito()
        {
            var carrito = GetCart();
            return PartialView(carrito);
        }
        public ActionResult DireccionEnvio()
        {
            var direccionEnvio = new DireccionEnvio();
            direccionEnvio.Paises = Mapeador.ConstruirListaVm(_servicioPaises.GetLista());
            direccionEnvio.Ciudades = Mapeador.ConstruirListaCiudadListVm(_servicioCiudades.GetLista(0));
            return View(direccionEnvio);
        }
        [HttpPost]
        public ActionResult DireccionEnvio(DireccionEnvio info)
        {
            if (ModelState.IsValid)
            {
                CarritoModel carrito = GetCart();
                carrito.DireccionEnvio = info;
                return RedirectToAction("FacturacionInfo");
            }
            else
            {
                info.Paises = Mapeador.ConstruirListaVm(_servicioPaises.GetLista());
                info.Ciudades = Mapeador.ConstruirListaCiudadListVm(_servicioCiudades.GetLista(0));
                return View(info);
            }
        }

        public ActionResult FacturacionInfo()
        {
            FacturacionInfo info = new FacturacionInfo()
            {
                Clientes = Mapeador.ConstruirListaClientesListVm(_servicioClientes.GetLista())
            };
            return View(info);
        }

        [HttpPost]
        public ActionResult FacturacionInfo(FacturacionInfo info)
        {
            if (ModelState.IsValid)
            {
                CarritoModel carrito = GetCart();
                carrito.FacturacionInfo = info;
                //Ver en servicio
                //ProcessOrder(cart);
                try
                {
                    Orden orden = new Orden()
                    {
                        ClienteId = carrito.FacturacionInfo.ClienteId,
                        FechaCompra = DateTime.Now,
                        FechaEntrega = DateTime.Now.AddDays(5),
                        DireccionEnvio = carrito.DireccionEnvio.Direccion,
                        CodigoPostalEnvio = carrito.DireccionEnvio.CodigoPostal,
                        PaisEnvioId = carrito.DireccionEnvio.PaisId,
                        CiudadEnvioId = carrito.DireccionEnvio.CiudadId,
                        DetalleOrdenes = ObtenerDetalleOrdenDelCarrito(carrito)
                    };
                    _servicioOrdnes.Guardar(orden);

                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty,e.Message);
                    info.Clientes = Mapeador.ConstruirListaClientesListVm(_servicioClientes.GetLista());
                    return View(info);
                }
                carrito.Clear();
                return View("OrdenCompleta");
            }
            else
            {
                info.Clientes = Mapeador.ConstruirListaClientesListVm(_servicioClientes.GetLista());

                return View(info);
            }
        }

        private ICollection<DetalleOrden> ObtenerDetalleOrdenDelCarrito(CarritoModel carrito)
        {
            List<DetalleOrden> lista = new List<DetalleOrden>();
            foreach (var carritoItemModel in carrito.Items)
            {
                DetalleOrden detalle = new DetalleOrden()
                {
                    ProductoId = carritoItemModel.Producto.ProductoId,
                    PrecioUnitario = carritoItemModel.Producto.PrecioUnitario,
                    Cantidad = carritoItemModel.Cantidad
                };
                lista.Add(detalle);
            }

            return lista;
        }

        public JsonResult GetCities(int paisId)
        {
            //Database.Configuration.ProxyCreationEnabled = false;
            var ciudadesVm = Mapeador.ConstruirListaCiudadListVm(_servicioCiudades.GetLista(paisId));
            return Json(ciudadesVm);
        }

        public ActionResult CancelOrder()
        {
            var cart = GetCart();
            foreach (var carritoItemModel in cart.Items)
            {
                _servicio.SetearReservarProducto(carritoItemModel.Producto.ProductoId,
                    -carritoItemModel.Cantidad);
            }
            cart.Clear();//Borra el contenido del carrito
            //return RedirectToAction("Index", "Home");
            return View("CancelOrder");
        }
    }
}
