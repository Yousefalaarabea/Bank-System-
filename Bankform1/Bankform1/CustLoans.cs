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
    public partial class CustLoans : Form
    {
        public CustLoans()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";

        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" ||textBox4.Text == "" ||comboBox1.Text == "" ||comboBox2.Text == "" ||comboBox3.Text == "")
            {
                MessageBox.Show("Enter All Fields");
            }
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlconnection.Open();
            sqlcommand.CommandText = "INSERT INTO LOAN Values('" + textBox2.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + textBox4.Text   + "','" +"Waiting"+ "') ";
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            Reset();
            MessageBox.Show("Loan Requested Successfuly");
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankDataSet.BRANCH' table. You can move, or remove it, as needed.
            this.bRANCHTableAdapter1.Fill(this.bankDataSet.BRANCH);
            // TODO: This line of code loads data into the 'bankDataSet.EMPLOYEE' table. You can move, or remove it, as needed.
            this.eMPLOYEETableAdapter1.Fill(this.bankDataSet.EMPLOYEE);
           }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string input = textBox3.Text;
            int ssn;
            if (int.TryParse(input, out ssn))
            {
                SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
                sqlconnection.Open();
                string query = "SELECT LOAN_NO,ID ,BRANCH_NO, SSN, LOAN_TYPE, LOAN_STATUS, LOAN_AMOUNT FROM LOAN WHERE SSN = '" + ssn + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlconnection);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                gunaDataGridView1.DataSource = ds.Tables[0];
                sqlconnection.Close();
            }
            else
            {
                MessageBox.Show("Enter Valid SSN");
            }
        }

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            CustomerMainMenu customerMainMenu = new CustomerMainMenu();
            customerMainMenu.Show();
            this.Hide();
        }
    }
}
