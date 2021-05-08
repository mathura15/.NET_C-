using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinalProjectBoookingSys
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\bharathi Sys\FinalProjectBoookingSys\BharathiTravels.mdf;Integrated Security=True;User Instance=True");
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
           String user = textBox1.Text;
           if (user == "admin")
           {
               SqlCommand login = new SqlCommand("select Username1,Password1 from Login", con);
               con.Open();
               SqlDataReader sdr = login.ExecuteReader();
               while (sdr.Read())
               {
                   string uname = sdr["Username1"].ToString();
                   string pword = sdr["Password1"].ToString();

                   if (uname == textBox1.Text && pword == textBox2.Text)
                   {
                       Form2 frm = new Form2();
                       this.Hide();
                       frm.Show();
                   }
                   else
                   {
                       MessageBox.Show("Please check your Username and Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
               }
               con.Close();

               textBox1.Clear();
               textBox2.Clear();
           }
           else if (user == "user")
           {
               SqlCommand businfo = new SqlCommand("select Username2,Password2 from Login", con);
               con.Open();
               SqlDataReader sde = businfo.ExecuteReader();
               while (sde.Read())
               {
                   string uname = sde["Username2"].ToString();
                   string pword = sde["Password2"].ToString();

                   if (uname == textBox1.Text && pword == textBox2.Text)
                   {
                       Form4 frm4 = new Form4();
                       this.Hide();
                       frm4.Show();
                   }
                   else
                   {
                       MessageBox.Show("Please check your Username and Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
               }
               con.Close();

               textBox1.Clear();
               textBox2.Clear();
           }
           else
           {
               MessageBox.Show("Username is incorrect!!");
           }
        }             

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            this.Hide();
            frm.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
