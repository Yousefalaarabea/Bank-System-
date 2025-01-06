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

namespace Bankform1
{
    public partial class Customerlogin : Form
    {
        public Customerlogin()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Enter Email & SSN");
            }
            else
            {
                SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select count(*) from CUSTOMER where CUSTOMER_EMAIL= '" + textBox1.Text + "' and SSN= '" + textBox2.Text + "'", sqlconnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    CustomerMainMenu obj = new CustomerMainMenu();
                    obj.Show();
                    this.Hide();
                    sqlconnection.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Email or SSN");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                sqlconnection.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {
          
        }

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            Role obj = new Role();
            obj.Show();
            this.Hide();
        }
    }
}
