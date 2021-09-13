using System.Collections.Generic;
using System.Linq;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Servicios.Facades
{
    public interface IPaisesServicios
    {
        List<Pais> GetLista(int registros, int pagina);
        List<Pais> GetLista();
        Pais GetEntityPorId(int id);
        void Guardar(Pais pais);
        bool Existe(Pais pais);
        bool EstaRelacionado(Pais pais);
        int GetCantidad();
        void Borrar(int id);
        List<IGrouping<int, Ciudad>> GetGrupos();
    }
}