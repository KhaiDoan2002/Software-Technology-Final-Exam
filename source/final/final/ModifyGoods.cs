using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace final
{
    public partial class ModifyGoods : Form
    {
        Modify modify;
        public ModifyGoods()
        {
            InitializeComponent();
        }

        private void ModifyGoods_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.GoodsList();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String goodsId = GoodsID.Text;
            String goodsName = GoodsName.Text;
            Decimal goodsPrice = Convert.ToDecimal(GoodsPrice.Text);
            String goodsUnit = GoodsUnit.Text;
            String manuID = ManuID.Text;

            Goods g = new Goods(goodsId,goodsName,goodsUnit, goodsPrice,manuID);

            if(goodsId == "" || goodsName =="" || goodsPrice<=0 || goodsUnit=="" || manuID=="")
            {
                MessageBox.Show("Please enter fully");

            }
            else
            {
                if (modify.insert_goods(g))
                {
                    dataGridView1.DataSource = modify.GoodsList();
                }
                else
                {
                    MessageBox.Show("Please enter again");
                }
            }
        }
    }
}
