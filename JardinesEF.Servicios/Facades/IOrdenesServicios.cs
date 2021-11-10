using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Servicios.Facades
{
    public interface IOrdenesServicios
    {
        List<Orden> GetLista(int registros, int pagina);
        int GetCantidad();
        void CancelarReservas(List<DetalleOrden> listaItemsCompra);
        void Guardar(Orden orden);
        List<Orden> GetLista();
    }
}
