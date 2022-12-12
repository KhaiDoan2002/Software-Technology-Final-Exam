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
    public partial class goods_delivery : Form
    {
        Modify modify;

        public goods_delivery()
        {
            InitializeComponent();
        }

        private void goods_delivery_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.Order();
                dataGridView2.DataSource = modify.GoodsList();
                dataGridView3.DataSource = modify.warehouse();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            String AgentId = Agent_ID.Text;
            String GoodsId = Goods_ID.Text;
            String GoodsUnit = goodsunit.Text;
            int quantity = 0;
            if (Goods_Quantity.Text != "")
            {
                quantity = Convert.ToInt32(Goods_Quantity.Text);
            }
            String chargeState = Charge_Status.Text;
            String deliveryState = Delivery_Status.Text;
            DateTime date = Date_Delivery.Value;

            Order orders = new Order(AgentId, GoodsId, GoodsUnit, quantity, date, chargeState, deliveryState);
            if (AgentId != "" || GoodsId != "" || GoodsUnit != "" || quantity <= 0 || chargeState !="" || deliveryState !="")
            {
                if (modify.insert_goods_orders(orders))
                {
                    dataGridView1.DataSource = modify.Order();
                    dataGridView2.DataSource = modify.GoodsList();
                    dataGridView3.DataSource = modify.warehouse();
                }
                else
                {
                    MessageBox.Show("Please enter again");
                }
            }
            else
            {
                MessageBox.Show("Please enter fully");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            String AgentId = Agent_ID.Text;
            String GoodsId = Goods_ID.Text;
            String GoodsUnit = goodsunit.Text;
            String chargeState = Charge_Status.Text;
            String deliveryState = Delivery_Status.Text;
            DateTime date = Date_Delivery.Value;

            Order orders = new Order(AgentId, GoodsId, GoodsUnit,1,date, chargeState, deliveryState);

            if (AgentId != "" || GoodsId != "" || GoodsUnit != ""|| chargeState != "" || deliveryState != "")
            {
                if (modify.update_goods_orders(orders))
                {
                    dataGridView1.DataSource = modify.Order();
                    dataGridView2.DataSource = modify.GoodsList();
                    dataGridView3.DataSource = modify.warehouse();
                }
                else
                {
                    MessageBox.Show("Please enter again");
                }
            }
            else
            {
                MessageBox.Show("Please enter fully");
            }
        }
    }
}
