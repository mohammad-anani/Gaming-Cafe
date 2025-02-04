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


namespace form7
{
    public partial class Form7 : Form
    {

        struct user
        {
            public string username;
            public string password;
            public bool fullaccess;
        }
        List<user> users=new List<user>();

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            user u= new user();
            u.username = "mohammad2006";
            u.password = "1234";
            u.fullaccess = true;
            users.Add(u);
            u.username = "ali2003";
            u.password = "1234";
            u.fullaccess=false;
            users.Add(u);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Gray;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
        }

        user finduser(string username,string password)
        {
            foreach (user user in users)
            {
                if(user.username == username && user.password==password)
                {
                    return user;
                }
            }
            user user2= new user();
            return user2;
        }

        int failedattempts = 3;
        int minutes, seconds;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(seconds==0 && minutes==0)
            {
                timer1.Enabled = false;
                textBox1.Enabled=true;
                textBox2.Enabled=true;
                button1.Enabled=true;
                label3.Visible=false;
                failedattempts = 3;
                MessageBox.Show("Time Over!\n3 Attempts Left","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            if(seconds==0)
            {
                minutes--;
                seconds = 60;
            }
            seconds--;
            label3.Text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Missing Information!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            user u =finduser(textBox1.Text, textBox2.Text);
            if (u.username==null)
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                failedattempts--;
                MessageBox.Show("Invalid Username/Password!\n" + failedattempts +" Attempts Left!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                if (failedattempts == 0)
                {

                    MessageBox.Show("3 Failed Attempts!\nWait 5 minutes", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    button1.Enabled = false;
                    label3.Visible = true;
                    minutes = 5;
                    label3.Text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
                    timer1.Enabled = true;
                    
                }
                return;
            }
            form1.Form1.fullaccess = u.fullaccess;
            textBox1.Text = "";
            textBox2.Text = "";
            failedattempts = 3;
            Form frm = new Form1();

            frm.ShowDialog();
            form1.Form1.tables.Clear();



        }
    }
}
