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
    public partial class Form4 : Form
    {
        SqlConnection conc = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Student\Documents\Visual Studio 2010\Projects\bharathi Sys\FinalProjectBoookingSys\BharathiTravels.mdf;Integrated Security=True;User Instance=True");
        public Form4()
        {          
            InitializeComponent();
        }

        void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ac;
            if (radioButton1.Checked == true)
            {
                ac = "A/C";
            }
            else 
            {
                ac = "NonA/C";
            }
            SqlCommand cmd = new SqlCommand("INSERT INTO BusInfo(Busno,BusType,AcType,Ffrom,PickupTime,Tto,DropTime) VALUES('"+textBox1.Text+"','"+textBox2.Text+"','"+ac+"','"+comboBox1.Text+"','"+comboBox2.Text+"','"+comboBox3.Text+"','"+comboBox4.Text+"')",conc);
            conc.Open();
            cmd.ExecuteNonQuery();
            conc.Close();
            MessageBox.Show("Details are saved!!","Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clear();
         }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM BusInfo WHERE Busno='"+textBox1.Text+"'",conc);
            conc.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                textBox2.Text = sdr[1].ToString();
                if (sdr[2].ToString() == "A/C")
                {
                    radioButton1.Checked = true;
                }
                else if (sdr[2].ToString() == "NonA/C")
                {
                    radioButton2.Checked = true;
                }
                comboBox1.Text = sdr[3].ToString();
                comboBox2.Text = sdr[4].ToString();
                comboBox3.Text = sdr[5].ToString();
                comboBox4.Text = sdr[6].ToString();                
            }
            conc.Close();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ac;
            if (radioButton1.Checked == true)
            {
                ac = "A/C";
            }
            else
            {
                ac = "NonA/C";
            }

            SqlCommand cmd = new SqlCommand("UPDATE BusInfo SET Busno='"+textBox1.Text+"',BusType='"+textBox2.Text+"',AcType='"+ac+"',Ffrom='"+comboBox1.Text+"',PickupTime='"+comboBox2.Text+"',Tto='"+comboBox3.Text+"',DropTime='"+comboBox4.Text+"' WHERE Busno='"+textBox1.Text+"'",conc);
            conc.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Details  are updated successfully!!","Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conc.Close();
            clear();          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM BusInfo WHERE BusNo='"+textBox1.Text+"'",conc);
            conc.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Details deleted successfully!!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            conc.Close();
            clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clear();
        }
      
     }
}
