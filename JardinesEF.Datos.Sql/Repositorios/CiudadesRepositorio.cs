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
    public class CiudadesRepositorio:ICiudadesRepositorio
    {
        private readonly ViveroSqlDbContext _context;

        public CiudadesRepositorio(ViveroSqlDbContext context)
        {
            _context = context;
        }
        public List<Ciudad> GetLista(int cantidad, int pagina)
        {
            try
            {
                return _context.Ciudades
                    .Include(c=>c.Pais)
                    .OrderBy(p => p.NombreCiudad)
                    .Skip(cantidad * (pagina - 1))
                    .Take(cantidad)
                    .AsNoTracking()
                    .ToList();

            }
            catch (Exception e)
            {

                throw new Exception("Error al leer");

            }

        }

        public Ciudad GetTEntityPorId(int id)
        {
            try
            {
                return _context.Ciudades.SingleOrDefault(p => p.CiudadId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public void Guardar(Ciudad ciudad)
        {
            try
            {
                _context.Paises.Attach(ciudad.Pais);

                if (ciudad.CiudadId == 0)
                {
                    //Cuando el id=0 entonces la entidad es nueva ==>alta
                    _context.Ciudades.Add(ciudad);

                }
                else
                {
                    var ciudadInDb =
                        _context.Ciudades.SingleOrDefault(p => p.CiudadId == ciudad.CiudadId);
                    if (ciudadInDb == null)
                    {
                        throw new Exception("Ciudad inexistente");
                    }

                    ciudadInDb.NombreCiudad = ciudad.NombreCiudad;
                    ciudadInDb.PaisId = ciudad.PaisId;
                    _context.Entry(ciudadInDb).State = EntityState.Modified;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }

        public bool Existe(Ciudad ciudad)
        {
            try
            {
                if (ciudad.CiudadId == 0)
                {
                    return _context.Ciudades.Any(c => c.NombreCiudad == ciudad.NombreCiudad && 
                                                      c.PaisId==ciudad.PaisId);
                }

                return _context.Ciudades.Any(c => c.NombreCiudad == ciudad.NombreCiudad
                                                  && c.PaisId==ciudad.PaisId
                                                         && c.CiudadId != ciudad.CiudadId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Ciudad TEntity)
        {
            throw new NotImplementedException();
        }


        public int GetCantidad()
        {
            try
            {
                return _context.Ciudades.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int id)
        {
            Ciudad ciudadInDb = null;
            try
            {
                ciudadInDb = _context.Ciudades
                    .SingleOrDefault(p => p.CiudadId == id);
                if (ciudadInDb == null) return;
                _context.Entry(ciudadInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception e)
            {
                _context.Entry(ciudadInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        //public List<Ciudad> Find(Func<Ciudad, bool> predicate)
        //{
        //    try
        //    {
        //        return _context.Ciudades
        //            .OrderBy(c=>c.NombreCiudad)
        //            .Where(predicate)
        //            .ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public List<Ciudad> Find(Func<Ciudad, bool> predicate, int registros, int pagina)
        //{
        //    try
        //    {
        //        return _context.Ciudades
        //            .Where(predicate)
        //            .OrderBy(c=>c.NombreCiudad)
        //            .Skip(registros * (pagina-1))
        //            .Take(registros)
        //            .ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        public List<Ciudad> Find(Func<Ciudad, bool> predicate, int? cantidad, int? pagina)
        {
            try
            {
                IEnumerable<Ciudad> query= _context.Ciudades
                    .Include(c => c.Pais).AsEnumerable()
                    .Where(predicate)
                    .OrderBy(p => p.NombreCiudad);
                if (cantidad.HasValue && pagina.HasValue)
                {
                    query = query.Skip(cantidad.Value * (pagina.Value - 1))
                        .Take(cantidad.Value);
                }
                return query.ToList();
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
                return _context.Ciudades.Count(predicate);
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer la tabla de Ciudades");
            }
        }

        //public List<Ciudad> GetLista(Func<Ciudad, bool> func, int cantidad, int pagina)
        //{
        //    try
        //    {
        //        return _context.Ciudades
        //            .Include(c => c.Pais).AsEnumerable()
        //            .Where(func)
        //            .OrderBy(p => p.NombreCiudad)
        //            .Skip(cantidad * (pagina - 1))
        //            .Take(cantidad)
        //            .ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
    }
}
