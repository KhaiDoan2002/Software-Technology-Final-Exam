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
    public partial class ModifyManufacturer : Form
    {
        Modify modify;
        public ModifyManufacturer()
        {
            InitializeComponent();
        }

        private void ModifyManufacturer_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.ManufacturerList();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String ManuId = textBox1.Text;
            String ManuName = textBox2.Text;
            String Address = textBox3.Text;

            Manufacturer m = new Manufacturer(ManuId, ManuName, Address); 
            if(ManuId == "" || ManuName == "" || Address == "")
            {
                MessageBox.Show("Please enter fully");
            }
            else
            {
                if (modify.insert_manufacturer(m))
                {
                    dataGridView1.DataSource = modify.ManufacturerList();
                }
                else
                {
                    MessageBox.Show("Please enter again");
                }
            }
        }
    }
}
