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
    public partial class ReportMonthly : Form
    {
        public ReportMonthly()
        {
            InitializeComponent();
        }

        private void ReportMonthly_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer2.LocalReport.ReportEmbeddedResource = "final.reportmonthly.rdlc";
                ReportDataSource reportDataSource1 = new ReportDataSource();
                reportDataSource1.Name = "DataSet5";
                reportDataSource1.Value = View.lst;
                reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer2.RefreshReport();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
