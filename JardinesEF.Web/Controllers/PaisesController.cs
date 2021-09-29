using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Servicios.Facades;
using JardinesEF.Web.Models.Pais;
using Microsoft.Ajax.Utilities;

namespace JardinesEF.Web.Controllers
{
    public class PaisesController : Controller
    {
        private readonly IPaisesServicios _servicio;

        public PaisesController(IPaisesServicios servicio)
        {
            _servicio = servicio;
        }
        // GET: Paises
        public ActionResult Index()
        {
            var listaPaises = _servicio.GetLista();
            var listaPaisVm = ConstruirListaVm(listaPaises);
            return View(listaPaisVm);
        }

        private List<PaisListVm> ConstruirListaVm(List<Pais> listaPaises)
        {
            var lista = new List<PaisListVm>();
            foreach (var pais in listaPaises)
            {
                var paisVm = ConstruirPaisVm(pais);
                lista.Add(paisVm);
            }

            return lista;
        }

        private PaisListVm ConstruirPaisVm(Pais pais)
        {
            return new PaisListVm()
            {
                PaisId = pais.PaisId,
                NombrePais = pais.NombrePais
            };
        }

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

            var pais = ConstruirPais(paisVm);

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

        private Pais ConstruirPais(PaisEditVm paisVm)
        {
            return new Pais()
            {
                PaisId = paisVm.PaisId,
                NombrePais = paisVm.NombrePais
            };
        }

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

            var paisVm = ConstruirPaisEditVm(pais);
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

            var pais = ConstruirPais(paisVm);
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
                Console.WriteLine(e);
                throw;
            }
        }
        private PaisEditVm ConstruirPaisEditVm(Pais pais)
        {
            return new PaisEditVm()
            {
                PaisId = pais.PaisId,
                NombrePais = pais.NombrePais
            };
        }

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

            var paisVm = ConstruirPaisVm(pais);
            return View(paisVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pais = _servicio.GetEntityPorId(id);
            if (_servicio.EstaRelacionado(pais))
            {
                var paisVm = ConstruirPaisVm(pais);
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
                var paisVm = ConstruirPaisVm(pais);
                ModelState.AddModelError(string.Empty, "País relacionado... baja denegada");
                return View(paisVm);
            }
        }

    }
}