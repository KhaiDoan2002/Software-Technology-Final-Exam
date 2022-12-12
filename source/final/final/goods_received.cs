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
    public partial class goods_received : Form
    {
        Modify modify;
        public goods_received()
        {
            InitializeComponent();
        }

        //private void Create_Click(object sender, EventArgs e)
        //{
        //    String goodsId = Goods_ID.Text;
        //    String goodsName = Goods_Name.Text;
        //    Decimal goodsPrice = Convert.ToDecimal(Goods_Price.Text);
        //    String quantity = Goods_Quantity.Text;
        //    Decimal totalPrice = Convert.ToInt32(quantity) * goodsPrice;
        //    String accountantID = Accountant_ID.Text;
        //    DateTime date = Date_Received.Value;
        //

        //   Goods goods = new Goods(goodsId, goodsName,goodsPrice);
        //    Import imports = new Import(accountantID,goodsId,Convert.ToInt32(quantity),totalPrice,date);

        //    if (modify.insert_goods_imports(goods,imports))
        //    {
        //        dataGridView1.DataSource = modify.Import();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Lỗi");
        //   }
        //}

        private void goods_received_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.Import();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

    }
}
