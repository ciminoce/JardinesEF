using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Reportes
{
    public interface ICategoriasReportes
    {
        JardinesDataSet GetDatosReporteCategorias(List<Categoria> lista);
    }
}
