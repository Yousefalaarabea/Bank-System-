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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace Bankform1
{
    public partial class Empcust : Form
    {
        public Empcust()
        {
            InitializeComponent();
            DisplayAcoounts();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "" ||textBox5.Text == "" ||textBox6.Text == "" ||textBox7.Text == "")
            {
                MessageBox.Show("Enter All Fields");
            }
            else { 
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlconnection.Open();
            sqlcommand.CommandText = "INSERT INTO CUSTOMER Values('" + textBox1.Text + "','" + comboBox1.Text+ "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox3.Text + "','" + textBox7.Text + "') ";
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            Reset();
            MessageBox.Show("Customer Added Successfuly");
            DisplayAcoounts();
            }
        }
        private void DisplayAcoounts()
        {
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            sqlconnection.Open();
            string query = "select * from CUSTOMER";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlconnection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gunaDataGridView1.DataSource = ds.Tables[0];
            sqlconnection.Close();
        }
       
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
           

            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            sqlconnection.Open();

            
            string deleteLoanQuery = "DELETE FROM LOAN WHERE SSN = @ssn;";// Delete the customer from loan
            SqlCommand deleteLoanCommand = new SqlCommand(deleteLoanQuery, sqlconnection);
            deleteLoanCommand.Parameters.AddWithValue("@ssn", textBox1.Text);
            deleteLoanCommand.ExecuteNonQuery();

            
            string deleteCustomerQuery = "DELETE FROM CUSTOMER WHERE SSN = @ssn;"; // Delete the customer from customer
            SqlCommand deleteCustomerCommand = new SqlCommand(deleteCustomerQuery, sqlconnection);
            deleteCustomerCommand.Parameters.AddWithValue("@ssn", textBox1.Text);
            deleteCustomerCommand.ExecuteNonQuery();

            sqlconnection.Close();

            MessageBox.Show("Successfully Deleted");
            Reset();
            DisplayAcoounts();


        }

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton23_Click_1(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlconnection.Open();
            sqlcommand.CommandText = "UPDATE CUSTOMER Set BRANCH_NO='" + comboBox1.Text + "',FIRST_NAME1='" + textBox2.Text + "',LAST_NAME2='" + textBox5.Text + "',PHONE='" + textBox6.Text + "',ADDERSS ='" + textBox3.Text + "',CUSTOMER_EMAIL='" + textBox7.Text + "' Where SSN='" + textBox1.Text + "' ";
            sqlcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            sqlconnection.Close();
            Reset();
            DisplayAcoounts();
            

        }

        private void Reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        int key = 0;
        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = gunaDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = gunaDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox6.Text = gunaDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox3.Text = gunaDataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = gunaDataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            if (textBox1.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            }
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void Addaccount_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankDataSet.BRANCH' table. You can move, or remove it, as needed.
            this.bRANCHTableAdapter1.Fill(this.bankDataSet.BRANCH);
            // TODO: This line of code loads data into the 'bankDataSet2.BRANCH' table. You can move, or remove it, as needed.
            this.bRANCHTableAdapter.Fill(this.bankDataSet2.BRANCH);

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            EmployeeMainmenu obj = new EmployeeMainmenu();
            obj.Show();
            this.Hide();
        }
    }
}
