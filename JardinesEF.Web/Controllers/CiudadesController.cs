using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JardinesEF.Servicios.Facades;
using JardinesEF.Web.Classes;
using JardinesEF.Web.Models.Ciudad;

namespace JardinesEF.Web.Controllers
{
    public class CiudadesController : Controller
    {
        private readonly ICiudadesServicios _servicio;
        private readonly IPaisesServicios _servicioPais;

        public CiudadesController(ICiudadesServicios servicio, IPaisesServicios servicioPais)
        {
            _servicio = servicio;
            _servicioPais = servicioPais;
        }

        // GET: Ciudades
        public ActionResult Index()
        {
            var listaCiudades = _servicio.GetLista();
            var listaVm = Mapeador.ConstruirListaCiudadListVm(listaCiudades);
            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var ciudadVm = new CiudadEditVm()
            {
                Paises = Mapeador.ConstruirListaVm(_servicioPais.GetLista())
            };
            return View(ciudadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CiudadEditVm ciudadVm)
        {
            if (!ModelState.IsValid)
            {
                ciudadVm.Paises = Mapeador.ConstruirListaVm(_servicioPais.GetLista());

                return View(ciudadVm);
            }

            var ciudad = Mapeador.ConstruirCiudad(ciudadVm);
            try
            {
                if (_servicio.Existe(ciudad))
                {
                    ciudadVm.Paises = Mapeador.ConstruirListaVm(_servicioPais.GetLista());

                    ModelState.AddModelError(string.Empty,"Ciudad existente!!!");
                    return View(ciudadVm);
                }
                _servicio.Guardar(ciudad);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ciudadVm.Paises = Mapeador.ConstruirListaVm(_servicioPais.GetLista());

                ModelState.AddModelError(string.Empty, e.Message);
                return View(ciudadVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ciudad = _servicio.GetEntityPorId(id.Value);
            if (ciudad==null)
            {
                return HttpNotFound("Código de Ciudad inexistente!!!");
            }

            var ciudadVm = Mapeador.ConstruirCiudadEditVm(ciudad);
            ciudadVm.Paises = Mapeador.ConstruirListaVm(_servicioPais.GetLista());

            return View(ciudadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CiudadEditVm ciudadVm)
        {
            if (!ModelState.IsValid)
            {
                ciudadVm.Paises = Mapeador.ConstruirListaVm(_servicioPais.GetLista());
                return View(ciudadVm);
            }

            var ciudad = Mapeador.ConstruirCiudad(ciudadVm);
            try
            {
                if (_servicio.Existe(ciudad))
                {
                    ModelState.AddModelError(string.Empty,"Ciudad existente!!!!");
                    ciudadVm.Paises = Mapeador.ConstruirListaVm(_servicioPais.GetLista());
                    return View(ciudadVm);
                }
                _servicio.Guardar(ciudad);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ciudad = _servicio.GetEntityPorId(id.Value);
            if (ciudad==null)
            {
                return HttpNotFound("Código de Ciudad inexistente!!!");
            }

            var ciudadVm = Mapeador.ConstruirCiudadListVm(ciudad);
            return View(ciudadVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var ciudad = _servicio.GetEntityPorId(id);
            try
            {
                if (_servicio.EstaRelacionado(ciudad))
                {
                    var ciudadVm = Mapeador.ConstruirCiudadListVm(ciudad);
                    ModelState.AddModelError(string.Empty,"Ciudad con registros relacionados... Baja denegada");
                    return View(ciudadVm);
                }
                _servicio.Borrar(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                var ciudadVm = Mapeador.ConstruirCiudadListVm(ciudad);
                ModelState.AddModelError(string.Empty, e.Message);
                return View(ciudadVm);
            }
        }
    }
}