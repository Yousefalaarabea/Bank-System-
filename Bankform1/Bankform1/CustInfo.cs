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
    public partial class CustInfo : Form
    {
        public CustInfo()
        {
            InitializeComponent();
        }

        private void CustInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankDataSet.BRANCH' table. You can move, or remove it, as needed.
            this.bRANCHTableAdapter2.Fill(this.bankDataSet.BRANCH);
            // TODO: This line of code loads data into the 'bankDataSet2.BRANCH' table. You can move, or remove it, as needed.
            this.bRANCHTableAdapter1.Fill(this.bankDataSet2.BRANCH);
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
            textBox1.Text = "";
            comboBox3.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox3.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Enter All Fields");
            }
            else
            {
                SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;
                sqlconnection.Open();
                sqlcommand.CommandText = "UPDATE CUSTOMER Set BRANCH_NO='" + comboBox3.Text + "',FIRST_NAME1='" + textBox3.Text + "',LAST_NAME2='" + textBox5.Text + "',PHONE='" + textBox6.Text + "',ADDERSS='" + textBox4.Text + "',CUSTOMER_EMAIL='" + textBox7.Text + "' Where SSN='" + textBox1.Text + "' ";
                sqlcommand.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated");
                sqlconnection.Close();
                Reset();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancelled");
            Application.Exit();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            CustomerMainMenu customerMainMenu = new CustomerMainMenu();
            customerMainMenu.Show();
            this.Hide();
        }
    }
}
