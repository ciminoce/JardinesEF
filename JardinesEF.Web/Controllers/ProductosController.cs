using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Servicios.Facades;
using JardinesEF.Web.Classes;
using JardinesEF.Web.Models.Producto;
using PagedList;

namespace JardinesEF.Web.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        private readonly IProductosServicios _servicio;
        private readonly IProveedoresServicios _servicioProveedores;
        private readonly ICategoriasServicios _servicioCategorias;
        private readonly string folder = "~/Content/Imagenes/Productos/";
        public ProductosController(IProductosServicios servicio, IProveedoresServicios servicioProveedores, ICategoriasServicios servicioCategorias)
        {
            _servicio = servicio;
            _servicioProveedores = servicioProveedores;
            _servicioCategorias = servicioCategorias;
        }

        private readonly int cantidadPorPagina = 12;

        public ActionResult Index(int? categoriaSeleccionadaId=null,int? page=null)
        {
            page = (page ?? 1);
            if (categoriaSeleccionadaId != null)
            {
                Session["categoriaSeleccionadaId"] = categoriaSeleccionadaId;
            }
            else
            {
                if (Session["categoriaSeleccionadaId"] != null)
                {
                    categoriaSeleccionadaId = (int)Session["categoriaSeleccionadaId"];
                }
            }


            List<Producto> lista;
            if (categoriaSeleccionadaId!=null)
            {
                if (categoriaSeleccionadaId.Value>0)
                {
                    lista = _servicio.GetLista(categoriaSeleccionadaId.Value);
                }
                else
                {
                    lista = _servicio.GetLista();
                }
            }
            else
            {
                lista = _servicio.GetLista();
                
            }
            var listaVm = Mapeador.ConstruirListaProductoListVm(lista);
            var listaCategorias = _servicioCategorias.GetLista();
            listaCategorias.Insert(0, new Categoria() { CategoriaId = 0, NombreCategoria = "[Seleccione una Categoría]" });
            listaCategorias.Insert(1, new Categoria() { CategoriaId = -1, NombreCategoria = "[Ver Todos]" });

            ViewBag.Categorias = new SelectList(listaCategorias, "CategoriaId", "NombreCategoria", categoriaSeleccionadaId);

            return View(listaVm.ToPagedList((int)page,cantidadPorPagina));
        }

        public ActionResult Create()
        {
            var productoVm = new ProductoEditVm()
            {
                Proveedores = Mapeador.ConstruirListaComboProveedores(_servicioProveedores.GetLista()),
                Categorias = Mapeador.ConstruirListaCategoriasListVm(_servicioCategorias.GetLista()),
                Imagen = "SinImagenDisponible.jpg"
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
                productoVm.Imagen = "SinImagenDisponible.jpg";

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
                    productoVm.Imagen = "SinImagenDisponible.jpg";

                    return View(productoVm);

                }
                if (productoVm.ImagenFile != null)
                {
                    producto.Imagen = $"{productoVm.ImagenFile.FileName}";
                }

                _servicio.Guardar(producto);
                if (productoVm.ImagenFile != null)
                {
                    var file = $"{productoVm.ImagenFile.FileName}";
                    var response = FileHelper.UploadPhoto(productoVm.ImagenFile, folder, file);
                }


                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                productoVm.Proveedores = Mapeador.ConstruirListaComboProveedores(_servicioProveedores.GetLista());
                productoVm.Categorias = Mapeador.ConstruirListaCategoriasListVm(_servicioCategorias.GetLista());
                productoVm.Imagen = "SinImagenDisponible.jpg";

                return View(productoVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Producto producto = _servicio.GetEntityPorId(id.Value);
            if (producto == null)
            {
                return HttpNotFound("Código de producto no encontrado!!!");
            }

            var productoVm = Mapeador.ConstruirProductoEditVm(producto);

            productoVm.Categorias = Mapeador.ConstruirListaCategoriasListVm(_servicioCategorias.GetLista());
            productoVm.Proveedores = Mapeador.ConstruirListaComboProveedores(_servicioProveedores.GetLista());
            if (productoVm.Imagen ==null)
            {
                productoVm.Imagen = "SinImagenDisponible.jpg";
            }
            return View(productoVm);
        }

        [HttpPost]
        public ActionResult Edit(ProductoEditVm productoVm)
        {
            if (!ModelState.IsValid)
            {
                productoVm.Categorias = Mapeador.ConstruirListaCategoriasListVm(_servicioCategorias.GetLista());
                productoVm.Proveedores = Mapeador.ConstruirListaComboProveedores(_servicioProveedores.GetLista());
                if (productoVm.Imagen == null)
                {
                    productoVm.Imagen = "SinImagenDisponible.jpg";
                }

                return View(productoVm);
            }

            Producto producto = Mapeador.ConstruirProducto(productoVm);
            try
            {
                if (_servicio.Existe(producto))
                {
                    ModelState.AddModelError(string.Empty,"Producto repetido!!!");
                    productoVm.Categorias = Mapeador.ConstruirListaCategoriasListVm(_servicioCategorias.GetLista());
                    productoVm.Proveedores = Mapeador.ConstruirListaComboProveedores(_servicioProveedores.GetLista());
                    if (productoVm.Imagen == null)
                    {
                        productoVm.Imagen = "SinImagenDisponible.jpg";
                    }

                    return View(productoVm);
                }
                if (productoVm.ImagenFile != null)
                {
                    producto.Imagen = $"{productoVm.ImagenFile.FileName}";
                }

                _servicio.Guardar(producto);
                if (productoVm.ImagenFile != null)
                {
                    var file = $"{productoVm.ImagenFile.FileName}";
                    var response = FileHelper.UploadPhoto(productoVm.ImagenFile, folder, file);
                }

                TempData["operacion"] = Operacion.Editar;
                TempData["Msg"] = "Producto Editado!!!";
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty,e.Message);
                productoVm.Categorias = Mapeador.ConstruirListaCategoriasListVm(_servicioCategorias.GetLista());
                productoVm.Proveedores = Mapeador.ConstruirListaComboProveedores(_servicioProveedores.GetLista());
                if (productoVm.Imagen == null)
                {
                    productoVm.Imagen = "SinImagenDisponible.jpg";
                }

                return View(productoVm);
            }
        }
    }
}