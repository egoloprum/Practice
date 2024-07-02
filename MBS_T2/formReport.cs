using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBS
{
    public partial class formReport : Form
    {
        public formReport()
        {
            InitializeComponent();
            //this.rvViewer.Reset();

            //var binding = new BindingSource();
            //binding.DataSource = this.NGStoreV2DataSet.mag2;

            //ReportDataSource rds = new ReportDataSource("NGStoreV2DataSet", binding);
            //this.rvViewer.LocalReport.DataSources.Clear();
            //this.rvViewer.LocalReport.DataSources.Add(rds);
            //this.rvViewer.LocalReport.ReportEmbeddedResource = "ReportViewerForm.Report2.rdlc";
            //thisrvViewer.RefreshReport();
        }

        private void formReport_Load(object sender, EventArgs e)
        {

            this.rvViewer.RefreshReport();
        }
    }
}
