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
    public partial class AdminLoanDetails : Form
    {
        public AdminLoanDetails()
        {
            InitializeComponent();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            sqlconnection.Open();
            string query = "SELECT LOAN.* , NAME  ,CUSTOMER.FIRST_NAME1 as CUST_FirstName ,CUSTOMER.LAST_NAME2 as CUST_LastName  FROM EMPLOYEE,CUSTOMER,LOAN Where LOAN.SSN = CUSTOMER.SSN AND LOAN.ID = EMPLOYEE.ID ";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlconnection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gunaDataGridView1.DataSource = ds.Tables[0];
            sqlconnection.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            gunaDataGridView1.DataSource = null; 
        }

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            AdminMainMenu obj = new AdminMainMenu();
            obj.Show();
            this.Hide();
        }
    }
}
