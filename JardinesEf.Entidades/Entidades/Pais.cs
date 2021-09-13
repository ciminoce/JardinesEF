using System;
using System.Collections.Generic;

namespace JardinesEf.Entidades.Entidades
{
    public class Pais:ICloneable
    {
        public Pais()
        {
            Clientes = new HashSet<Cliente>();
            Proveedores = new HashSet<Proveedor>();
        }

        public int PaisId { get; set; }
        public string NombrePais { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Proveedor> Proveedores { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
