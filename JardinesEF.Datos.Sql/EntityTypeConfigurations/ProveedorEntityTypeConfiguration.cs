using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Datos.Sql.EntityTypeConfigurations
{
    public class ProveedorEntityTypeConfiguration:EntityTypeConfiguration<Proveedor>
    {
        public ProveedorEntityTypeConfiguration()
        {
            ToTable("Proveedores");
        }
    }
}
