using DevExpress.XtraRichEdit.Commands;
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
    public partial class EmployeeSignUp : Form
    {
        public EmployeeSignUp()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox4.PasswordChar = '*';
        }
        
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "" || textBox6.Text == "" )
            {
                MessageBox.Show("Enter All Fields");
            }
            if (textBox2.Text == textBox4.Text) {
                SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;
                sqlconnection.Open();
                sqlcommand.CommandText = "INSERT INTO EMPLOYEE Values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox2.Text + "') ";
                sqlcommand.ExecuteNonQuery();
                sqlconnection.Close();
                MessageBox.Show("Account Created Successfuly");
                Employeelogin employeelogin = new Employeelogin();
                employeelogin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Password and Confirm Password doesn't match");
            }
        }

        private void EmployeeSignUp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankDataSet.BANK' table. You can move, or remove it, as needed.
            this.bANKTableAdapter.Fill(this.bankDataSet.BANK);

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancelled");
            Employeelogin employeelogin = new Employeelogin();
            employeelogin.Show();
            this.Hide();
        }
    }
}
