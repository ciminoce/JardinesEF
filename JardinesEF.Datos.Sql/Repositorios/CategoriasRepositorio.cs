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
    public class CategoriasRepositorio:ICategoriasRepositorio
    {
        private readonly ViveroSqlDbContext _context;

        public CategoriasRepositorio(ViveroSqlDbContext context)
        {
            _context = context;
        }
        public List<Categoria> GetLista(int cantidad, int pagina)
        {
            try
            {
                return _context.Categorias
                    .OrderBy(p => p.NombreCategoria)
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

        public Categoria GetTEntityPorId(int id)
        {
            try
            {
                return _context.Categorias.SingleOrDefault(p => p.CategoriaId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public void Guardar(Categoria categoria)
        {
            try
            {
                if (categoria.CategoriaId == 0)
                {
                    //Cuando el id=0 entonces la entidad es nueva ==>alta
                    _context.Categorias.Add(categoria);

                }
                else
                {
                    var categoriaInDb =
                        _context.Categorias.SingleOrDefault(p => p.CategoriaId == categoria.CategoriaId);
                    if (categoriaInDb == null)
                    {
                        throw new Exception("Categoría inexistente");
                    }

                    categoriaInDb.NombreCategoria = categoria.NombreCategoria;
                    _context.Entry(categoriaInDb).State = EntityState.Modified;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }

        public bool Existe(Categoria categoria)
        {
            try
            {
                if (categoria.CategoriaId == 0)
                {
                    return _context.Categorias.Any(p => p.NombreCategoria == categoria.NombreCategoria);
                }

                return _context.Categorias.Any(p => p.NombreCategoria == categoria.NombreCategoria
                                                         && p.CategoriaId != categoria.CategoriaId);
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
                return _context.Productos.Any(p => p.CategoriaId == categoria.CategoriaId);
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
                return _context.Categorias.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int id)
        {
            Categoria categoriaInDb = null;
            try
            {
                categoriaInDb = _context.Categorias
                    .SingleOrDefault(p => p.CategoriaId == id);
                if (categoriaInDb == null) return;
                _context.Entry(categoriaInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception e)
            {
                _context.Entry(categoriaInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        public List<Categoria> GetLista()
        {
            try
            {
                return _context.Categorias
                    .OrderBy(p => p.NombreCategoria)
                    .AsNoTracking()
                    .ToList();

            }
            catch (Exception e)
            {

                throw new Exception("Error al leer");

            }
        }

        public List<IGrouping<int, Producto>> GetGrupo()
        {
            try
            {
                return _context.Productos.GroupBy(p => p.CategoriaId).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
