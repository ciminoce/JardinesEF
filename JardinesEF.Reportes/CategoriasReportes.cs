using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JardinesEf.Entidades.Entidades;

namespace JardinesEF.Reportes
{
    public class CategoriasReportes:ICategoriasReportes
    {
        public JardinesDataSet GetDatosReporteCategorias(List<Categoria> lista)
        {
            var ds = new JardinesDataSet();
            foreach (var categoria in lista)
            {
                ds.Tables["CategoriasDatatable"].Rows.Add(new object[]
                {
                    categoria.NombreCategoria,
                    categoria.Descripcion
                });
            }

            return ds;
        }
    }
}
