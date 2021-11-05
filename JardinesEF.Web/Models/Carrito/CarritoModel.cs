using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JardinesEF.Web.Models.Producto;

namespace JardinesEF.Web.Models.Carrito
{
    public class CarritoModel
    {
        private List<CarritoItemModel> items = new List<CarritoItemModel>();
        public DireccionEnvio DireccionEnvio { get; set; }
        public FacturacionInfo FacturacionInfo { get; set; }


        public IEnumerable<CarritoItemModel> Items
        {
            get { return items; }
        }

        public void AddItem(ProductoListVm producto, int cantidad)
        {
            CarritoItemModel item =
                items.SingleOrDefault(p => p.Producto.ProductoId == producto.ProductoId);

            if (item == null)
            {
                items.Add(new CarritoItemModel
                {
                    Producto = producto,
                    Cantidad = cantidad
                });
            }
            else
            {
                item.Cantidad += cantidad;
            }
        }

        public void RemoveItem(int productId)
        {
            items.RemoveAll(l => l.Producto.ProductoId == productId);
        }

        public decimal GetCartTotal()
        {
            return items.Sum(e => e.Producto.PrecioUnitario * e.Cantidad);

        }
        public void Clear()
        {
            items.Clear();
        }
    }
}