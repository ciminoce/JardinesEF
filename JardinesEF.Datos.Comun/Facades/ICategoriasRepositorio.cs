using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Datos.Comun.Facades
{
    public interface ICategoriasRepositorio:IRepositorio<Categoria>
    {
        List<Categoria> GetLista();
        List<IGrouping<int, Producto>> GetGrupo();
    }
}
