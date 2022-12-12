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
    public partial class ReportBestSelling : Form
    {
        public ReportBestSelling()
        {
            InitializeComponent();
        }

        Modify modify = new Modify();
        private void ReportBestSelling_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "final.reportbestselling.rdlc";
                ReportDataSource reportDataSource1 = new ReportDataSource();
                reportDataSource1.Name = "DataSet1";
                reportDataSource1.Value = modify.BestSelling();
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
