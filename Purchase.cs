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
    public partial class Purchase : Form
    {
        public Purchase()
        {
            InitializeComponent();
            lblTotalCost.Text = ("Total Cost: " + customers._TotalCost.ToString("c2"));
        }

        private void Purchase_Load(object sender, EventArgs e)
        {

        }
        private bool ccChecker(string cc)
        {
            //Looks for Digits only
            Regex numOnly = new Regex("\\d+");
            Match match = numOnly.Match(cc);

            if (match.Success && txtNum.Text.Length == 16)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Invalid Credit Card number", "Invalid card");
                return false;
            }
        }
        private bool csvCheck(string csv)
        {
            //Looks for Digits only
            Regex numOnly = new Regex("\\d+");
            Match match = numOnly.Match(csv);

            if (match.Success && txtCSV.Text.Length == 3)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Invalid CSV number", "Invalid CSV");
                return false;
            }
        }
        private bool Letters(string name)
        {
            //look for letter only
            Regex LetterOnly = new Regex("^[a-zA-Z]+$");
            Match letters = LetterOnly.Match(name);

            if (letters.Success)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Name must be letter only", "Invalid Name");
                return false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e) 
        { 
        

            if (ccChecker(txtNum.Text) == true && csvCheck(txtCSV.Text)== true && Letters(txtNameCard.Text) == true)
            {
                //get random number
                Random R = new Random();
                int randnum = R.Next(1000, 9999);

                //load customer record array
                string[] customerArray = new string[11];

                customerArray[0] = customers.name;
                customerArray[1] = customers.email;
                customerArray[2] = customers.age.ToString();
                customerArray[3] = txtNum.Text;
                customerArray[4] = txtNameCard.Text;
                customerArray[5] = txtCSV.Text;
                customerArray[6] = customers._TotalCost.ToString();
                customerArray[7] = customers.LLseats.ToString();
                customerArray[8] = customers.CLseats.ToString();
                customerArray[9] = customers.UDseats.ToString();
                customerArray[10] = randnum.ToString();

                //get confirmation
                DialogResult result = MessageBox.Show("Hello! " + customers.name + "\n" +
                    "Please confirm you Purchase of: " + customers._TotalCost.ToString("c2") +
                    "\n" + "Please click yes to confirm your order", "Confirmation", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                { // display confirmation number and array of customer informations
                    MessageBox.Show("Thank you for your order!" + "\n" + "Your confirmation number is " + randnum);
                    string customerload = string.Join(",", customerArray);
                    //write to data file
                    File.AppendAllText("customerInfo.txt", customerload + "\r\n");
                    this.Close();
                }
            }
            
        }
    }
}
