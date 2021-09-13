using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Servicios.Facades
{
    public interface IProveedoresServicios
    {
        List<Proveedor> GetLista(int registros, int pagina);
        List<Proveedor> GetLista();
        Proveedor GetEntityPorId(int id);
        void Guardar(Proveedor proveedor);
        bool Existe(Proveedor proveedor);
        bool EstaRelacionado(Proveedor proveedor);
        int GetCantidad();
        //List<IGrouping<int, Planta>> GetGrupo();
        void Borrar(int id);
        int GetCantidad(Func<Proveedor, bool> predicate);
        List<Proveedor> Find(Func<Proveedor, bool> predicate, int cantidadPorPagina, int paginaActual);
    }
}
