using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Windows.Helpers
{
    public class HelperCalculos
    {
        public static int CalcularCantidadDePaginas(int totalRegistros, int porPagina)
        {
            if (totalRegistros < porPagina)
            {
                return 1;
            }
            if (totalRegistros % porPagina > 0)
            {
                return totalRegistros / porPagina + 1;
            }
            else
            {
                return totalRegistros / porPagina;
            }
        }

        public static decimal CalcularTotal(decimal precio, decimal cantidad)
        {
            return precio * cantidad;
        }

        public static decimal CalcularTotalOrden(ICollection<DetalleOrden> detalleOrdenes)
        {
            return detalleOrdenes.Sum(d => d.PrecioUnitario * d.Cantidad);
        }

    }
}
