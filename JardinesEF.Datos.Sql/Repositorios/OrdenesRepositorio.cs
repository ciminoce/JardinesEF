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
    public class OrdenesRepositorio:IOrdenesRepositorio
    {
        private readonly ViveroSqlDbContext _context;

        public OrdenesRepositorio(ViveroSqlDbContext context)
        {
            _context = context;
        }
        public List<Orden> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.Ordenes
                    .Include(o=>o.Cliente)
                    .Include(o=>o.DetalleOrdenes)
                    .OrderBy(o => o.OrdenId)
                    .Skip(registros * (pagina - 1))
                    .Take(registros)
                    .AsNoTracking()
                    .ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Orden GetTEntityPorId(int id)
        {
            try
            {
                return _context.Ordenes
                    .Include(o => o.Cliente)
                    .SingleOrDefault(o => o.OrdenId == id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Orden orden)
        {
            try
            {
                _context.Ordenes.Add(orden);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Orden TEntity)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Orden TEntity)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            try
            {
                return _context.Ordenes.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Orden> GetLista()
        {
            try
            {
                return _context.Ordenes
                    .Include(o => o.Cliente)
                    .Include(o => o.DetalleOrdenes)
                    .OrderBy(o => o.OrdenId)
                    .AsNoTracking()
                    .ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
