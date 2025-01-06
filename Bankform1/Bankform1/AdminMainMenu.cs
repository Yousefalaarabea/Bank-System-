using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bankform1
{
    public partial class AdminMainMenu : Form
    {
        public AdminMainMenu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {
           AddBank addBank = new AddBank();
            addBank.Show();
            this.Hide();
        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            AdminLoanDetails adminLoanDetails = new AdminLoanDetails();
            adminLoanDetails.Show();
            this.Hide();    
        }

        
        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaPictureBox6_Click(object sender, EventArgs e)
        {
            AddBranch addBranch = new AddBranch();
            addBranch.Show();
            this.Hide();
        }

        private void gunaPictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            REPORT rEPORT = new REPORT();
            rEPORT.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
