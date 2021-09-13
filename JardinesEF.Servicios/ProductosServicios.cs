using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEF.Datos.Comun;
using JardinesEF.Datos.Comun.Facades;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Servicios.Facades;

namespace JardinesEF.Servicios
{
    public class ProductosServicios:IProductosServicios
    {
        private readonly IProductosRepositorio _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ProductosServicios(IProductosRepositorio repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
        }

        public List<Producto> GetLista(int registros, int pagina)
        {
            try
            {
                return _repositorio.GetLista(registros, pagina);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Producto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public Producto GetEntityPorId(int id)
        {
            try
            {
                return _repositorio.GetTEntityPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Producto pais)
        {
            try
            {
                _repositorio.Guardar(pais);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Producto producto)
        {
            try
            {
                return _repositorio.Existe(producto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Producto producto)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            try
            {
                return _repositorio.GetCantidad();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //public List<IGrouping<int, Planta>> GetGrupo()
        //{
        //    try
        //    {
        //        return _repositorio.GetGrupos();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        public void Borrar(int id)
        {
            try
            {
                _repositorio.Borrar(id);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public int GetCantidad(Func<Producto, bool> predicate)
        {
            try
            {
                return _repositorio.GetCantidad(predicate);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Producto> Find(Func<Producto, bool> predicate, int cantidadPorPagina, int paginaActual)
        {
            try
            {
                return _repositorio.Find(predicate, cantidadPorPagina, paginaActual);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Producto> GetLista(int categoriaId)
        {
            try
            {
                return _repositorio.GetLista(categoriaId);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void SetearReservarProducto(int productoId, int cantidad)
        {
            try
            {
                _repositorio.SetearReservarProducto(productoId, cantidad);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
