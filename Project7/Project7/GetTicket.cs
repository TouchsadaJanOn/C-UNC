using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project7
{
    public partial class GetTicket : Form
    {
        public GetTicket()
        {
            InitializeComponent();
        }

        private void btnGetTicket_Click(object sender, EventArgs e)
        {//when user click on get ticket button, login form will launch
            Email_Login openform = new Email_Login();
            openform.ShowDialog();
            openform.Show();
           

        }

        private void lnkAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {//if user click on admin link, admin form will launch 
            Admin_Login open = new Admin_Login();
            open.Show();
        }

        private void GetTicket_Load(object sender, EventArgs e)
        {

        }
    }
}
