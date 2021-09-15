using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEF.Datos.Comun;
using JardinesEF.Datos.Comun.Facades;
using JardinesEF.Datos.Sql;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Servicios.Facades;
using System.Transactions;

namespace JardinesEF.Servicios
{
    public class OrdenesServicios:IOrdenesServicios
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrdenesRepositorio _repositorio;

        private readonly IProductosRepositorio _repositorioProductos;
        private readonly IDetalleOrdenesRepositorio _repositorioDetalles;

        public OrdenesServicios(ViveroSqlDbContext context, IUnitOfWork unitOfWork, IOrdenesRepositorio repositorio, IProductosRepositorio repositorioProductos, IDetalleOrdenesRepositorio repositorioDetalles)
        {
            _unitOfWork = unitOfWork;
            _repositorio = repositorio;
            _repositorioProductos = repositorioProductos;
            _repositorioDetalles = repositorioDetalles;
        }


        public List<Orden> GetLista(int registros, int pagina)
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

        public void CancelarReservas(List<DetalleOrden> listaItemsCompra)
        {
            try
            {
                foreach (var detalleOrden in listaItemsCompra)
                {
                    _repositorioProductos.SetearReservarProducto(detalleOrden.ProductoId,-detalleOrden.Cantidad);
                }
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Orden orden)
        {

            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    _repositorio.Guardar(orden);
                    _unitOfWork.Save();//Guardo para obtener el Id de la orden
                    foreach (var item in orden.DetalleOrdenes)
                    {
                        item.OrdenId = orden.OrdenId;
                        _repositorioDetalles.Guardar(item);
                        _repositorioProductos.ActualizarStock(item.ProductoId, item.Cantidad);
                    }
                    _unitOfWork.Save();

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
