using JardinesEF.Datos.Comun;
using JardinesEF.Datos.Comun.Facades;
using JardinesEF.Datos.Sql;
using JardinesEF.Datos.Sql.Repositorios;
using JardinesEF.Servicios;
using JardinesEF.Servicios.Facades;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEF.Reportes;

namespace JardinesEF.Windows.Ninject
{
    public class Bindins : NinjectModule
    {
        public override void Load()
        {
            Bind<ViveroSqlDbContext>().ToSelf().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<IPaisesRepositorio>().To<PaisesRepositorio>();
            Bind<IPaisesServicios>().To<PaisesServicios>();

            Bind<ICategoriasRepositorio>().To<CategoriasRepositorio>();
            Bind<ICategoriasServicios>().To<CategoriasServicios>();

            Bind<ICiudadesRepositorio>().To<CiudadesRepositorio>();
            Bind<ICiudadesServicios>().To<CiudadesServicios>();

            Bind<IClientesRepositorio>().To<ClientesRepositorio>();
            Bind<IClientesServicios>().To<ClientesServicios>();

            Bind<IProveedoresRepositorio>().To<ProveedoresRepositorio>();
            Bind<IProveedoresServicios>().To<ProveedoresServicios>();

            Bind<IProductosRepositorio>().To<ProductosRepositorio>();
            Bind<IProductosServicios>().To<ProductosServicios>();

            Bind<IOrdenesRepositorio>().To<OrdenesRepositorio>();
            Bind<IOrdenesServicios>().To<OrdenesServicios>();

            Bind<IDetalleOrdenesRepositorio>().To<DetalleOrdenesRepositorio>();

            Bind<IPaisesReportes>().To<PaisesReportes>();
            Bind<ICategoriasReportes>().To<CategoriasReportes>();

            Bind<IManejadorDeReportes>().To<ManejadorDeReportes>();

        }
    }
}
