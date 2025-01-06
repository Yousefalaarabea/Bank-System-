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

namespace Bankform1
{
    public partial class Adminlogin : Form
    {
        public Adminlogin()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            if(textBox1.Text == "" || textBox2.Text == "")
            {
                  MessageBox.Show("Enter Username & Password");
            }
            else
            {
                  SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
                  SqlCommand sqlcommand = new SqlCommand();
                  sqlcommand.Connection = sqlconnection;
                  sqlconnection.Open();
                  SqlDataAdapter adapter = new SqlDataAdapter("select count(*) from ADMIN where USER_NAME= '"+textBox1.Text+"' and PASSWORD= '"+ textBox2.Text +"'",sqlconnection);
                  DataTable dt = new DataTable();
                  adapter.Fill(dt);
                  if (dt.Rows[0][0].ToString()== "1")
                  {
                      AdminMainMenu obj = new AdminMainMenu();
                      obj.Show();
                      this.Hide();
                      sqlconnection.Close();
                  }
                  else
                  {
                      MessageBox.Show("Wrong Admin name or PassWord");
                      textBox1.Text = "";
                      textBox2.Text = "";
                  }
                  sqlconnection.Close();
            }
        }

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AdminSignUp adminSignUp = new AdminSignUp();
            adminSignUp.Show();
            this.Hide();
        }

        private void gunaPictureBox2_Click_1(object sender, EventArgs e)
        {
            Role Obj = new Role();
            Obj.Show();
            this.Hide();
        }
    }
}
