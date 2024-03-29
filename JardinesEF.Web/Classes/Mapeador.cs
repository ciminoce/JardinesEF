﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Web;
using System.Web.ModelBinding;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Web.Models.Categoria;
using JardinesEF.Web.Models.Ciudad;
using JardinesEF.Web.Models.Cliente;
using JardinesEF.Web.Models.DetalleOrden;
using JardinesEF.Web.Models.Orden;
using JardinesEF.Web.Models.Pais;
using JardinesEF.Web.Models.Producto;
using JardinesEF.Web.Models.Proveedor;

namespace JardinesEF.Web.Classes
{
    public class Mapeador
    {
        public static PaisEditVm ConstruirPaisEditVm(Pais pais)
        {
            return new PaisEditVm()
            {
                PaisId = pais.PaisId,
                NombrePais = pais.NombrePais
            };
        }

        public static Pais ConstruirPais(PaisEditVm paisVm)
        {
            return new Pais()
            {
                PaisId = paisVm.PaisId,
                NombrePais = paisVm.NombrePais
            };
        }

        public static List<PaisListVm> ConstruirListaVm(List<Pais> listaPaises)
        {
            var lista = new List<PaisListVm>();
            foreach (var pais in listaPaises)
            {
                var paisVm = ConstruirPaisVm(pais);
                lista.Add(paisVm);
            }

            return lista;
        }

        public static PaisListVm ConstruirPaisVm(Pais pais)
        {
            return new PaisListVm()
            {
                PaisId = pais.PaisId,
                NombrePais = pais.NombrePais
            };
        }

        public static List<CiudadListVm> ConstruirListaCiudadListVm(List<Ciudad> listaCiudades)
        {
            var lista = new List<CiudadListVm>();
            foreach (var ciudad in listaCiudades)
            {
                var ciudadVm = ConstruirCiudadListVm(ciudad);
                lista.Add(ciudadVm);
            }

            return lista;
        }

        public static CiudadListVm ConstruirCiudadListVm(Ciudad ciudad)
        {
            return new CiudadListVm()
            {
                CiudadId = ciudad.CiudadId,
                NombreCiudad = ciudad.NombreCiudad,
                NombrePais = ciudad.Pais.NombrePais
            };
        }

        public static Ciudad ConstruirCiudad(CiudadEditVm ciudadVm)
        {
            return new Ciudad()
            {
                CiudadId = ciudadVm.CiudadId,
                NombreCiudad = ciudadVm.NombreCiudad,
                PaisId = ciudadVm.PaisId
            };
        }

        public static CiudadEditVm ConstruirCiudadEditVm(Ciudad ciudad)
        {
            return new CiudadEditVm()
            {
                CiudadId = ciudad.CiudadId,
                NombreCiudad = ciudad.NombreCiudad,
                PaisId = ciudad.PaisId
            };
        }

        public static PaisDetailsVm ConstruirPaisDetailsVm(Pais pais)
        {
            return new PaisDetailsVm()
            {
                PaisId = pais.PaisId,
                NombrePais = pais.NombrePais
            };
        }

        public static List<CategoriaListVm> ConstruirListaCategoriasListVm(List<Categoria> lista)
        {
            var listaVm = new List<CategoriaListVm>();
            foreach (var categoria in lista)
            {
                var categoriaVm = ConstruirCategoriaListVm(categoria);
                listaVm.Add(categoriaVm);
            }

            return listaVm;
        }

        public static CategoriaListVm ConstruirCategoriaListVm(Categoria categoria)
        {
            return new CategoriaListVm()
            {
                CategoriaId = categoria.CategoriaId,
                NombreCategoria = categoria.NombreCategoria
            };
        }

        public static Categoria ConstruirCategoria(CategoriaEditVm categoriaVm)
        {
            return new Categoria()
            {
                CategoriaId = categoriaVm.CategoriaId,
                NombreCategoria = categoriaVm.NombreCategoria,
                Descripcion = categoriaVm.Descripcion
            };
        }

        public static CategoriaEditVm ConstruirCategoriaEditVm(Categoria categoria)
        {
            return new CategoriaEditVm()
            {
                CategoriaId = categoria.CategoriaId,
                NombreCategoria = categoria.NombreCategoria,
                Descripcion = categoria.Descripcion
            };
        }

        public static List<ProductoListVm> ConstruirListaProductoListVm(List<Producto> lista)
        {
            var listaVm = new List<ProductoListVm>();
            foreach (var producto in lista)
            {
                var productoVm =Mapeador.ConstruirProductoListVm(producto);
                listaVm.Add(productoVm);
            }

            return listaVm;
        }

        public static ProductoListVm ConstruirProductoListVm(Producto producto)
        {
            return new ProductoListVm()
            {
                ProductoId = producto.ProductoId,
                NombreProducto = producto.NombreProducto,
                Categoria = producto.Categoria.NombreCategoria,
                StockDisponible = producto.UnidadesEnStock-producto.UnidadesEnPedido,
                PrecioUnitario = producto.PrecioUnitario,
                Suspendido = producto.Suspendido,
                Imagen = producto.Imagen
            };
        }

        public static List<ProveedorComboVm> ConstruirListaComboProveedores(List<Proveedor> lista)
        {
            var listaVm = new List<ProveedorComboVm>();
            foreach (var proveedor in lista)
            {
                var proveedorVm = Mapeador.ConstruirProveedorCombo(proveedor);
                listaVm.Add(proveedorVm);
            }

            return listaVm;
        }

