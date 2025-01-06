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
    public partial class Employeelogin : Form
    {
        public Employeelogin()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';   
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Enter Username & Password");
            }
            else
            {
                SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select count(*) from EMPLOYEE where  EMPLOYEE.EMPOLYEE_USER_NAME = '" + textBox1.Text + "' and EMPLOYEE.EMPLOYEE_PASSWORD= '" + textBox2.Text + "'", sqlconnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    EmployeeMainmenu obj = new EmployeeMainmenu();
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

        private void label5_Click(object sender, EventArgs e)
        {
            EmployeeSignUp employeeSignUp   = new EmployeeSignUp();
            employeeSignUp.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            Role Obj = new Role();
            Obj.Show();
            this.Hide();
        }
    }
}
