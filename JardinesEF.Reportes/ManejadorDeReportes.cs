using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Reportes.Reportes;

namespace JardinesEF.Reportes
{
    public class ManejadorDeReportes : IManejadorDeReportes
    {
        public IPaisesReportes PaisesReportes { get; set; }
        public ICategoriasReportes CategoriasReportes { get; set; }

        public ManejadorDeReportes(ICategoriasReportes categoriasReportes, IPaisesReportes paisesReportes)
        {
            CategoriasReportes = categoriasReportes;
            PaisesReportes = paisesReportes;
        }

        public ReportePaises GetReportePaises(List<Pais> lista)
        {

            var rpt = new ReportePaises();
            var ds = PaisesReportes.GetDatosReportePaises(lista);
            rpt.SetDataSource(ds);
            return rpt;
        }

        public ReporteCategorias GetReporteCategorias(List<Categoria> lista)
        {
            var rpt = new ReporteCategorias();
            var ds = CategoriasReportes.GetDatosReporteCategorias(lista);
            rpt.SetDataSource(ds);
            return rpt;
        }
    }
}