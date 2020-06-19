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
    public partial class Admin_Form : Form
    {
        //read the info from the customers text file and initialize valuable
        string[] customers = File.ReadAllLines("customerInfo.txt");
        int LLTotal;
        int CLTotal;
        int UDTotal;
        double TotalSales;

        public Admin_Form()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            //Query of the customers array to load into Datagrid from customersInfo file
            var DatagridQuery = from name in customers
                                let getdata = name.Split(',')
                                let getname = getdata[0]
                                let useremail = getdata[1]
                                let totalcost = getdata[6]
                                let confirm = getdata[10]
                                let ll = getdata[7]
                                let cl = getdata[8]
                                let ud = getdata[9]
                                select new { getname, useremail, totalcost, confirm, ll, cl, ud };
            foreach ( var i in DatagridQuery)
            {
                //load datagrid
                dataGridView1.Rows.Add(i.getname, i.useremail, i.totalcost, i.confirm, i.ll, i.cl, i.ud);

                //compute total numbers of seats purchase
                LLTotal += int.Parse(i.ll);
                CLTotal += int.Parse(i.cl);
                UDTotal += int.Parse(i.ud);
                TotalSales += double.Parse(i.totalcost);

            }

            lblDisplayLower.Text = (200 - LLTotal).ToString();
            lblDisplayClub.Text = (75 - CLTotal).ToString();
            lblDisplayUpper.Text = (200 - UDTotal).ToString();
            lblAdminTotal.Text = "Total Sales " + TotalSales.ToString("c");


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string confirmNum = txtConfirm.Text;
            // Query to find confirmation number of customer associated with
            var searchNameQuery = from purchase in customers
                                  let searchNum = purchase.Split(',')
                                  let confirm = searchNum[10]
                                  let name = searchNum[0]
                                  let amtcharge = searchNum[6]
                                  select new { confirm, name, amtcharge };
            //look for matched confirmation number
            foreach (var result in searchNameQuery)
            {
                if(confirmNum == result.confirm)
                {
                    MessageBox.Show("Found Confirmation number: " + result.confirm + "\n" + "Name: " + result.name + "\n" + "Total Charge: $" + result.amtcharge, "Confirmation Found");
                }
            }
            //hightlight the row
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[3].Value.ToString().Equals(confirmNum))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }catch
            {
                MessageBox.Show("Confirmation number does not exist", "Confirmation not Found");
            }


        }

        private void Admin_Form_Load(object sender, EventArgs e)
        {

        }

        private void lblAdminTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
