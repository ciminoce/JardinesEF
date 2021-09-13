using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Datos.Comun.Facades
{
    public interface IDetalleOrdenesRepositorio:IRepositorio<DetalleOrden>
    {
        List<DetalleOrden> GetLista(int OrdenId);
        decimal GetTotal(int OrdenId);
    }
}
