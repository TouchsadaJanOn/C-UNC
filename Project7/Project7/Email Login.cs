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
    public partial class Email_Login : Form
    {
        string[] existingaccount = File.ReadAllLines("useraccounts.txt");
        public Email_Login()
        {
            InitializeComponent();
        }

        private void lblAccount_Click(object sender, EventArgs e)
        {
            Account_Creation open = new Account_Creation();
            open.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //initalized variable and use boolan to get user the access to another form
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            bool validauth = false; // determine if next form will launch


            var emailQuery = from name in existingaccount
                             let loademail = name.Split(',')
                             let useremail = loademail[1]
                             let user = loademail[0]
                             let userage = loademail[2]
                             let userpassword = loademail[3]
                             select new { useremail, user, userage, userpassword };
            foreach (var name in emailQuery)
            {//if user have correct infomation, next form will launch
                if (name.useremail == email && name.userpassword == password)
                {
                    validauth = true;
                    Order open = new Order();
                    open.Show();
                    this.Close();
                }
            }
            if (validauth == false)
            {//if user have incorrect info, error message will pop up
                MessageBox.Show("Invalid username or password!","Invalid Email or Password!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Email_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
