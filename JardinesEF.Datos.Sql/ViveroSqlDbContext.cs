using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Datos.Sql
{
    public partial class ViveroSqlDbContext : DbContext
    {
        public ViveroSqlDbContext()
            : base("name=ConexionSql")
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Ciudad> Ciudades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DetalleOrden> DetallesOrdenes { get; set; }
        public virtual DbSet<Orden> Ordenes { get; set; }
        public virtual DbSet<Pais> Paises { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ViveroSqlDbContext>(null);//no usar migraciones
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();//evita el borrado en cascada
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly()); //le digo que toma las configuraciones del assembly actual

        }
    }
}
