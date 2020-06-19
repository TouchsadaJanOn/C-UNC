using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project7
{
    public partial class Admin_Login : Form
    {
       
        public Admin_Login()
        {
            InitializeComponent();
        }

        private void btnadminLogin_Click(object sender, EventArgs e)
        {
            //verify that the users have correct username and password to continue
            if (txtAdminUser.Text == "admin" && txtAdminPass.Text == "BACS287") 
            {
                //if correct input, form will launch
                Admin_Form open = new Admin_Form();
                open.Show();

            }
            else
            {
                // if incorrect input, error message will occur
                MessageBox.Show("Incorrect Username or Password was entered!");
                txtAdminPass.Clear();
                txtAdminUser.Clear();
            }
        }

        private void Admin_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
