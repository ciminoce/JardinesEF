using System;
using System.Collections.Generic;

namespace JardinesEf.Entidades.Entidades
{
    public class Categoria:ICloneable
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
