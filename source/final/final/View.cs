using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final
{
    public partial class View : Form
    {
        Modify modify;
        public static List<monthly_icome> lst = new List<monthly_icome>();

        public View()
        {
            InitializeComponent();
        }

        private void Incoming_Click(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.Import();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Outcoming_Click(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.Order();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Best_Selling_Click(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.BestSelling();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Monthly_income_Click(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.MonthlyIncome();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void reportbestselling_Click(object sender, EventArgs e)
        {
            ReportBestSelling r = new ReportBestSelling();
            r.ShowDialog();
        }
        private void reportincoming_Click(object sender, EventArgs e)
        {

            ReportIncoming r = new ReportIncoming();
            r.ShowDialog();
        }

        private void reportoutcoming_Click(object sender, EventArgs e)
        {
            ReportOutComing r = new ReportOutComing();
            r.ShowDialog();
        }

        private void reportmonthlyincome_Click(object sender, EventArgs e)
        {
            ReportDataSource rs = new ReportDataSource();
            modify = new Modify();
            ReportMonthly r = new ReportMonthly();

            lst.Clear();
            dataGridView1.DataSource = modify.MonthlyIncome();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                lst.Add(new monthly_icome
                {
                    month = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    income = Decimal.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString())

                });
            }
            rs.Name = "Dataset5";
            rs.Value = lst;
            r.reportViewer2.LocalReport.DataSources.Clear();
            r.reportViewer2.LocalReport.DataSources.Add(rs);
            r.reportViewer2.LocalReport.ReportEmbeddedResource = "final.reportmonthly.rdlc";
            r.ShowDialog();
        }           
    }
}
