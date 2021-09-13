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
    public class ProveedoresServicios:IProveedoresServicios
    {
        private readonly IProveedoresRepositorio _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ProveedoresServicios(IProveedoresRepositorio repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
        }

        public List<Proveedor> GetLista(int registros, int pagina)
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

        public List<Proveedor> GetLista()
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


        public Proveedor GetEntityPorId(int id)
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

        public void Guardar(Proveedor pais)
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

        public bool Existe(Proveedor proveedor)
        {
            try
            {
                return _repositorio.Existe(proveedor);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Proveedor proveedor)
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

        public int GetCantidad(Func<Proveedor, bool> predicate)
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

        public List<Proveedor> Find(Func<Proveedor, bool> predicate, int cantidadPorPagina, int paginaActual)
        {
            try
            {
                return _repositorio.Find(predicate,cantidadPorPagina, paginaActual);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
