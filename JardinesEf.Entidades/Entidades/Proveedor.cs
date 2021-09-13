using System.Collections.Generic;

namespace JardinesEf.Entidades.Entidades
{
    public class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }

        public int ProveedorId { get; set; }
        public string NombreProveedor { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public int CiudadId { get; set; }
        public int PaisId { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
