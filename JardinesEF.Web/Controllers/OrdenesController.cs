using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Servicios.Facades;
using JardinesEF.Web.Classes;
using JardinesEF.Web.Models.Orden;
using PagedList;

namespace JardinesEF.Web.Controllers
{
    public class OrdenesController : Controller
    {
        private readonly IOrdenesServicios _servicios;
        private readonly int cantidadPorPagina = 12;

        public OrdenesController(IOrdenesServicios servicios)
        {
            _servicios = servicios;
        }
        // GET: Ordenes
        public ActionResult Index(int?page)
        {
            page = (page ?? 1);
            var lista = _servicios.GetLista();
            var listaVm = Mapeador.ConstruirListaOrdenesListVm(lista);
            return View(listaVm.ToPagedList((int)page,cantidadPorPagina));
        }

        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Orden orden = _servicios.GetOrdenPorId(id.Value);
            if (orden==null)
            {
                return HttpNotFound("Código de Venta no encontrado!!!");
            }
            OrdenDetailsVm ordenVm = Mapeador.ConstruirOrdenDetailsVm(orden);
            return View(ordenVm);
        }
    }
}