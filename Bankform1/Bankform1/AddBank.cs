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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Serialization;

namespace Bankform1
{
    public partial class AddBank : Form
    {
        public AddBank()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");

        private void AdminAdd_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankDataSet1.ADMIN' table. You can move, or remove it, as needed.
            this.aDMINTableAdapter4.Fill(this.bankDataSet1.ADMIN);
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Enter All Fields");
            }
            else
            {
                SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;
                sqlconnection.Open();
                sqlcommand.CommandText = "INSERT INTO Bank Values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "')";
                sqlcommand.ExecuteNonQuery();
                sqlconnection.Close();
                Reset();
                MessageBox.Show("Bank Added Successfuly");
            }
        }

       

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancelled");
            Application.Exit();

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void bunifuThinButton23_Click_1(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-DREU99S;Initial Catalog=Bank;Integrated Security=True");
            sqlconnection.Open();
            string query = "SELECT * FROM BANK";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlconnection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gunaDataGridView1.DataSource = ds.Tables[0];
            sqlconnection.Close();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            AdminMainMenu Obj = new AdminMainMenu();
            Obj.Show();
            this.Hide();
        }
    }
}
