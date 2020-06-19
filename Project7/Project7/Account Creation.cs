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
using System.Text.RegularExpressions;

namespace Project7
{
    public partial class Account_Creation : Form
    {
        //boolean variables to do error-checks on the text boxes
        bool LetterChecker = true;
        bool AgeChecker = true;
        bool Emaildup = true;
        //to check if email already exist 
        string[] customer = File.ReadAllLines("useraccounts.txt");

        public Account_Creation()
        {
            InitializeComponent();
        }
        //this method checks letters only in the name text box
        private void lettersonly()
        {
            string name = txtName.Text;
            //only looks for letter
            Regex onlyletters = new Regex("^[a-zA-Z]+$");
            Match letters = onlyletters.Match(name);

            if (letters.Success)
            {
                LetterChecker = true;
            }
            else
            {
                //message box will display error if letter was not put in
                LetterChecker = false;
                MessageBox.Show("Please enter a valid name", "Invalid name");
                txtName.Clear();
            }
        }
        //this method checks if age is above 16 and check for numeric value
        private void agecheck()
        {
            try
            {
                int age = int.Parse(txtAge.Text);
                if (age < 16)
                {
                    AgeChecker = false;
                    txtAge.Clear();
                    MessageBox.Show("You must be at least 16 to attend", "Not old enough");
                }
                else
                {
                    AgeChecker = true;
                }
            }
            catch
            {
                MessageBox.Show("Please enter a numeric age");
            }
        }
        //this method check if email already exist
        private void emailcheck()
        {
            string email = txtMakeEmail.Text;

            var emailQuery = from name in customer
                             let loademail = name.Split(',')
                             let useremail = loademail[1]
                             select new { useremail };

            foreach (var i in emailQuery)
            {
                if (i.useremail == email)
                {
                    Emaildup = false;
                    MessageBox.Show("The email address of " + txtMakeEmail.Text + " already exist. Please enter a different address!");
                    break;
                }
            }

        }
        //this method checks if the email format is correct
        public bool verifyEmail(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                MessageBox.Show("Incorrect e-mail format");
                return false;
            }
            return true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            lettersonly();
            agecheck();
            emailcheck();

            //this will add users infomation in the text file
            if (LetterChecker == true && AgeChecker == true && Emaildup == true && verifyEmail(txtMakeEmail.Text) == true)
            {
                customers.name = txtName.Text;
                customers.email = txtMakeEmail.Text;
                customers.age = int.Parse(txtAge.Text);

                string[] useraccount = new string[4];

                useraccount[0] = customers.name;
                useraccount[1] = customers.email;
                useraccount[2] = customers.age.ToString();
                useraccount[3] = txtMakePassword.Text;

                string accountload = string.Join(",", useraccount);

                File.AppendAllText("useraccounts.txt", accountload + "\r\n");

                Order open = new Order();
                open.Show();
                this.Hide();
            }
        }

        private void Account_Creation_Load(object sender, EventArgs e)
        {

        }
    }
}
