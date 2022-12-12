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

namespace final
{
    public partial class ReportIncoming : Form
    {
        public ReportIncoming()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();
        private void ReportIncoming_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "final.reportincoming.rdlc";
                ReportDataSource reportDataSource1 = new ReportDataSource();
                reportDataSource1.Name = "DataSet2";
                reportDataSource1.Value = modify.Import();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.RefreshReport();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
