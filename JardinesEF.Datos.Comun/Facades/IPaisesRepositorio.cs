using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Datos.Comun.Facades
{
    public interface IPaisesRepositorio:IRepositorio<Pais>
    {
        List<Pais> GetLista();

        List<IGrouping<int, Ciudad>> GetGrupos();
    }
}
