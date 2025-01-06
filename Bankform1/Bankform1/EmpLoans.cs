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
    public partial class EmpLoans : Form
    {
        public EmpLoans()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
        private void EmpLoans_Load(object sender, EventArgs e)
        {

        }


        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }  
        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (textBox3.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            }

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(textBox3.Text=="" || comboBox1.Text == "")
            {
                MessageBox.Show("Please Fill all fields");
            }
            else
            {
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlconnection.Open();
            sqlcommand.CommandText = "UPDATE  LOAN Set LOAN_STATUS='" + comboBox1.Text + "ed' Where LOAN_NO='" + textBox3.Text + "'";
            sqlcommand.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            sqlconnection.Close();
            Reset();
            }
        }


        private void Reset()
        {
            textBox3.Text = "";
            comboBox1.Text = "";
        }
        int key = 0;  
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {      
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            sqlconnection.Open();
            string query = "SELECT Distinct LOAN.*,CUSTOMER.FIRST_NAME1,CUSTOMER.LAST_NAME2,EMPLOYEE.NAME from LOAN,CUSTOMER,EMPLOYEE Where  LOAN.SSN=CUSTOMER.SSN AND LOAN.ID ='" + textBox1.Text +"'"; 
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlconnection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gunaDataGridView1.DataSource = ds.Tables[0];
            sqlconnection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            EmployeeMainmenu employeeMainmenu = new EmployeeMainmenu();
            employeeMainmenu.Show();
            this.Hide();
        }
    }
}
