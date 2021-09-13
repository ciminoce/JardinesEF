using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using JardinesEF.Reportes.Reportes;

namespace JardinesEF.Windows
{
    public partial class FrmVisorReportes : Form
    {
        public FrmVisorReportes()
        {
            InitializeComponent();
        }

        private ReportClass rpt;
        public void SetReporte(ReportClass rpt)
        {
            this.rpt = rpt;
        }

        private void FrmVisorReportes_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
