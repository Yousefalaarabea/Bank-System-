using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bankform1
{
    public partial class AdminSignUp : Form
    {
        public AdminSignUp()
        {
            InitializeComponent();
            textBox6.PasswordChar = '*';
        }

        private void AdminSignUp_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" ||textBox3.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Enter All Fields");
            }
            
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlconnection.Open();
            sqlcommand.CommandText = "INSERT INTO ADMIN Values('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox6.Text + "') ";
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            Reset();
            MessageBox.Show("Account Created Successfuly");
            this.Hide();
            Adminlogin obj = new Adminlogin();
            obj.Show();

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancelled");
            Adminlogin obj = new Adminlogin();
            obj.Show();
            this.Hide();
        }

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
