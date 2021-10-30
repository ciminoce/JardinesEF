using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JardinesEF.Servicios.Facades;
using JardinesEF.Web.Classes;
using JardinesEF.Web.Models.Cliente;
using PagedList;

namespace JardinesEF.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClientesServicios _servicio;
        private readonly IPaisesServicios _servicioPaises;
        private readonly ICiudadesServicios _servicioCiudades;


        private readonly int cantidadPorPagina = 12;

        public ClientesController(IClientesServicios servicio, IPaisesServicios servicioPaises, ICiudadesServicios servicioCiudades)
        {
            _servicio = servicio;
            _servicioPaises = servicioPaises;
            _servicioCiudades = servicioCiudades;
        }
        // GET: Clientes
        public ActionResult Index(int? page=null)
        {
            page = (page ?? 1);
            var lista = _servicio.GetLista();
            var listaVm = Mapeador.ConstruirListaClientesListVm(lista);
            return View(listaVm.ToPagedList((int)page,cantidadPorPagina));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ClienteEditVm clienteVm = new ClienteEditVm()
            {
                Paises = Mapeador.ConstruirListaVm(_servicioPaises.GetLista()),
                Ciudades = Mapeador.ConstruirListaCiudadListVm(_servicioCiudades.GetLista())
            };
            return View(clienteVm);
        }

        [HttpPost]
        public ActionResult Create(ClienteEditVm clienteVm)
        {
            if (!ModelState.IsValid)
            {
                clienteVm.Paises = Mapeador.ConstruirListaVm(_servicioPaises.GetLista());
                clienteVm.Ciudades = Mapeador.ConstruirListaCiudadListVm(_servicioCiudades.GetLista(clienteVm.PaisId));
                return View(clienteVm);
            }

            var cliente = Mapeador.ConstruirCliente(clienteVm);
            try
            {
                if (_servicio.Existe(cliente))
                {
                    ModelState.AddModelError(string.Empty,"Cliente repetido!!!");
                    clienteVm.Paises = Mapeador.ConstruirListaVm(_servicioPaises.GetLista());
                    clienteVm.Ciudades = Mapeador.ConstruirListaCiudadListVm(_servicioCiudades.GetLista(clienteVm.PaisId));
                    return View(clienteVm);

                }
                _servicio.Guardar(cliente);
                TempData["operacion"] = Operacion.Agregar;
                TempData["Msg"] = "Cliente agregado!!!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty,e.Message);
                clienteVm.Paises = Mapeador.ConstruirListaVm(_servicioPaises.GetLista());
                clienteVm.Ciudades = Mapeador.ConstruirListaCiudadListVm(_servicioCiudades.GetLista(clienteVm.PaisId));
                return View(clienteVm);

            }

        }

        public JsonResult GetCities(int paisId)
        {
            //Database.Configuration.ProxyCreationEnabled = false;
            var ciudadesVm = Mapeador.ConstruirListaCiudadListVm(_servicioCiudades.GetLista(paisId));
            return Json(ciudadesVm);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cliente = _servicio.GetEntityPorId(id.Value);
            if (cliente==null)
            {
                return HttpNotFound("Código de cliente inexistente!!!");
            }

            var clienteVm = Mapeador.ConstruirClienteEditVm(cliente);
            clienteVm.Paises = Mapeador.ConstruirListaVm(_servicioPaises.GetLista());
            clienteVm.Ciudades = Mapeador.ConstruirListaCiudadListVm(_servicioCiudades.GetLista(clienteVm.PaisId));
            return View(clienteVm);
        }

        [HttpPost]
        public ActionResult Edit(ClienteEditVm clienteVm)
        {
            if (!ModelState.IsValid)
            {
                clienteVm.Paises = Mapeador.ConstruirListaVm(_servicioPaises.GetLista());
                clienteVm.Ciudades = Mapeador.ConstruirListaCiudadListVm(_servicioCiudades.GetLista(clienteVm.PaisId));
                return View(clienteVm);
            }

            var cliente = Mapeador.ConstruirCliente(clienteVm);
            try
            {
                if (_servicio.Existe(cliente))
                {
                    ModelState.AddModelError(string.Empty,"Cliente existente!!!");
                    clienteVm.Paises = Mapeador.ConstruirListaVm(_servicioPaises.GetLista());
                    clienteVm.Ciudades = Mapeador.ConstruirListaCiudadListVm(_servicioCiudades.GetLista(clienteVm.PaisId));
                    return View(clienteVm);
                }
                _servicio.Guardar(cliente);
                TempData["operacion"] = Operacion.Editar;
                TempData["Msg"] = "Cliente modificado!!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                clienteVm.Paises = Mapeador.ConstruirListaVm(_servicioPaises.GetLista());
                clienteVm.Ciudades = Mapeador.ConstruirListaCiudadListVm(_servicioCiudades.GetLista(clienteVm.PaisId));
                return View(clienteVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cliente = _servicio.GetEntityPorId(id.Value);
            if (cliente == null)
            {
                return new HttpNotFoundResult("Código de Cliente inexistente!!!");
            }

            var clienteVm = Mapeador.ConstruirClienteListVm(cliente);
            return View(clienteVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = _servicio.GetEntityPorId(id);
            if (_servicio.EstaRelacionado(cliente))
            {
                var clienteVm = Mapeador.ConstruirClienteListVm(cliente);
                ModelState.AddModelError(string.Empty, "Cliente relacionado... baja denegada");
                return View(clienteVm);
            }

            try
            {
                _servicio.Borrar(id);
                TempData["operacion"] = Operacion.Borrar;
                TempData["Msg"] = "Cliente Borrado!!!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                var clienteVm = Mapeador.ConstruirClienteListVm(cliente);
                ModelState.AddModelError(string.Empty, e.Message);
                return View(clienteVm);
            }
        }


    }
}