        private static ProveedorComboVm ConstruirProveedorCombo(Proveedor proveedor)
        {
            return new ProveedorComboVm()
            {
                ProveedorId = proveedor.ProveedorId,
                NombreProveedor = proveedor.NombreProveedor
            };
        }

        public static Producto ConstruirProducto(ProductoEditVm productoVm)
        {
            return new Producto()
            {
                ProductoId = productoVm.ProductoId,
                NombreProducto = productoVm.NombreProducto,
                NombreLatin = productoVm.NombreLatin,
                CategoriaId = productoVm.CategoriaId,
                ProveedorId = productoVm.ProveedorId,
                NivelDeReposicion = productoVm.NivelDeReposicion,
                UnidadesEnStock = productoVm.UnidadesEnStock,
                Suspendido = productoVm.Suspendido,
                PrecioUnitario = productoVm.PrecioUnitario,
                Imagen = productoVm.Imagen

            };
        }
        public static ProductoEditVm ConstruirProductoEditVm(Producto producto)
        {
            return new ProductoEditVm()
            {
                ProductoId = producto.ProductoId,
                NombreProducto = producto.NombreProducto,
                NombreLatin = producto.NombreLatin,
                CategoriaId = producto.CategoriaId,
                ProveedorId = producto.ProveedorId,
                NivelDeReposicion = producto.NivelDeReposicion,
                UnidadesEnStock = producto.UnidadesEnStock,
                Suspendido = producto.Suspendido,
                PrecioUnitario = producto.PrecioUnitario,
                Imagen = producto.Imagen

            };
        }

        public static List<ClienteListVm> ConstruirListaClientesListVm(List<Cliente> lista)
        {
            var listaVm = new List<ClienteListVm>();
            foreach (var cliente in lista)
            {
                var clienteVm = ConstruirClienteListVm(cliente);
                listaVm.Add(clienteVm);
            }

            return listaVm;

        }

        public static ClienteListVm ConstruirClienteListVm(Cliente cliente)
        {
            return new ClienteListVm()
            {
                ClienteId = cliente.ClienteId,
                Nombres = cliente.Nombres,
                Apellido = cliente.Apellido,
                Pais = cliente.Pais.NombrePais,
                Ciudad = cliente.Ciudad.NombreCiudad
            };
        }

        public static Cliente ConstruirCliente(ClienteEditVm clienteVm)
        {
            return new Cliente()
            {
                ClienteId = clienteVm.ClienteId,
                Nombres = clienteVm.Nombres,
                Apellido = clienteVm.Apellido,
                Direccion = clienteVm.Direccion,
                CodigoPostal = clienteVm.CodigoPostal,
                PaisId = clienteVm.PaisId,
                CiudadId = clienteVm.CiudadId
            };
        }

        public static ClienteEditVm ConstruirClienteEditVm(Cliente cliente)
        {
            return new ClienteEditVm()
            {
                ClienteId = cliente.ClienteId,
                Nombres = cliente.Nombres,
                Apellido = cliente.Apellido,
                Direccion = cliente.Direccion,
                CodigoPostal = cliente.CodigoPostal,
                PaisId = cliente.PaisId,
                CiudadId = cliente.CiudadId

            };
        }

        public static List<OrdenListVm> ConstruirListaOrdenesListVm(List<Orden> lista)
        {
            List<OrdenListVm> listaVm = new List<OrdenListVm>();
            foreach (var orden in lista)
            {
                var ordenVm = new OrdenListVm()
                {
                    Cliente = orden.Cliente.ApeNombre,
                    FechaCompra = orden.FechaCompra,
                    FechaEntrega = orden.FechaEntrega,
                    OrdenId = orden.OrdenId
                };
                listaVm.Add(ordenVm);
            }

            return listaVm;
        }

        public static OrdenDetailsVm ConstruirOrdenDetailsVm(Orden orden)
        {
            return new OrdenDetailsVm()
            {
                OrdenId = orden.OrdenId,
                Cliente = orden.Cliente.ApeNombre,
                DireccionEnvio = orden.DireccionEnvio,
                CodigoPostalEnvio = orden.CodigoPostalEnvio,
                Ciudad = orden.Ciudad.NombreCiudad,
                Pais = orden.Pais.NombrePais,
                FechaCompra = orden.FechaCompra,
                FechaEntrega = orden.FechaEntrega,
                DetalleOrdenes = ConstruirListaDetalleOrdenListVm(orden.DetalleOrdenes)
            };
        }

        private static List<DetalleOrdenListVm> ConstruirListaDetalleOrdenListVm(ICollection<DetalleOrden> detalleOrden)
        {
            List<DetalleOrdenListVm> lista = new List<DetalleOrdenListVm>();
            foreach (var item in detalleOrden)
            {
                DetalleOrdenListVm itemVm = ConstruirDetalleOrdenListVm(item);
                lista.Add(itemVm);
            }

            return lista;
        }

        private static DetalleOrdenListVm ConstruirDetalleOrdenListVm(DetalleOrden item)
        {
            return new DetalleOrdenListVm()
            {
                Producto = item.Producto.NombreProducto,
                Cantidad = item.Cantidad,
                PrecioUnitario = item.PrecioUnitario
            };
        }
    }
}