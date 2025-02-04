using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using form1;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            foreach(form1.Form1.table t in form1.Form1.tables)
            {
                comboBox1.Items.Add(t.id);
            }
        }

        int findtable(int id)
        {
            foreach (form1.Form1.table t in form1.Form1.tables)
            {
                if (t.id == id) return t.id;
            }
            return 0;
        }

        
        private void btnorder_Click(object sender, EventArgs e)
        {
            form1.Form1.RemoveTableId = Convert.ToInt32(comboBox1.SelectedItem);
            
            MessageBox.Show("Table Removed Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnorder.Enabled = true;
        }
    }
}
