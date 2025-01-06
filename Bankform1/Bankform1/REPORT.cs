using DevExpress.XtraCharts.Native;
using Guna.UI.WinForms;
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
    public partial class REPORT : Form
    {
        public REPORT()
        {
            InitializeComponent();
        }

       

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            sqlconnection.Open();

            string query2= "select * FROM CUSTOMER LEFT JOIN LOAN on CUSTOMER.SSN = LOAN.SSN ";
            SqlDataAdapter sda = new SqlDataAdapter(query2, sqlconnection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gunaDataGridView1.DataSource = ds.Tables[0];
            sqlconnection.Close();

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            sqlconnection.Open();
            
            string query2 = "select * FROM  CUSTOMER RIGHT JOIN BRANCH on BRANCH.BRANCH_NO = CUSTOMER.BRANCH_NO ";
            SqlDataAdapter sda = new SqlDataAdapter(query2, sqlconnection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gunaDataGridView1.DataSource = ds.Tables[0];
            sqlconnection.Close();
        }

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            sqlconnection.Open();
            string query2 = "select  EMPLOYEE.ID,NAME ,EMPLOYEE.CODE,LOAN_NO,LOAN_TYPE,LOAN_STATUS from EMPLOYEE left join LOAN on EMPLOYEE.ID = LOAN.ID Where LOAN_STATUS = 'Accepted'";
            SqlDataAdapter sda = new SqlDataAdapter(query2, sqlconnection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gunaDataGridView1.DataSource = ds.Tables[0];
            sqlconnection.Close();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            sqlconnection.Open();
            string query2 = "select  EMPLOYEE.ID,NAME ,EMPLOYEE.CODE,LOAN_NO,LOAN_TYPE,LOAN_STATUS from EMPLOYEE left join LOAN on EMPLOYEE.ID = LOAN.ID Where LOAN_STATUS = 'Rejected'";
            SqlDataAdapter sda = new SqlDataAdapter(query2, sqlconnection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gunaDataGridView1.DataSource = ds.Tables[0];
            sqlconnection.Close();
        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            AdminMainMenu obj = new AdminMainMenu();
            obj.Show();
            this.Hide();
        }
    }
    
}
