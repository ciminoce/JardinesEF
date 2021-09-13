using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Reportes
{
    public class PaisesReportes : IPaisesReportes
    {
        public PaisesReportes()
        {
            
        }
        public JardinesDataSet GetDatosReportePaises(List<Pais> lista)
        {
            var ds = new JardinesDataSet();
            foreach (var pais in lista)
            {
                ds.Tables["PaisesDatatable"].Rows.Add(pais.NombrePais);
            }

            return ds;
        }
    }
}
