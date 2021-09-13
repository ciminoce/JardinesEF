namespace JardinesEf.Entidades.Entidades
{
    public class DetalleOrden
    {
        public int DetalleOrdenId { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public virtual Orden Orden { get; set; }
        public virtual Producto Producto { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is DetalleOrden))
            {
                return false;
            }

            return this.ProductoId == ((DetalleOrden) obj).ProductoId;
        }

        public override int GetHashCode()
        {
            return this.ProductoId.GetHashCode();
        }
    }
}
