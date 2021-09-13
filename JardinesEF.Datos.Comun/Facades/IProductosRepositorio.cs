using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Datos.Comun.Facades
{
    public interface IProductosRepositorio:IRepositorio<Producto>
    {
        List<Producto> GetLista();
        int GetCantidad(Func<Producto, bool> predicate);
        List<Producto> Find(Func<Producto, bool> predicate, int cantidadPorPagina, int paginaActual);
        List<Producto> GetLista(int categoriaId);
        void SetearReservarProducto(int productoId, int cantidad);
        void ActualizarStock(int productoId, int cantidad);
    }
}
