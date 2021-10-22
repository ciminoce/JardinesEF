using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}