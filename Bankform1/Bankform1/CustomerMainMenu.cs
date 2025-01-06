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
    public partial class CustomerMainMenu : Form
    {
        public CustomerMainMenu()
        {
            InitializeComponent();
        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            CustLoans custLoans = new CustLoans();
            custLoans.Show();
            this.Hide();
        }

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {
            CustInfo Obj = new CustInfo();
            Obj.Show();
            this.Hide();
        }

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            Custcreateaccount custcreateaccount = new Custcreateaccount();
            custcreateaccount.Show();
            this.Hide();
        }
    }
}
