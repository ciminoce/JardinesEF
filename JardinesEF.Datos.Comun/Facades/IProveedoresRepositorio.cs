using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Datos.Comun.Facades
{
    public interface IProveedoresRepositorio:IRepositorio<Proveedor>
    {
        List<Proveedor> GetLista();
        int GetCantidad(Func<Proveedor, bool> predicate);
        List<Proveedor> Find(Func<Proveedor, bool> predicate, int cantidadPorPagina, int paginaActual);
    }
}
