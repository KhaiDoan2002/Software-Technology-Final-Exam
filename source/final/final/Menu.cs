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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void goodRecivedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            ImportGoods r = new ImportGoods();
            r.MdiParent = this;
            r.Text = "Good Received";
            r.WindowState=FormWindowState.Maximized;
            r.Show();
        }

        private void goodDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            goods_delivery d = new goods_delivery();
            d.MdiParent = this;
            d.Text = "Good Delievery";
            d.WindowState =FormWindowState.Maximized;
            d.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            View v = new View();
            v.MdiParent = this;
            v.Text = "View";
            v.WindowState = FormWindowState.Maximized;
            v.Show();
        }

        private void goodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            ModifyGoods v = new ModifyGoods();
            v.MdiParent = this;
            v.Text = "View";
            v.WindowState = FormWindowState.Maximized;
            v.Show();
        }

        private void manufacturerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            ModifyManufacturer v = new ModifyManufacturer();
            v.MdiParent = this;
            v.Text = "View";
            v.WindowState = FormWindowState.Maximized;
            v.Show();
        }
    }
}
