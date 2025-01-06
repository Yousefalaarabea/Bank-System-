using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Layout;
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
    public partial class AddBranch : Form
    {
        public AddBranch()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
        }
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {         
                SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;
                sqlconnection.Open();
                sqlcommand.CommandText = "INSERT INTO BRANCH Values('" + textBox5.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "')";
                sqlcommand.ExecuteNonQuery();
                sqlconnection.Close();
                Reset();
                MessageBox.Show("Branch Added Successfuly");
 
        }
        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            sqlconnection.Open();

            
            string deleteLoanQuery = "DELETE FROM LOAN WHERE SSN IN (SELECT SSN FROM CUSTOMER WHERE BRANCH_NO = @bno);"; //delete the loan related to customer in the branch
            SqlCommand deleteLoanCommand = new SqlCommand(deleteLoanQuery, sqlconnection);
            deleteLoanCommand.Parameters.AddWithValue("@bno", textBox5.Text);
            deleteLoanCommand.ExecuteNonQuery();


            string deletecustQuery = "DELETE FROM CUSTOMER WHERE BRANCH_NO = @bno;";// Delete the BRANCH from customer
            SqlCommand deletecustCommand = new SqlCommand(deletecustQuery, sqlconnection);
            deletecustCommand.Parameters.AddWithValue("@bno", textBox5.Text);
            deletecustCommand.ExecuteNonQuery();


            string deletebranchQuery = "DELETE FROM BRANCH WHERE BRANCH_NO = @bno;"; // Delete the BRANCH from BRANCH
            SqlCommand deletebranchCommand = new SqlCommand(deletebranchQuery, sqlconnection);
            deletebranchCommand.Parameters.AddWithValue("@bno", textBox5.Text);
            deletebranchCommand.ExecuteNonQuery();

            sqlconnection.Close();

            MessageBox.Show("Successfully Deleted");
            Reset();



        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            sqlconnection.Open();
            string query = "SELECT * FROM BRANCH";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlconnection);
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

        private void AddBranch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankDataSet.ADMIN' table. You can move, or remove it, as needed.
            this.aDMINTableAdapter2.Fill(this.bankDataSet.ADMIN);
            // TODO: This line of code loads data into the 'bankDataSet.BANK' table. You can move, or remove it, as needed.
            this.bANKTableAdapter1.Fill(this.bankDataSet.BANK);
            
            

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            AdminMainMenu obj = new AdminMainMenu();
            obj.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        
        int key = 0;
        private void gunaDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox2.Text = gunaDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = gunaDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            
            if (textBox5.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
