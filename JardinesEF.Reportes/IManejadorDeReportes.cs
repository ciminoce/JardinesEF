using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Reportes.Reportes;

namespace JardinesEF.Reportes
{
    public interface IManejadorDeReportes
    {
        ReportePaises GetReportePaises(List<Pais> lista);
        ReporteCategorias GetReporteCategorias(List<Categoria> lista);
    }
}