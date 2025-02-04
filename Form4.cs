using inter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using form1;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtconsole.Text) || string.IsNullOrEmpty(txtpph.Text))
            {
                MessageBox.Show("Missing Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            form1.Form1.order o = new form1.Form1.order();
            o.price= Convert.ToSingle(txtpph.Text);
            o.name= txtconsole.Text;
            form1.Form1.orders.Add(o);
            MessageBox.Show("Order Added Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            btn.BackColor = Color.Lime;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
