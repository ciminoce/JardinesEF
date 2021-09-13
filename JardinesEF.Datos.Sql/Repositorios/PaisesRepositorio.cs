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
    public class PaisesRepositorio:IPaisesRepositorio
    {
        private readonly ViveroSqlDbContext _context;

        public PaisesRepositorio(ViveroSqlDbContext context)
        {
            _context = context;
        }
        public List<Pais> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.Paises
                    .OrderBy(p => p.NombrePais)
                    .AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }

        }

        public Pais GetTEntityPorId(int id)
        {
            try
            {
                return _context.Paises.SingleOrDefault(p => p.PaisId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public void Guardar(Pais pais)
        {
            try
            {
                if (pais.PaisId == 0)
                {
                    //Cuando el id=0 entonces la entidad es nueva ==>alta
                    _context.Paises.Add(pais);
                }
                else
                {
                    var paisInDb =
                        _context.Paises.SingleOrDefault(p => p.PaisId == pais.PaisId);
                    if (paisInDb == null)
                    {
                        throw new Exception("País inexistente");
                    }
                    paisInDb.NombrePais = pais.NombrePais;
                    _context.Entry(paisInDb).State = EntityState.Modified;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }

        public bool Existe(Pais pais)
        {
            try
            {
                if (pais.PaisId == 0)
                {
                    return _context.Paises.Any(p =>p.NombrePais == pais.NombrePais);
                }

                return _context.Paises.Any(p => p.NombrePais == pais.NombrePais
                                                         && p.PaisId != pais.PaisId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Pais pais)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            try
            {
                return _context.Paises.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int id)
        {
            Pais paisInDb = null;
            try
            {
                paisInDb = _context.Paises
                    .SingleOrDefault(p => p.PaisId == id);
                if (paisInDb == null) return;
                _context.Entry(paisInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception e)
            {
                _context.Entry(paisInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        public List<Pais> GetLista()
        {
            try
            {
                return _context.Paises.OrderBy(p => p.NombrePais).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<IGrouping<int, Ciudad>> GetGrupos()
        {
            try
            {
                return _context.Ciudades.GroupBy(c => c.PaisId).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
