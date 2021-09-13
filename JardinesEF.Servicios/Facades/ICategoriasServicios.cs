using System.Collections.Generic;
using System.Linq;
using JardinesEF.Datos.Comun.Facades;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Servicios.Facades
{
    public interface ICategoriasServicios
    {
        List<Categoria> GetLista(int registros, int pagina);
        Categoria GetEntityPorId(int id);
        void Guardar(Categoria categoria);
        bool Existe(Categoria categoria);
        bool EstaRelacionado(Categoria categoria);
        int GetCantidad();
        List<IGrouping<int, Producto>> GetGrupo();
        void Borrar(int id);
        List<Categoria> GetLista();
       
    }
}
