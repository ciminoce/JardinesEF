using System.Collections.Generic;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Reportes
{
    public interface IPaisesReportes
    {
        JardinesDataSet GetDatosReportePaises(List<Pais> lista);
    }
}