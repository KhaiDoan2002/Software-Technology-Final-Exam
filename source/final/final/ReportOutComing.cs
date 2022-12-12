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
    public partial class ReportOutComing : Form
    {
        public ReportOutComing()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();

        private void ReportOutComing_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "final.reportoutcoming.rdlc";
                ReportDataSource reportDataSource1 = new ReportDataSource();
                reportDataSource1.Name = "DataSet3";
                reportDataSource1.Value = modify.Order();
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
