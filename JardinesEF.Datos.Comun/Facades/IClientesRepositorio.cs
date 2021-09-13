using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Datos.Comun.Facades
{
    public interface IClientesRepositorio:IRepositorio<Cliente>
    {
        List<Cliente> GetLista();
        int GetCantidad(Func<Cliente, bool> predicate);
        List<Cliente> Find(Func<Cliente, bool> predicate, int cantidadPorPagina, int paginaActual);
    }
}
