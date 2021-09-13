using System;
using System.Collections.Generic;

namespace JardinesEf.Entidades.Entidades
{
    public class Cliente:ICloneable
    {
        public Cliente()
        {
            Ordenes = new HashSet<Orden>();
        }

        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public int PaisId { get; set; }
        public int CiudadId { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual ICollection<Orden> Ordenes { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string ApeNombre => $"{Apellido}, {Nombres}";
    }
}
