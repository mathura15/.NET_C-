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
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Student\Documents\Visual Studio 2010\Projects\bharathi Sys\FinalProjectBoookingSys\BharathiTravels.mdf;Integrated Security=True;User Instance=True");
        public Form2()
        {
            InitializeComponent();
        }
        void clear()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
         }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("Fill your travel details!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else 
            {
                bussearch();
                Form3 frm = new Form3(comboBox1.Text,comboBox3.Text,comboBox2.Text,comboBox4.Text);
                this.Hide();
                clear();
                frm.Show();
            }
             
                                       
        }
        void bussearch()
        {
            //TODO: This line of code loads data into the 'bharathiTravelsDataSet1.BusInfo' table. You can move, or remove it, as needed.
            //this.BusInfoTableAdapter.Fill(this.BharathiTravelsDataSet1.BusInfo);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Busno FROM BusInfo WHERE Ffrom='" +comboBox1.Text+ "' AND PickupTime='" +comboBox3.Text+ "' AND Tto='" +comboBox2.Text+ "' AND DropTime='" +comboBox4.Text+ "'", conn);
           // SqlDataAdapter sda = new SqlDataAdapter("SELECT Busno FROM BusInfo", conn);

            conn.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox1.DataSource = dt;
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
