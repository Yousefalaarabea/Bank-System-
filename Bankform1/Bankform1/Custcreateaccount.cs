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
    public partial class Custcreateaccount : Form
    {
        public Custcreateaccount()
        {
            InitializeComponent();
        }

        private void Custcreateaccount_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankDataSet.BRANCH' table. You can move, or remove it, as needed.
            this.bRANCHTableAdapter2.Fill(this.bankDataSet.BRANCH);
            // TODO: This line of code loads data into the 'bankDataSet2.BRANCH' table. You can move, or remove it, as needed.
            this.bRANCHTableAdapter1.Fill(this.bankDataSet2.BRANCH);
            

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""  || textBox3.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Enter All Fields");
            }
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlconnection.Open();
            sqlcommand.CommandText = "INSERT INTO ACCOUNTS Values('" + textBox3.Text + "','" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox6.Text + "','" + comboBox2.Text +  "') ";
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            MessageBox.Show("Account Created Successfuly");
            this.Hide();
            Application.Exit();      
        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            CustomerMainMenu customerMainMenu = new CustomerMainMenu();
            customerMainMenu.Show();
            this.Hide();
        }
    }
}
