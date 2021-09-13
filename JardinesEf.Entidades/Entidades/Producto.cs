using System.Collections.Generic;

namespace JardinesEf.Entidades.Entidades
{
    public class Producto
    {
        public Producto()
        {
            DetalleOrdenes = new HashSet<DetalleOrden>();
        }

        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public string NombreLatin { get; set; }
        public int ProveedorId { get; set; }
        public int CategoriaId { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int UnidadesEnStock { get; set; }
        public int UnidadesEnPedido { get; set; }
        public int NivelDeReposicion { get; set; }
        public bool Suspendido { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<DetalleOrden> DetalleOrdenes { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
