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
    public partial class Order : Form
    {
        string[] customersTotal = File.ReadAllLines("customerInfo.txt");

        bool soldoutll = false;
        bool soldoutcl = false;
        bool soldoutud = false;

        public Order()
        {
            //initial 0 for the combo box
            InitializeComponent();
            cmbLower.Text = "0";
            cmbClub.Text = "0";
            cmbUpper.Text = "0";
            soldoutchecker();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void soldoutchecker()
        {
            int llSeats = 0;
            int clSeats = 0;
            int udSeats = 0;
            //get seat purchased already
            var getSeatQuery = from i in customersTotal
                               let seatTotal = i.Split(',')
                               let ll = seatTotal[7]
                               let cl = seatTotal[8]
                               let ud = seatTotal[9]
                               select new { ll, cl, ud };
            //tally all of the seats already purchased
            foreach (var total in getSeatQuery)
            {
                llSeats += int.Parse(total.ll);
                clSeats += int.Parse(total.cl);
                udSeats += int.Parse(total.ud);
            }
            //get the total amount of seats remaining
            int llTotal = 0;
            int clTotal = 0;
            int udTotal = 0;

            llTotal = 200 - llSeats - int.Parse(cmbLower.Text);
            clTotal = 75 - clSeats - int.Parse(cmbClub.Text);
            udTotal = 200 - udSeats - int.Parse(cmbUpper.Text);



            // determine if the levels are soldout
            if (llTotal < 0 && soldoutll == false)
            {
                MessageBox.Show("There is not enough number of tickets remaining. Please reduce number of ticket");
            }
            else if (llTotal == 0)
            { 
                MessageBox.Show("Sorry, but the Lower level section is sold out");
                lblLower.Text = "Sold Out";
                lblLower.ForeColor = Color.Red;
                cmbLower.Text = "0";
                cmbLower.Visible = false;
                soldoutll = true;
            }
            else
            {
                //get the number tickets from the user and convert it to integers
                customers.LLseats = int.Parse(cmbLower.Text);
            }
            if (clTotal < 0 && soldoutcl == false)
            {
                MessageBox.Show("There is not enough number of tickets remaining. Please reduce number of ticket");
            }
            else if (clTotal == 0)
            { 
                MessageBox.Show("Sorry, but the Club level section is sold out");
                lblClub.Text = "Sold Out";
                lblClub.ForeColor = Color.Red;
                cmbClub.Text = "0";
                cmbClub.Visible = false;
                soldoutcl = true;
            }
            else
            {
                //get the number tickets from the user and convert it to integers
                customers.CLseats = int.Parse(cmbClub.Text);
            }
            if (udTotal < 0 && soldoutud == false)
            {
                MessageBox.Show("There is not enough number of tickets remaining. Please reduce number of ticket");
            }
            else if (udTotal == 0)
            { 
                MessageBox.Show("Sorry, but the Upper Deck level section is sold out");
                lblUpper.Text = "Sold Out";
                lblUpper.ForeColor = Color.Red;
                cmbUpper.Text = "0";
                cmbUpper.Visible = false;
                soldoutud = true;
            }
            else
            {
                //get the number tickets from the user and convert it to integers
                customers.UDseats = int.Parse(cmbUpper.Text);
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {

            
            soldoutchecker();

            customers.TotalCost(customers.LLseats, customers.CLseats, customers.UDseats);
            if (customers._TotalCost > 0)
            {  
                //once click buy, next form will launch
                Purchase open = new Purchase();
                open.Show();
                this.Close();
            }
            
            else
            {
                MessageBox.Show("Please select a number of tickets");
            }

        }
       

        private void cmbLower_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Order_Load(object sender, EventArgs e)
        {
            
        }

        private void grpOrder_Enter(object sender, EventArgs e)
        {

        }
    }
}
