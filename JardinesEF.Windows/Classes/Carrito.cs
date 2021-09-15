using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Windows.Classes
{
    public class Carrito
    {
        public static Carrito instancia;

        public static Carrito GetInstancia()
        {
            if (instancia==null)
            {
                instancia = new Carrito();
            }

            return instancia;
        }

        public List<DetalleOrden> listaItemsCompra { get; set; } = new List<DetalleOrden>();
        private Carrito(){}

        public bool ExisteDetalleOrden(DetalleOrden detalleOrden)
        {

            return listaItemsCompra.Any(i => i.ProductoId == detalleOrden.ProductoId);
        }

        public int GetCantidadItems()
        {
            return listaItemsCompra.Count;
        }
        public void Agregar(DetalleOrden detalleOrden)
        {

            var item = listaItemsCompra.SingleOrDefault(i => i.ProductoId == detalleOrden.ProductoId);
            if (item == null)
            {
                listaItemsCompra.Add(detalleOrden);
            }
            else
            {
                item.Cantidad+=detalleOrden.Cantidad;
            }

        }

        public decimal TotalCarrito()
        {
            return listaItemsCompra.Sum(i => i.PrecioUnitario *(decimal) i.Cantidad);
        }

        public void QuitarDelCarrito(DetalleOrden detalleOrden)
        {
            listaItemsCompra.Remove(detalleOrden);
        }
    }
}
