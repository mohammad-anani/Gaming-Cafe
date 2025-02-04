using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using inter;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
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

        private void btnorder_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtconsole.Text)|| string.IsNullOrEmpty(txtpph.Text))
            {
                MessageBox.Show("Missing Information","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            inter.inter.pph = Convert.ToSingle(txtpph.Text);
            inter.inter.console = txtconsole.Text;
            MessageBox.Show("Table Added Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
