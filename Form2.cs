using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using form1;
using inter;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form1
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void btnorder_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.DarkGreen;
        }

        private void btnorder_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.Lime;
        }

        int y = 0;
        int x = 0;
        
        void AddOrder(string ordername, float price)
        {

            if (x == 15)
            {
                y++;
                x = 0;
            }
            Button button = new Button
            {
                Text = ordername,
                Tag = price.ToString(),
                Location = new Point(5 + 100 * x, 5 + 100 * y),
                Size = new Size(100, 100),
                Font = new Font("Arial", 10, FontStyle.Regular),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                

            };
            button.MouseEnter += Button_Enter;
            button.MouseLeave += Button_Leave;
            button.Click += AddOrderToList;
            panel1.Controls.Add(button);
            x++;
          

        }

        float total = 0;
        void UpdatePrice()
        {
            total = 0;

            foreach (ListViewItem i in listView1.Items)
            {
                
                total += Convert.ToSingle(i.SubItems[1].Text);
            }
            lblprice.Text = total.ToString()+"$";
        }

        void AddOrderToList(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ListViewItem item = new ListViewItem(btn.Text);
            item.SubItems.Add(btn.Tag.ToString());
            listView1.Items.Add(item);
            UpdatePrice();

        }

        void Button_Leave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Black;
        }

        void Button_Enter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Gray;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.SelectedItems.Clear();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lbltable.Text =inter.inter.tablenum.ToString();
           foreach(form1.Form1.order o in form1.Form1.orders)
            {
                AddOrder(o.name,o.price);
            }
        }
        
        Button findorder(string name)
        {
            foreach(Control c in panel1.Controls)
            {
                if(c.Text == name)
                {
                    return (Button)c;
                }
            }
            return null;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            foreach (ListViewItem i in listView1.Items)
            {
                if (i.Checked)
                    {
                    total -= Convert.ToSingle(i.SubItems[1].Text);
                    
                    listView1.Items.Remove(i);
                    UpdatePrice();
                }
                
            }
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
                return;

            MessageBox.Show("Order Successful.","Message",MessageBoxButtons.OK, MessageBoxIcon.Information);
 

            orderhist o=new orderhist();
            o.id = Convert.ToInt32(inter.inter.tablenum.ToString());

            o.orders = new List<string>();
            fillorder(ref o);
            fillorderstring(o);
            o.date=System.DateTime.Now.ToString();

            inter.inter.oneOrderHist = o;


            this.Close();
        }

        string orderdetails = "";
        void fillorderstring(orderhist o)
        {
            orderdetails = "";
            foreach(string s in o.orders)
            {
                orderdetails += s + "\n";
            }
            inter.inter.ordersdetails.Add(orderdetails);
        }
        

        void fillorder(ref orderhist o)
        {
            
            foreach (ListViewItem i in listView1.Items)
            {
                o.total += Convert.ToSingle(i.SubItems[1].Text);
                o.orders.Add(i.SubItems[0].Text);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Gray;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Black;
        }
    }
}
