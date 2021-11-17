using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Servicios.Facades;
using JardinesEF.Web.Classes;
using JardinesEF.Web.Models.Ciudad;
using JardinesEF.Web.Models.Pais;
using Microsoft.Ajax.Utilities;

namespace JardinesEF.Web.Controllers
{
    public class PaisesController : Controller
    {
        private readonly IPaisesServicios _servicio;
        private readonly ICiudadesServicios _servicioCiudades;

        public PaisesController(IPaisesServicios servicio, ICiudadesServicios servicioCiudades)
        {
            _servicio = servicio;
            _servicioCiudades = servicioCiudades;
        }
        // GET: Paises
        public ActionResult Index()
        {
            var listaPaises = _servicio.GetLista();
            var listaPaisVm =Mapeador.ConstruirListaVm(listaPaises);
            foreach (var paisVm in listaPaisVm)
            {
                paisVm.CantidadCiudades = _servicioCiudades.GetCantidad(c => c.PaisId == paisVm.PaisId);
            }
            return View(listaPaisVm);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaisEditVm paisVm)
        {
            if (!ModelState.IsValid)
            {
                return View(paisVm);
            }

            var pais =Mapeador.ConstruirPais(paisVm);

            try
            {
                if (_servicio.Existe(pais))
                {
                    ModelState.AddModelError(string.Empty,"País existente!!!");
                    return View(paisVm);
                }
                _servicio.Guardar(pais);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty,e.Message);
                return View(paisVm);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            var pais = _servicio.GetEntityPorId(id.Value);
            if (pais==null)
            {
                return new HttpNotFoundResult("Código de País inexistente!!!");
            }

            var paisVm =Mapeador.ConstruirPaisEditVm(pais);
            return View(paisVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PaisEditVm paisVm)
        {
            if (!ModelState.IsValid)
            {
                return View(paisVm);
            }

            var pais =Mapeador.ConstruirPais(paisVm);
            try
            {
                if (_servicio.Existe(pais))
                {
                    ModelState.AddModelError(string.Empty,"País existente!!!");
                    return View(paisVm);
                }
                _servicio.Guardar(pais);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(paisVm);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pais = _servicio.GetEntityPorId(id.Value);
            if (pais == null)
            {
                return new HttpNotFoundResult("Código de País inexistente!!!");
            }

            var paisVm =Mapeador.ConstruirPaisVm(pais);
            return View(paisVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pais = _servicio.GetEntityPorId(id);
            if (_servicio.EstaRelacionado(pais))
            {
                var paisVm =Mapeador.ConstruirPaisVm(pais);
                ModelState.AddModelError(string.Empty, "País relacionado... baja denegada");
                return View(paisVm);
            }

            try
            {
                _servicio.Borrar(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                var paisVm =Mapeador.ConstruirPaisVm(pais);
                ModelState.AddModelError(string.Empty, "País relacionado... baja denegada");
                return View(paisVm);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pais = _servicio.GetEntityPorId(id.Value);
            if (pais==null)
            {
                return HttpNotFound("Código de país inexistente!!!");
            }

            var paisVm = Mapeador.ConstruirPaisDetailsVm(pais);
            paisVm.CantidadCiudades = _servicioCiudades.GetCantidad(c => c.PaisId == pais.PaisId);
            paisVm.Ciudades =
                Mapeador.ConstruirListaCiudadListVm(_servicioCiudades.Find(c => c.PaisId == pais.PaisId, null, null));
            return View(paisVm);
        }
        [Authorize]
        public ActionResult AddCity(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pais = _servicio.GetEntityPorId(id.Value);
            if (pais==null)
            {
                return HttpNotFound("Código de país inexistente!!!");
            }

            var ciudadVm = new CiudadEditVm()
            {
                PaisId = pais.PaisId,
                Pais = Mapeador.ConstruirPaisVm(pais)
            };
            return View(ciudadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCity(CiudadEditVm ciudadVm)
        {
            if (!ModelState.IsValid)
            {
                var pais =Mapeador.ConstruirPaisVm(_servicio.GetEntityPorId(ciudadVm.PaisId));
                ciudadVm.Pais = pais;
                return View(ciudadVm);
            }

            var ciudad = Mapeador.ConstruirCiudad(ciudadVm);
            try
            {
                if (_servicioCiudades.Existe(ciudad))
                {
                    var pais = Mapeador.ConstruirPaisVm(_servicio.GetEntityPorId(ciudadVm.PaisId));
                    ciudadVm.Pais = pais;

                    ModelState.AddModelError(string.Empty,"Ciudad existente!!!");
                    return View(ciudadVm);
                }
                _servicioCiudades.Guardar(ciudad);
                return RedirectToAction($"Details/{ciudad.PaisId}");
            }
            catch (Exception e)
            {
                var pais = Mapeador.ConstruirPaisVm(_servicio.GetEntityPorId(ciudadVm.PaisId));
                ciudadVm.Pais = pais;

                ModelState.AddModelError(string.Empty, e.Message);
                return View(ciudadVm);
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCity(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ciudad = _servicioCiudades.GetEntityPorId(id.Value);
            if (ciudad==null)
            {
                return HttpNotFound("Código de ciudad inexistente!!!");
            }

            var ciudadVm = Mapeador.ConstruirCiudadEditVm(ciudad);
            var paisVm = Mapeador.ConstruirPaisVm(_servicio.GetEntityPorId(ciudadVm.PaisId));
            ciudadVm.Pais = paisVm;
            return View(ciudadVm);
        }

        [HttpPost, ActionName("DeleteCity")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCity(int id)
        {
            var ciudad = _servicioCiudades.GetEntityPorId(id);

            try
            {
                if (_servicioCiudades.EstaRelacionado(ciudad))
                {
                    var ciudadVm = Mapeador.ConstruirCiudadEditVm(ciudad);
                    var paisVm = Mapeador.ConstruirPaisVm(_servicio.GetEntityPorId(ciudad.PaisId));
                    ciudadVm.Pais = paisVm;
                    ModelState.AddModelError(string.Empty,"Ciudad con registros relacionados... Baja denegada!!!");
                    return View(ciudadVm);

                }
                _servicioCiudades.Borrar(ciudad.CiudadId);
                return RedirectToAction($"Details/{ciudad.PaisId}");
            }
            catch (Exception e)
            {
                var ciudadVm = Mapeador.ConstruirCiudadEditVm(ciudad);

                var paisVm = Mapeador.ConstruirPaisVm(_servicio.GetEntityPorId(ciudadVm.PaisId));
                ciudadVm.Pais = paisVm;
                ModelState.AddModelError(string.Empty, e.Message);
                return View(ciudadVm);
            }
        }
    }
}