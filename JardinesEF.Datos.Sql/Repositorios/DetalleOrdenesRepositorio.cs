using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEF.Datos.Comun.Facades;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Datos.Sql.Repositorios
{
    public class DetalleOrdenesRepositorio:IDetalleOrdenesRepositorio
    {
        private readonly ViveroSqlDbContext _context;

        public DetalleOrdenesRepositorio(ViveroSqlDbContext context)
        {
            _context = context;
        }
        public List<DetalleOrden> GetLista(int registros, int pagina)
        {
            throw new NotImplementedException();
        }

        public DetalleOrden GetTEntityPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(DetalleOrden detalle)
        {
            try
            {
                _context.DetallesOrdenes.Add(detalle);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(DetalleOrden TEntity)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(DetalleOrden TEntity)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            throw new NotImplementedException();
        }

        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public List<DetalleOrden> GetLista(int OrdenId)
        {
            try
            {
                return _context.DetallesOrdenes
                    .Include(d=>d.Producto)
                    .Where(d => d.OrdenId == OrdenId).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public decimal GetTotal(int OrdenId)
        {
            throw new NotImplementedException();
        }
    }
}
