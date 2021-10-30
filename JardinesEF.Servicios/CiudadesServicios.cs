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
    public class CiudadesServicios:ICiudadesServicios
    {
        private readonly ICiudadesRepositorio _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public CiudadesServicios(ICiudadesRepositorio repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
        }

        public List<Ciudad> Find(Func<Ciudad, bool> predicate, int? registros, int? pagina)
        {
            try
            {
                return _repositorio.Find(predicate,registros, pagina);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //public List<Ciudad> Find(Func<Ciudad, bool> predicate)
        //{
        //    try
        //    {
        //        return _repositorio.Find(predicate);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        public List<Ciudad> GetLista(int registros, int pagina)
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


        public Ciudad GetEntityPorId(int id)
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

        public void Guardar(Ciudad ciudad)
        {
            try
            {
                _repositorio.Guardar(ciudad);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Ciudad ciudad)
        {
            try
            {
                return _repositorio.Existe(ciudad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Ciudad ciudad)
        {
            try
            {
                return _repositorio.EstaRelacionado(ciudad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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

        public int GetCantidad(Func<Ciudad, bool> predicate)
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

        public List<Ciudad> GetLista()
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

        public List<Ciudad> GetLista(int paisId)
        {
            try
            {
                return _repositorio.GetLista(paisId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
