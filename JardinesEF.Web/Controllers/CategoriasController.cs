using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JardinesEF.Servicios.Facades;
using JardinesEF.Web.Classes;
using JardinesEF.Web.Models.Categoria;
using JardinesEF.Web.Models.Pais;
using PagedList;

namespace JardinesEF.Web.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriasServicios _servicio;
        private readonly int cantidadPorPagina = 12;
        public CategoriasController(ICategoriasServicios servicio)
        {
            _servicio = servicio;
        }
        // GET: Categorias
        public ActionResult Index(int? page=null)
        {
            page = (page ?? 1);
            var lista = _servicio.GetLista();
            var listaVm = Mapeador.ConstruirListaCategoriasListVm(lista);

            return View(listaVm.ToPagedList((int)page,cantidadPorPagina));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoriaEditVm categoriaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoriaVm);
            }

            var categoria = Mapeador.ConstruirCategoria(categoriaVm);
            try
            {
                if (_servicio.Existe(categoria))
                {
                    ModelState.AddModelError(string.Empty,"Categoría existente!!!");
                    return View(categoriaVm);
                }
                _servicio.Guardar(categoria);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(categoriaVm);

            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            var categoria = _servicio.GetEntityPorId(id.Value);
            if (categoria == null)
            {
                return new HttpNotFoundResult("Código de categoría inexistente!!!");
            }

            var categoriaVm = Mapeador.ConstruirCategoriaEditVm(categoria);
            return View(categoriaVm);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaEditVm categoriaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoriaVm);
            }

            var categoria = Mapeador.ConstruirCategoria(categoriaVm);
            try
            {
                if (_servicio.Existe(categoria))
                {
                    ModelState.AddModelError(string.Empty, "Categoría existente!!!");
                    return View(categoriaVm);
                }
                _servicio.Guardar(categoria);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(categoriaVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categoria = _servicio.GetEntityPorId(id.Value);
            if (categoria == null)
            {
                return new HttpNotFoundResult("Código de Categoría inexistente!!!");
            }

            var categoriaVm = Mapeador.ConstruirCategoriaListVm(categoria);
            return View(categoriaVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var categoria = _servicio.GetEntityPorId(id);
            if (_servicio.EstaRelacionado(categoria))
            {
                var categoriaVm = Mapeador.ConstruirCategoriaListVm(categoria);
                ModelState.AddModelError(string.Empty, "Categoría relacionada... baja denegada");
                return View(categoriaVm);
            }

            try
            {
                _servicio.Borrar(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                var categoriaVm = Mapeador.ConstruirCategoriaListVm(categoria);
                ModelState.AddModelError(string.Empty, e.Message);
                return View(categoriaVm);
            }
        }

    }
}