using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Esoft_Project
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F7C56NH\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True");

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            con.Open();
            string query_select = "Select * from register";
            SqlCommand cmd = new SqlCommand(query_select, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            comboBox2.Text = "New Regiter";
            while (dataReader.Read())
            {
                comboBox2.Text = dataReader[0].ToString();
            }
            con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 Login = new Form2();
            Login.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure,do you really want to exit.....?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int regNo = int.Parse(comboBox2.Text);
                string firstName = textBox2.Text;
                string lastName = textBox1.Text;
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd/MM/yyyy";
                string gender;
                if (radioButton2.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string address = textBox4.Text;
                string email = textBox3.Text;
                int mobileNo = int.Parse(textBox5.Text);
                int homePhone = int.Parse(textBox6.Text);
                string parentName = textBox9.Text;
                string nic = textBox7.Text;
                int contacNo = int.Parse(textBox8.Text);

                string query_insert = "insert into register values ('" + regNo + "','" + firstName + "','" + lastName + "','" + dateTimePicker1.Text + "','" + gender + "', '" + address + "', '" + email + "','" + mobileNo + "','" + homePhone + "', '" + parentName + "', '" + nic + "', '" + contacNo + "')";

                SqlCommand cmd = new SqlCommand(query_insert, con);

                con.Open();

                cmd.ExecuteNonQuery();
                const string message = "Record added succesfully";
                const string caption = "register student";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while Registering" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string no = comboBox2.Text;
            if (no != "New Register")
            {
                int regNo = int.Parse(comboBox2.Text);
                string firstName = textBox2.Text;
                string lastName = textBox1.Text;
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd/MM/yyyy";
                string gender;
                if (radioButton2.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string address = textBox4.Text;
                string email = textBox3.Text;
                int mobileNo = int.Parse(textBox5.Text);
                int homePhone = int.Parse(textBox6.Text);
                string parentName = textBox9.Text;
                string nic = textBox7.Text;
                int contacNo = int.Parse(textBox8.Text);

                string query_update = "update register set firstName ='" + firstName + "',lastName = '" + lastName + "',dateOfBirth = '" + dateTimePicker1.Text + "',gender = '" + gender + "',address = '" + address + "',email = '" + email + "',mobilePhone ='" + mobileNo + "',homePhone = '" + homePhone + "',  parentName = '" + parentName + "',  nic =  '" + nic + "', contacNo = '" + contacNo + "'";

                con.Open();
                SqlCommand cmd = new SqlCommand(query_update, con);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Updated Sucessfully", "Updated register", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            DateTime today = DateTime.Today;
            dateTimePicker1.Text = today.ToString();
            radioButton2.Checked = true;
            radioButton1.Checked = false;
            textBox4.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox9.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure , do you really want to delete this record......?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string no = comboBox2.Text;
                string query_delete = "delete from register where regNo =' " + no + "'";
                con.Open();

                SqlCommand cmd = new SqlCommand(query_delete, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted Sucessfully", "Delete register", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                this.Close();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string no = comboBox2.Text;
            if (no != "New Register")
            {

                con.Open();
                string query_select = "select * from regNo where comboBox2 =" + no;
                SqlCommand cmd = new SqlCommand(query_select, con);
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    textBox2.Text = dataReader[1].ToString();
                    textBox1.Text = dataReader[2].ToString();
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.CustomFormat = "yyyy/MM/dd";
                    dateTimePicker1.Text = dataReader[3].ToString();
                    if (dataReader[4].ToString() == "Male")
                    {
                        radioButton2.Checked = true;
                        radioButton1.Checked = false;
                    }
                    else
                    {
                        radioButton2.Checked = false;
                        radioButton1.Checked = true;
                    }
                    textBox4.Text = dataReader[5].ToString();
                    textBox3.Text = dataReader[6].ToString();
                    textBox5.Text = dataReader[7].ToString();
                    textBox6.Text = dataReader[8].ToString();
                    textBox9.Text = dataReader[9].ToString();
                    textBox7.Text = dataReader[10].ToString();
                    textBox8.Text = dataReader[11].ToString();
                }
                con.Close();
                button1.Enabled = false;
                button4.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                textBox2.Text = "";
                textBox1.Text = "";
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy/MM/dd";
                DateTime today = DateTime.Today;
                dateTimePicker1.Text = today.ToString();
                radioButton2.Checked = true;
                radioButton1.Checked = false;
                textBox4.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox9.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
            }
        }
    }
}
