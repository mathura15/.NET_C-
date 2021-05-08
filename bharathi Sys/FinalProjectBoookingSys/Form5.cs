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
    
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Student\Documents\Visual Studio 2010\Projects\bharathi Sys\FinalProjectBoookingSys\BharathiTravels.mdf;Integrated Security=True;User Instance=True");
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand rstpw = new SqlCommand("select * from login", con);
            con.Open();
            SqlDataReader sdr = rstpw.ExecuteReader();
            while (sdr.Read())
             {
                 string uname1 = sdr["Username1"].ToString();
                 string oldpword1 = sdr["Password1"].ToString();
                 string uname2 = sdr["Username2"].ToString();
                 string oldpword2 = sdr["Password2"].ToString();


                    if (uname1 == txtuname.Text && oldpword1 == txtoldpword.Text)
                    {
                        con.Close();
                            SqlCommand rst = new SqlCommand("update Login set Password1='" + txtpword.Text + "' where Username1='" + txtuname.Text + "'", con);
                            con.Open();
                            rst.ExecuteNonQuery();
                            MessageBox.Show("Password Changed", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            con.Close();
                    }
                    else if (uname2 == txtuname.Text && oldpword2 == txtoldpword.Text)
                    {
                        con.Close();
                        SqlCommand rst = new SqlCommand("update Login set Password2='" + txtpword.Text + "' where Username2='" + txtuname.Text + "'", con);
                        con.Open();
                        rst.ExecuteNonQuery();
                        MessageBox.Show("Password Changed", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please check your Username and Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
             
                }
            
               con.Close();
                Clear();
        }
        void Clear()
        {
            txtuname.Clear();
            txtpword.Clear();
            txtoldpword.Clear();
        }
               
        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
            Form1 frm=new Form1();
            frm.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtoldpword.PasswordChar = '\0';
            }
            else
            {
                txtoldpword.PasswordChar = '*';
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                txtpword.PasswordChar = '\0';
            }
            else
            {
                txtpword.PasswordChar = '*';
            }
        }       
        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }             
    }
}
