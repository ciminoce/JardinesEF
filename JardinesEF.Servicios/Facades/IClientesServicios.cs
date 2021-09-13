using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Servicios.Facades
{
    public interface IClientesServicios
    {
        List<Cliente> GetLista(int registros, int pagina);
        List<Cliente> GetLista();

        Cliente GetEntityPorId(int id);
        void Guardar(Cliente cliente);
        bool Existe(Cliente cliente);
        bool EstaRelacionado(Cliente cliente);
        int GetCantidad();
        //List<IGrouping<int, Planta>> GetGrupo();
        void Borrar(int id);
        int GetCantidad(Func<Cliente, bool> predicate);
        List<Cliente> Find(Func<Cliente, bool> predicate, int cantidadPorPagina, int paginaActual);
    }
}
