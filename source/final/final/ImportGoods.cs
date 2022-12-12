using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final
{
    public partial class ImportGoods : Form
    {
        Modify modify;
        public ImportGoods()
        {
            InitializeComponent();
        }

        private void ImportGoods_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.Import();
                dataGridView2.DataSource = modify.warehouse();
                dataGridView3.DataSource = modify.GoodsList();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String AccountantID = accountantid.Text;
            String GoodsId = goodsid.Text;
            String GoodsUnit = goodsunit.Text;
            int Quantity = 0;
            if(quantity.Text!="")
            {
                Quantity = Convert.ToInt32(quantity.Text);
            }
            DateTime date = dateTimePicker1.Value;

            try
            {
                if (AccountantID == "" || GoodsId == "" || GoodsUnit == "" || Quantity <= 0)
                {
                    MessageBox.Show("Please enter fully");
                }
                else
                {
                    Import import = new Import(AccountantID, GoodsId, GoodsUnit, Quantity, date);
                    if (modify.Imports(import))
                    {
                        dataGridView1.DataSource = modify.Import();
                        dataGridView2.DataSource = modify.warehouse();
                    }
                    else
                    {
                        MessageBox.Show("Please enter again");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            
        }
    }
}
