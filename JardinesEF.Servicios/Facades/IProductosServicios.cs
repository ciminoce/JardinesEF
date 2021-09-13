using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Servicios.Facades
{
    public interface IProductosServicios
    {
        List<Producto> GetLista(int registros, int pagina);
        List<Producto> GetLista();
        Producto GetEntityPorId(int id);
        void Guardar(Producto producto);
        bool Existe(Producto producto);
        bool EstaRelacionado(Producto producto);
        int GetCantidad();
        //List<IGrouping<int, Planta>> GetGrupo();
        void Borrar(int id);
        int GetCantidad(Func<Producto, bool> predicate);
        List<Producto> Find(Func<Producto, bool> predicate, int cantidadPorPagina, int paginaActual);
        List<Producto> GetLista(int id);
        void SetearReservarProducto(int productoId, int cantidad);
    }
}
