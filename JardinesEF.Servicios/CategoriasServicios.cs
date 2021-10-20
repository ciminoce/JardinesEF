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
    public class CategoriasServicios:ICategoriasServicios
    {
        private readonly ICategoriasRepositorio _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriasServicios(ICategoriasRepositorio repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
        }

        public List<Categoria> GetLista(int registros, int pagina)
        {
            try
            {
                return _repositorio.GetLista(registros,pagina);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public Categoria GetEntityPorId(int id)
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

        public void Guardar(Categoria pais)
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

        public bool Existe(Categoria categoria)
        {
            try
            {
                return _repositorio.Existe(categoria);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Categoria categoria)
        {
            try
            {
                return _repositorio.EstaRelacionado(categoria);
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

        public List<IGrouping<int, Producto>> GetGrupo()
        {
            try
            {
                return _repositorio.GetGrupo();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

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

        public List<Categoria> GetLista()
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
    }
}
