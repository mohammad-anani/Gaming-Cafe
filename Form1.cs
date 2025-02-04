using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using inter;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.Win32;
using form7;

namespace form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public struct table
        {
            public string name;
            public int id;
            public string console;
            public bool working;
            public bool timer;
            public Panel panel;
            public float PricePerHour;
            public float price;
            public int seconds;
            public int minutes;
            public float Time;
            public int x;
            public int y;
            public float hours;
            public string date;

        }

        struct tabledetails
        {
            public string console;
            public float pph;
        }
        List<tabledetails> list=new List<tabledetails>();
        int TablesCount = 0;
       public static List<table> tables=new List<table>();
        public static int RemoveTableId=-1;
        int y = 0;
        int x = 0;

       
        void AddTable(string console,float Price)
        {
            TablesCount++;
            if (x == 6)
            {
                y++;
                x = 0;
            }
            Panel panel = new Panel()
            {
                Name = (TablesCount).ToString(),
                Size = new Size(250, 470),
                Location = new Point(5 + 251 * x, 5 + 470 * y),
                BorderStyle = BorderStyle.FixedSingle
            };
           
            tabPage1.Controls.Add(panel);




            System.Windows.Forms.Label lbltitle = new System.Windows.Forms.Label()
            {
                AutoSize = true,
                Font = new Font("Arial", 20, FontStyle.Regular),
                ForeColor = Color.White,
                Text = "Table " + TablesCount,
                Location= new Point(70,15),
            };
            panel.Controls.Add(lbltitle);




            System.Windows.Forms.Label lblconsole = new System.Windows.Forms.Label()
            {
                AutoSize = true,
                Font = new Font("Arial", 20, FontStyle.Regular),
                ForeColor = Color.White,
                Text = console,
                Location = new Point(85, 45),
            };
            panel.Controls.Add(lblconsole);




            System.Windows.Forms.Label lblpph = new System.Windows.Forms.Label()
            {
                AutoSize = true,
                Font = new Font("Arial", 20, FontStyle.Regular),
                ForeColor = Color.White,
                Text = Price.ToString() + "$ per Hour",
                Location = new Point(40, 75),
            };
            panel.Controls.Add(lblpph);




            System.Windows.Forms.Label lblname = new System.Windows.Forms.Label()
            {
                AutoSize = true,
                Font = new Font("Arial", 20, FontStyle.Regular),
                ForeColor = Color.White,
                Text = "Name:",
                Location = new Point(5, 140),
            };
            panel.Controls.Add(lblname);





            TextBox txtname = new TextBox
            {
                Name="txtname",
               Size=new Size(150,100),
                Font = new Font("Arial", 20, FontStyle.Regular),
                Location= new Point(90,135)
            };
            panel.Controls.Add(txtname);
            lblname.SendToBack();






            System.Windows.Forms.Label lbltime = new System.Windows.Forms.Label()
            {
                AutoSize = true,
                Font = new Font("Arial", 20, FontStyle.Regular),
                ForeColor = Color.White,
                Text = "Hours:",
                Location = new Point(5, 200),
            };
            panel.Controls.Add(lbltime);





            NumericUpDown n = new NumericUpDown
            {
                Name = "n",
                Size = new Size(100, 150),
                Font = new Font("Arial", 20, FontStyle.Regular),
                Location = new Point(100, 195),
                Increment = 0.25m,
                DecimalPlaces = 2,
                Maximum = 5, Minimum = 0
            };
            panel.Controls.Add(n);
            n.ValueChanged += change_time_price;





            System.Windows.Forms.Label lbltimetag = new System.Windows.Forms.Label()
            {
                AutoSize = true,
                Font = new Font("Arial", 20, FontStyle.Regular),
                ForeColor = Color.White,
                Text = "Timer:",
                Location = new Point(5, 250),
            };
            panel.Controls.Add(lbltimetag);





            System.Windows.Forms.Label lbltimer = new System.Windows.Forms.Label()
            {
                Name = "lbltimer",
                AutoSize = true,
                Font = new Font("Arial", 20, FontStyle.Regular),
                ForeColor = Color.White,
                Text = "0:00:00",
                Location = new Point(100, 250),
            };
            panel.Controls.Add(lbltimer);





            System.Windows.Forms.Label lblpricetag = new System.Windows.Forms.Label()
            {
                AutoSize = true,
                Font = new Font("Arial", 20, FontStyle.Regular),
                ForeColor = Color.White,
                Text = "Price:",
                Location = new Point(5, 300),
            };
            panel.Controls.Add(lblpricetag);





            System.Windows.Forms.Label lblprice = new System.Windows.Forms.Label()
            {
                Name = "lblprice",
                AutoSize = true,
                Font = new Font("Arial", 20, FontStyle.Regular),
                ForeColor = Color.White,
                Text = "00$",
                Location = new Point(100, 300),
            };
            panel.Controls.Add(lblprice);





            Button start = new Button
            {
                Name="Start",
                Location = new Point(40, 350),
                Size = new Size(150, 100),
                Font = new Font("Arial", 20, FontStyle.Regular),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Text ="Start/End"
            };
            panel.Controls.Add(start);
            start.MouseClick += Start_MouseClick;
            start.MouseEnter += Start_MouseEnter;
            start.MouseLeave += Start_MouseLeave;






            ContextMenuStrip cms = new ContextMenuStrip
            {
                
            };

            ToolStripMenuItem disable = new ToolStripMenuItem
            {
                Text = "Disable",
               
            };
            ToolStripMenuItem enable = new ToolStripMenuItem
            {
                Text = "Enable",
              
               
            };
            cms.Items.Add(disable);
            cms.Items.Add(enable);
            disable.Click += Disable_Click;
            enable.Click += Enable_Click;
            panel.ContextMenuStrip = cms;
            

            table tab = new table();
            tab.panel = panel;
            tab.id = TablesCount; ;
            tab.console = console;
            tab.x = x;
            tab.y = y;
            tab.PricePerHour = Price;
            tab.PricePerHour = Price;
            tables.Add(tab);
            x++;
        }

        private void Start_MouseLeave(object sender, EventArgs e)
        {
            
                Button btn = sender as Button;
            Panel panel = (Panel)btn.Parent;
            index = FindTableByPanel(panel);
            if (!tables[index].working)
                btn.BackColor = Color.Black;
            else
                btn.BackColor = Color.Blue;
            

            
                
            
        }

        private void Start_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Gray;
        }

        

        private void Enable_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = sender as ToolStripItem;
            ContextMenuStrip cms = tsi.Owner as ContextMenuStrip;
            Panel panel = cms.SourceControl as Panel;
            
            Button btn = (Button)find("Start", panel);
            TextBox txtname = (TextBox)find("txtname", panel);
            NumericUpDown n = (NumericUpDown)find("n", panel);
            

            txtname.Enabled = true;
            n.Enabled = true;
            btn.Enabled = true;
        }

        private void Disable_Click(object sender, EventArgs e)
        {
          ToolStripItem tsi = sender as ToolStripItem;
            ContextMenuStrip cms = tsi.Owner as ContextMenuStrip;
            Panel panel=cms.SourceControl as Panel;
            Button btn = (Button)find("Start", panel);
            TextBox txtname = (TextBox)find("txtname", panel);
            NumericUpDown n = (NumericUpDown)find("n", panel);
            index = FindTableByPanel(panel);

            table t = tables[index];
            t.working = false;
            t.timer = false;
            t.hours = 0;
            t.Time = 0;
            t.minutes = 0;
            t.seconds = 0;
            t.price = 0;
            UpdateTime(panel, index);
            UpdatePrice(panel, index);
            tables[index] = t;
            txtname.Enabled = false;
            n.Enabled = false;
            txtname.Text = "";
            btn.Enabled = false;
            n.Value = 0;
        }

        private void Start_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Panel panel = (Panel)btn.Parent;
            TextBox txtname = (TextBox)find("txtname", panel);
            NumericUpDown n = (NumericUpDown)find("n", panel);
            index = FindTableByPanel(panel);


            if (!tables[index].working)
            {
                if (string.IsNullOrEmpty(txtname.Text) || n.Value == 0)
                {
                    MessageBox.Show("Missing Information", "Error", MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                    return;
                }

                table t = tables[index];
                t.name = txtname.Text;
                t.date=System.DateTime.Now.ToString();
                
                SaveToHistory(t);
                UpdateIncome();

                t.timer = true;
                t.working = true;
                tables[index] = t;
                btn.BackColor = Color.Blue;
                txtname.Enabled = false;
                n.Enabled = false;
                
            }
            else
            {
                btn.BackColor = Color.Black;
                table t = tables[index];
                t.working = false;
                t.hours = 0;
                t.Time = 0;
                t.minutes = 0;
                t.seconds = 0;
                t.price = 0;
                UpdateTime(panel,index);
                UpdatePrice(panel, index);
                tables[index] = t;
                txtname.Enabled = true;
                n.Enabled = true;
                txtname.Text = "";
                n.Value=0;

            }


        }


        void SaveToHistory(table t)
        {
            ListViewItem item=new ListViewItem(t.id.ToString());
            item.SubItems.Add(t.name);
            item.SubItems.Add(t.Time.ToString());
            item.SubItems.Add(t.price.ToString());
            item.SubItems.Add(t.date);
            listView1.Items.Add(item);
        }
        int FindIndex(table t)
        {
            for (int i = 0;i<tables.Count();i++)
            {
                if (tables[i].id==t.id) return i;
            }
            return -1;
        }
        void count_down(table t)
        {
            if (t.seconds == 0 && t.minutes == 0 && t.hours == 0)
            {
                t.timer = false;
                index = FindIndex(t);
                tables[index] = t;
                MessageBox.Show("Table " + (index + 1) + " Time Over\nPlease End Session",
                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (t.seconds == 0 && t.minutes>0)
            {
                t.minutes--;
                t.seconds = 60;
            }
            if (t.minutes == 0 && t.hours>0)
            {
                t.hours--;
                t.minutes = 59;
            }
             if(t.seconds>0)
            t.seconds--;

            index= FindIndex(t);

            tables[index] = t;
            UpdateTime(t.panel,index);
            
        }

       string FindOrderDetailsByDate(string date)
        {
            for (int i = 0; i< listView2.Items.Count;i++)
            {
                if (date == listView2.Items[i].SubItems[2].Text)
                    return inter.inter.ordersdetails[i];
            }
            return "";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            List<table> temp = new List<table>(tables);

            foreach (table t in temp)
            {
                if(t.timer)
                {
                    count_down(t);
                    
                    
                }
            }
            

        }

        int FindTableByPanel(Panel panel)
        {
            foreach (table t in tables)
            {
                if (t.panel == panel)
                    return tables.IndexOf(t) ;
            }
            
            return -1;
        }

        int index = -1;
        void UpdateTime(Panel panel,int index)
        {
           
            System.Windows.Forms.Label lbltimer = (System.Windows.Forms.Label)find("lbltimer", panel);

                lbltimer.Text=tables[index].hours.ToString() +":"+
                tables[index].minutes.ToString("D2") + ":"+tables[index].seconds.ToString("D2");
        }

        void UpdatePrice(Panel panel,int index)
        {
            System.Windows.Forms.Label lblprice = (System.Windows.Forms.Label)find("lblprice", panel);

            lblprice.Text = tables[index].price.ToString() + "$";
        }
        private void change_time_price(object sender, EventArgs e)
        {
            NumericUpDown n=(NumericUpDown)sender;
            Panel panel = (Panel) n.Parent;
            index= FindTableByPanel(panel);
            table t = tables[index];

            t.Time = (Convert.ToSingle(n.Value));
            t.price = t.PricePerHour * t.Time;
            tables[index] = t;
            UpdatePrice(panel, index);

            t.minutes = (int)(Convert.ToSingle(t.Time) % 1*60);
            t.hours = (int)(Convert.ToSingle(t.Time) / 1);
            t.seconds = 0;
            tables[index] = t;
            UpdateTime(panel,index);

            

        }

        Control find(string name,Panel panel)
        {
            foreach(Control c in panel.Controls)
            {
                if (c.Name == name)
                    return c;
            }
            return null;
        }


        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            if(!fullaccess)
            {
                panel1.Visible = false;
            }
            else
                panel1.Visible= true;

            Timer timer = new Timer
            {
                Enabled =true,
                Interval = 10
            };
            timer.Tick += Timer_Tick;
           
          
            AddTable("Ps4", 10);
            AddTable("Ps4 Pro", 15);
            AddTable("Ps5", 20);
            AddTable("Ps4", 10);
            AddTable("Ps4", 10);
            AddTable("Xbox X", 15);
            AddOrder("Tea", 2.5f);
            AddOrder("Coffee", 2.0f);
            AddOrder("Water", 0.5f);
                ShowTablesButtons();
                
           

        }

        void AddOrder(string name,float price)
        {
            order o=new order();
            o.name = name;
            o.price = price;
            orders.Add(o);
        }
        void ShowTablesButtons()
        {
            int y = 0;
            int x = 0;
           for(int i=0;i<= tables.Count - 1; i++)
            {
                x = i;
                if(x==15)
                {
                    y++;
                    x = 0;
                }
                Button button = new Button
                {
                    Text = "Table " + (i + 1),
                    Location = new Point(5+100*x,61+100*y ),
                    Size = new Size(100, 100),
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    
                };
                button.MouseEnter += Button_Enter;
                button.MouseLeave += Button_Leave;
                button.Click += Table_Order_button;
                tabPage2.Controls.Add(button);
            }
        }

        private void Table_Order_button(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            inter.inter.tablenum = btn.Text[btn.Text.Length-1];
            Form frm = new Form2();
           frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        private void Button_Leave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Black;
        }

        private void Button_Enter(object sender, EventArgs e)
        {
           Button btn=sender as Button;
            btn.BackColor = Color.Gray;
        }

        void SaveToHistory(ref orderhist o)
        {
            if (o.id == 0)
                return;


            ListViewItem item = new ListViewItem(o.id.ToString());
            item.SubItems.Add(o.total.ToString());
            item.SubItems.Add(o.date);
            listView2.Items.Add(item);
            o = new orderhist();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            SaveToHistory(ref inter.inter.oneOrderHist);
            UpdateIncome();
        }

        float income = 0;
        void UpdateIncome()
        {
            income = 0;

            foreach(ListViewItem item in listView1.Items)
            {
                income += Convert.ToSingle(item.SubItems[3].Text);
            }
            foreach (ListViewItem item in listView2.Items)
            {
                income += Convert.ToSingle(item.SubItems[1].Text);
            }
            lblincome.Text = income.ToString() + "$";
        }
        private void listView2_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if(listView2.CheckedItems.Count > 0)
           { MessageBox.Show(FindOrderDetailsByDate(listView2.CheckedItems[0].SubItems[2].Text), "Order Details");
                listView2.CheckedItems[0].Checked = false;
            }

        }

        private void btnorder_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Yellow;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Lime;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Red;
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            Form form = new Form3();
            form.ShowDialog();
            if (inter.inter.pph != 0)
            {
                AddTable(inter.inter.console, inter.inter.pph);
            }
            inter.inter.console = "";
                inter.inter.pph = 0;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm= new Form4();
            frm.ShowDialog();
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.YellowGreen;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Yellow;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
           
            if(MessageBox.Show("Are You Sure?","Wait",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==
                DialogResult.Yes)
            {
                progressBar1.Visible = true;
                while(progressBar1.Value<100)
                {
                    await Task.Delay(10);
                    progressBar1.Value++;
                }
                progressBar1.Visible = false;
                MessageBox.Show("Day Ended Successfully.\nHistories Saved.", "Good Job", MessageBoxButtons.OK,
                    MessageBoxIcon.Information) ;

                this.Close();
            }
        }


        Panel FindPanel(string name)
        {
            foreach(Control c in tabPage1.Controls)
            {
                if (c.Name == name)
                    return (Panel)c;
            }
            return null;
        }


        void RemoveTable(int id)
        {
            table toremove = new table();
          
            for (int i=1;i<=tables.Count();i++)
            {
                if (tables[i-1].id==id)
                {
                    toremove=tables[i-1];
                    break;
                }
               
            }
            toremove.panel = FindPanel(id.ToString());
            toremove.panel.Dispose();
            tables.Remove(toremove);
            RemoveTableId = -1;
        }

        void ShiftTables(int id)
        {
            table toremove=new table();
            for (int i = 1; i <= tables.Count(); i++)
            {
                if (tables[i - 1].id == id)
                {
                    toremove = tables[i - 1];
                    break;
                }

            }
            Point previoustablelocation = toremove.panel.Location;
            Point Currenttablelocation = new Point();
            for (int i=toremove.x+1;i<=6;i++)
            {
                Panel panel= FindPanel((6*toremove.y+i).ToString());
                if (panel == null)
                    break;
                Currenttablelocation = panel.Location;
                panel.Location = previoustablelocation;
                previoustablelocation = Currenttablelocation;
                int index = FindTableByPanel(panel);
                table t = tables[index];
                t.x = i-1;
                tables[index] = t;
            }
           
            for(int i=toremove.y+1;i<=y;i++)
            {
                for(int j=1;j<=6;j++)
                {
                    Panel panel = FindPanel((6 * i + j).ToString());
                    if (panel == null)
                        return;
                    Currenttablelocation = panel.Location;
                    panel.Location = previoustablelocation;
                    previoustablelocation = Currenttablelocation;
                    int index = FindTableByPanel(panel);
                    table t = tables[index];
                    if (t.x == 0)
                    {
                        t.x = 5;
                        t.y--;
                    }
                    else
                        t.x = j - 1;
                    tables[index] = t;

                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form form= new Form5();
            form.ShowDialog();

            if(RemoveTableId!=-1)
            {
                ShiftTables(RemoveTableId);
                RemoveTable(RemoveTableId);
                

                if(x==0)
                {
                    y--;
                    x = 6;
                }
                else { x--; }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm= new Form6();
            frm.ShowDialog();

        }

       public struct order
        {
            public  string name;
            public  float price;
        }
        public static List<order> orders= new List<order>();

        public static bool fullaccess = false;
        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
