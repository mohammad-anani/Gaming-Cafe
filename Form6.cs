using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using inter;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form7
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }


        form1.Form1.order findorder(string name)
        {
            foreach(form1.Form1.order o in form1.Form1.orders)
            {
                if(o.name == name) return o;
            }
            form1.Form1.order o2= new form1.Form1.order();
            return o2;
        }
        private void btnorder_Click(object sender, EventArgs e)
        {
            form1.Form1.orders.Remove(findorder(comboBox1.SelectedItem.ToString()));
            MessageBox.Show("Order Removed Successfully","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private void btnorder_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Yellow;
        }

        private void btnorder_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Red;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            foreach(form1.Form1.order o in form1.Form1.orders)
            {
                comboBox1.Items.Add(o.name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnorder.Enabled = true;
        }
    }
}
