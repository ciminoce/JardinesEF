using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JardinesEf.Entidades.Entidades;
using JardinesEF.Servicios.Facades;

namespace JardinesEF.Windows
{
    public partial class FrmProductosPorCategoria : Form
    {
        public FrmProductosPorCategoria(ICategoriasServicios servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private ICategoriasServicios _servicio;
        private List<IGrouping<int, Producto>> listaGrupos;
        public void SetGrupo(List<IGrouping<int, Producto>> listaGrupos)
        {
            this.listaGrupos = listaGrupos;
        }

        private void FrmProductosPorCategoria_Load(object sender, EventArgs e)
        {
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            foreach (var grupo in listaGrupos)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(GruposDataGridView);
                SetearFila(r, grupo);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            GruposDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, IGrouping<int, Producto> grupo)
        {
            var categoria = _servicio.GetEntityPorId(grupo.Key);
            r.Cells[colCategoria.Index].Value = categoria.NombreCategoria;
            r.Cells[colCantidad.Index].Value = grupo.Count();
        }

    }
}
