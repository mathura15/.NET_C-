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
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Student\Documents\Visual Studio 2010\Projects\bharathi Sys\FinalProjectBoookingSys\BharathiTravels.mdf;Integrated Security=True;User Instance=True");
        string from;
        string picktime;
        string TTo;
        string droptime;

        public Form3(String fr, String pt, String tto, String dt)
        {
            InitializeComponent();
            from = fr;
            picktime = pt;
            TTo = tto;
            droptime = dt;
        }
        void fromto()
        {
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM BusInfo WHERE Busno='" + comboBox1.Text + "'", conn);
            conn.Open();
            SqlDataReader sdr1 = cmd1.ExecuteReader();
            while (sdr1.Read())
            {
                textBox5.Text = sdr1[3].ToString();
                textBox6.Text = sdr1[5].ToString();
            }
            conn.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            fromto();
            // TODO: This line of code loads data into the 'bharathiTravelsDataSet1.BusInfo' table. You can move, or remove it, as needed.
            this.busInfoTableAdapter.Fill(this.bharathiTravelsDataSet1.BusInfo);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Busno FROM BusInfo WHERE Ffrom='"+from+"' AND PickupTime='"+picktime+"' AND Tto='"+TTo+"' AND DropTime='"+droptime+"'",conn);
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT Busno FROM BusInfo", conn);
            conn.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox1.DataSource = dt;
            conn.Close();

           
        }
        void searchreservation()
        {
            fromto();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Reservation WHERE Seatno='" + textBox1.Text + "' AND Date='" + dateTimePicker1.Text + "' AND Busno='" + comboBox1.Text + "'", conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                textBox2.Text = sdr[1].ToString();
                textBox3.Text = sdr[2].ToString();
                textBox4.Text = sdr[3].ToString();
                if (sdr[4].ToString() == "Male")
                {
                    radioButton1.Checked = true;                   
                }
                else if (sdr[4].ToString() == "Female")
                {
                    radioButton2.Checked = true;                    
                }

                textBox5.Text = sdr[5].ToString();
                textBox6.Text = sdr[6].ToString();
                textBox8.Text = sdr[7].ToString();
                textBox9.Text = sdr[8].ToString();
            }
            conn.Close();
        }
        private void button1_Click1(object sender, EventArgs e)
        {
            textBox1.Text = button1.Text;
            searchreservation();
        }

        void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox5.Clear();
            textBox6.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }
       void clearcolor()
       {
           button1.BackColor = Color.Transparent;
           button2.BackColor = Color.Transparent;
           button4.BackColor = Color.Transparent;
           button5.BackColor = Color.Transparent;
           button6.BackColor = Color.Transparent;
           button7.BackColor = Color.Transparent;
           button8.BackColor = Color.Transparent;
           button9.BackColor = Color.Transparent;
           button10.BackColor = Color.Transparent;
           button11.BackColor = Color.Transparent;
           button12.BackColor = Color.Transparent;
           button13.BackColor = Color.Transparent;
           button14.BackColor = Color.Transparent;
           button15.BackColor = Color.Transparent;
           button16.BackColor = Color.Transparent;
           button17.BackColor = Color.Transparent;
           button18.BackColor = Color.Transparent;
           button19.BackColor = Color.Transparent;
           button20.BackColor = Color.Transparent;
           button21.BackColor = Color.Transparent;
           button22.BackColor = Color.Transparent;
           button23.BackColor = Color.Transparent;
           button24.BackColor = Color.Transparent;
           button25.BackColor = Color.Transparent;
           button26.BackColor = Color.Transparent;
           button28.BackColor = Color.Transparent;
           button29.BackColor = Color.Transparent;
           button30.BackColor = Color.Transparent;
           button31.BackColor = Color.Transparent;
           button32.BackColor = Color.Transparent;
        }
       void changecolor()
       {

           SqlCommand cmd = new SqlCommand("SELECT COUNT(Seatno) FROM Reservation WHERE Date='" + dateTimePicker1.Text + "' AND Busno='" + textBox9.Text + "'", conn);
           conn.Open();
           SqlDataReader sdr = cmd.ExecuteReader();
           while (sdr.Read())
           {
               numres = int.Parse(sdr[0].ToString());
           }
           conn.Close();

           SqlDataAdapter sda = new SqlDataAdapter("Select * FROM Reservation WHERE Date='" + dateTimePicker1.Text + "' AND Busno='" + textBox9.Text + "'", conn);
           conn.Open();
           DataTable dt = new DataTable();
           sda.Fill(dt);
           for (int x = 0; x < numres; x++)
           {
               int b = int.Parse(dt.Rows[x]["Seatno"].ToString());
               string gen = dt.Rows[x]["Gender"].ToString();
               string date = dt.Rows[x]["Date"].ToString();
               switch (b)
               {
                   case 1:
                       if (gen == "Male")
                       {
                           button1.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button1.BackColor = Color.Green;
                       }
                       else
                       {
                           button1.BackColor = Color.Transparent;
                       }
                       break;

                   case 2:
                       if (gen == "Male")
                       {
                           button2.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button2.BackColor = Color.Green;
                       }
                       else
                       {
                           button2.BackColor = Color.Transparent;
                       }
                       break;

                   case 3:
                       if (gen == "Male")
                       {
                           button3.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button3.BackColor = Color.Green;
                       }
                       else
                       {
                           button3.BackColor = Color.Transparent;
                       }
                       break;

                   case 4:
                       if (gen == "Male")
                       {
                           button4.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button4.BackColor = Color.Green;
                       }
                       else
                       {
                           button4.BackColor = Color.Transparent;
                       }
                       break;

                   case 5:
                       if (gen == "Male")
                       {
                           button5.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button5.BackColor = Color.Green;
                       }
                       else
                       {
                           button5.BackColor = Color.Transparent;
                       }
                       break;

                   case 6:
                       if (gen == "Male")
                       {
                           button6.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button6.BackColor = Color.Green;
                       }
                       else
                       {
                           button6.BackColor = Color.Transparent;
                       }
                       break;

                   case 7:
                       if (gen == "Male")
                       {
                           button7.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button7.BackColor = Color.Green;
                       }
                       else
                       {
                           button7.BackColor = Color.Transparent;
                       }
                       break;

                   case 8:
                       if (gen == "Male")
                       {
                           button8.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button8.BackColor = Color.Green;
                       }
                       else
                       {
                           button8.BackColor = Color.Transparent;
                       }
                       break;

                   case 9:
                       if (gen == "Male")
                       {
                           button9.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button9.BackColor = Color.Green;
                       }
                       else
                       {
                           button9.BackColor = Color.Transparent;
                       }
                       break;

                   case 10:
                       if (gen == "Male")
                       {
                           button10.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button10.BackColor = Color.Green;
                       }
                       else
                       {
                           button10.BackColor = Color.Transparent;
                       }
                       break;
                   case 11:
                       if (gen == "Male")
                       {
                           button11.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button11.BackColor = Color.Green;
                       }
                       else
                       {
                           button11.BackColor = Color.Transparent;
                       }
                       break;

                   case 12:
                       if (gen == "Male")
                       {
                           button12.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button12.BackColor = Color.Green;
                       }
                       else
                       {
                           button12.BackColor = Color.Transparent;
                       }
                       break;

                   case 13:
                       if (gen == "Male")
                       {
                           button13.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button13.BackColor = Color.Green;
                       }
                       else
                       {
                           button13.BackColor = Color.Transparent;
                       }
                       break;

                   case 14:
                       if (gen == "Male")
                       {
                           button14.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button14.BackColor = Color.Green;
                       }
                       else
                       {
                           button14.BackColor = Color.Transparent;
                       }
                       break;

                   case 15:
                       if (gen == "Male")
                       {
                           button15.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button15.BackColor = Color.Green;
                       }
                       else
                       {
                           button15.BackColor = Color.Transparent;
                       }
                       break;

                   case 16:
                       if (gen == "Male")
                       {
                           button16.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button16.BackColor = Color.Green;
                       }
                       else
                       {
                           button16.BackColor = Color.Transparent;
                       }
                       break;

                   case 17:
                       if (gen == "Male")
                       {
                           button17.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button17.BackColor = Color.Green;
                       }
                       else
                       {
                           button17.BackColor = Color.Transparent;
                       }
                       break;

                   case 18:
                       if (gen == "Male")
                       {
                           button18.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button18.BackColor = Color.Green;
                       }
                       else
                       {
                           button18.BackColor = Color.Transparent;
                       }
                       break;

                   case 19:
                       if (gen == "Male")
                       {
                           button19.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button19.BackColor = Color.Green;
                       }
                       else
                       {
                           button19.BackColor = Color.Transparent;
                       }
                       break;

                   case 20:
                       if (gen == "Male")
                       {
                           button20.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button20.BackColor = Color.Green;
                       }
                       else
                       {
                           button20.BackColor = Color.Transparent;
                       }
                       break;

                   case 21:
                       if (gen == "Male")
                       {
                           button21.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button21.BackColor = Color.Green;
                       }
                       else
                       {
                           button21.BackColor = Color.Transparent;
                       }
                       break;

                   case 22:
                       if (gen == "Male")
                       {
                           button22.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button22.BackColor = Color.Green;
                       }
                       else
                       {
                           button22.BackColor = Color.Transparent;
                       }
                       break;

                   case 23:
                       if (gen == "Male")
                       {
                           button23.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button23.BackColor = Color.Green;
                       }
                       else
                       {
                           button23.BackColor = Color.Transparent;
                       }
                       break;

                   case 24:
                       if (gen == "Male")
                       {
                           button24.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button24.BackColor = Color.Green;
                       }
                       else
                       {
                           button24.BackColor = Color.Transparent;
                       }
                       break;

                   case 25:
                       if (gen == "Male")
                       {
                           button25.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button25.BackColor = Color.Green;
                       }
                       else
                       {
                           button25.BackColor = Color.Transparent;
                       }
                       break;

                   case 26:
                       if (gen == "Male")
                       {
                           button26.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button26.BackColor = Color.Green;
                       }
                       else
                       {
                           button26.BackColor = Color.Transparent;
                       }
                       break;

                   case 27:
                       if (gen == "Male")
                       {
                           button27.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button27.BackColor = Color.Green;
                       }
                       else
                       {
                           button27.BackColor = Color.Transparent;
                       }
                       break;

                   case 28:
                       if (gen == "Male")
                       {
                           button28.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button28.BackColor = Color.Green;
                       }
                       else
                       {
                           button28.BackColor = Color.Transparent;
                       }
                       break;

                   case 29:
                       if (gen == "Male")
                       {
                           button29.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button29.BackColor = Color.Green;
                       }
                       else
                       {
                           button29.BackColor = Color.Transparent;
                       }
                       break;

                   case 30:
                       if (gen == "Male")
                       {
                           button30.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button30.BackColor = Color.Green;
                       }
                       else
                       {
                           button30.BackColor = Color.Transparent;
                       }
                       break;

                   case 31:
                       if (gen == "Male")
                       {
                           button31.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button31.BackColor = Color.Green;
                       }
                       else
                       {
                           button31.BackColor = Color.Transparent;
                       }
                       break;

                   case 32:
                       if (gen == "Male")
                       {
                           button32.BackColor = Color.Red;
                       }
                       else if (gen == "Female")
                       {
                           button32.BackColor = Color.Green;
                       }
                       else
                       {
                           button32.BackColor = Color.Transparent;
                       }
                       break;
               }
           }
           conn.Close();
       }



        int numres;
        //string date;
        private void button36_Click(object sender, EventArgs e)
        {
            clearcolor();
            clear();
            fromto();
            textBox8.Text = dateTimePicker1.Text;
            textBox9.Text = comboBox1.Text;
            changecolor();
           
        }

        private void button33_Click_1(object sender, EventArgs e)
        {
            String g = "a";
            if (radioButton1.Checked == true)
            {
                g = "Male";
            }
            else if (radioButton2.Checked == true)
            {
                g = "Female";
            }
            else
            {
                MessageBox.Show("Select your Gender!!");
            }

            SqlCommand cmd = new SqlCommand("INSERT INTO Reservation(Seatno,Name,Phoneno,Address,Gender,Ffrom,Tto,Date,Busno) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + g + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Text + "','" + textBox9.Text + "')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully seat is reserved!!", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            clear();

        }
        void delete()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox5.Clear();
            textBox6.Clear();

        }

        private void button34_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Reservation WHERE Seatno='" + textBox1.Text + "' AND Busno='"+comboBox1.Text+"' AND Date='"+dateTimePicker1.Text+"'", conn);
            conn.Close();
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Reservation cancelled!!", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            conn.Close();
            delete();          
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button1.Text;
            searchreservation();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button2.Text;
            searchreservation();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button3.Text;
            searchreservation();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button4.Text;
            searchreservation();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button5.Text;
            searchreservation();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button6.Text;
            searchreservation();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button7.Text;
            searchreservation();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button8.Text;
            searchreservation();
        }


        private void button35_Click(object sender, EventArgs e)
        {
            String g = "a";
            if (radioButton1.Checked == true)
            {
                g = "Male";
            }
            else if (radioButton2.Checked == true)
            {
                g = "Female";
            }
            else
            {
                MessageBox.Show("Select your Gender!!");
            }

            SqlCommand cmd = new SqlCommand("UPDATE Reservation SET Seatno='" + textBox1.Text + "',Name='" + textBox2.Text + "',Phoneno='" + textBox3.Text + "',Address='" + textBox4.Text + "',Gender='" + g + "',Ffrom='" + textBox5.Text + "',Tto='" + textBox6.Text + "',Date='" + textBox8.Text + "',Busno='" + textBox9.Text + "' WHERE Seatno='" + textBox1.Text + "' AND Busno='"+comboBox1.Text+"' AND Date='"+dateTimePicker1.Text+"'", conn);
            conn.Close();
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Reservation Details Updated succesfully!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            clear();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button9.Text;
            searchreservation();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button10.Text;
            searchreservation();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button11.Text;
            searchreservation();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button12.Text;
            searchreservation();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button13.Text;
            searchreservation();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button14.Text;
            searchreservation();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button15.Text;
            searchreservation();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button16.Text;
            searchreservation();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button17.Text;
            searchreservation();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button18.Text;
            searchreservation();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button19.Text;
            searchreservation();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button20.Text;
            searchreservation();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button21.Text;
            searchreservation();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button22.Text;
            searchreservation();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button23.Text;
            searchreservation();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button24.Text;
            searchreservation();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button25.Text;
            searchreservation();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button26.Text;
            searchreservation();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button27.Text;
            searchreservation();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button28.Text;
            searchreservation();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button29.Text;
            searchreservation();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button30.Text;
            searchreservation();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button31.Text;
            searchreservation();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            clear();
            textBox9.Text = comboBox1.Text;
            textBox8.Text = dateTimePicker1.Text;
            textBox1.Text = button32.Text;
            searchreservation();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            clear();
        }
    }

 }


