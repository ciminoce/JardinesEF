using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JardinesEF.Windows.Helpers
{
    public class HelperForm
    {
        public static void MostrarInfoPaginas(SplitterPanel panel, int cantidadRegistros, int cantidadPaginas,
            int paginaActual)
        {
            ((Label) panel.Controls["CantidadDeRegistrosLabel"]).Text=cantidadRegistros.ToString();
            ((Label)panel.Controls["CantidadDePaginasLabel"]).Text=cantidadPaginas.ToString();
            ((Label) panel.Controls["PaginaActualLabel"]).Text=paginaActual.ToString();

        }
        public static void CrearBotonesPaginas(Panel panel, int paginas)
        {
            panel.Controls.Clear();
            for (int i = 0; i < paginas; i++)
            {
                Button b = new Button()
                {
                    Text = (i + 1).ToString(),
                    Location = new Point(16 + (35 * i), 16),
                    Size = new Size(32, 32)

                };
                //b.Click += Miclick;//Le agrego un manejador al evento clic de los botones
                panel.Controls.Add(b);//Agregro el botón a la colección de controles del panel
            }

        }

    }
}
