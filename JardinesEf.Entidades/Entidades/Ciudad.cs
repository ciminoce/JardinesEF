using System;
using System.Collections.Generic;

namespace JardinesEf.Entidades.Entidades
{
    public class Ciudad:ICloneable
    {
        public Ciudad()
        {
            Clientes = new HashSet<Cliente>();
            Proveedores = new HashSet<Proveedor>();
        }

        public int CiudadId { get; set; }
        public string NombreCiudad { get; set; }
        public int PaisId { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Proveedor> Proveedores { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
