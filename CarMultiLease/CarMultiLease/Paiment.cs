using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarMultiLease
{
    public partial class Paiment : Form
    {
        public Paiment()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Back to the Main form 

            this.Close();
            MainForm main = new MainForm();
            main.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            // Printing out the details about the client and the amount 


            ResultTxt.Clear();
            ResultTxt.Text += "********************************************\n";
            ResultTxt.Text += "***     MultiLease Car Receipt            ***\n";
            ResultTxt.Text += "********************************************\n";
            ResultTxt.Text += "Date :"+DateTime.Now+"\n\n";

            ResultTxt.Text += "Client Id : " +ClientIdTxt.Text+"\n\n";
            ResultTxt.Text += "Name      : "+NameTxt.Text+"\n\n";
            ResultTxt.Text += "Last-Name : " + LastNametxt.Text + "\n\n";
            ResultTxt.Text += "Mobile    : "+Mobiletxt.Text+"\n\n";
            ResultTxt.Text += "Contract Number : " + ContractNotxt.Text + "\n\n";
            ResultTxt.Text += "Duration  : " + Durationtxt.Text + "\n\n";
            ResultTxt.Text += "Amount    : " + Amounttxt.Text + "\n\n";


            ResultTxt.Text += "\n                   Signature ";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Clear all the textbox on the pressing the clear btn


            ClientIdTxt.Text = "";
            NameTxt.Text = "";
            LastNametxt.Text = "";
            Mobiletxt.Text = "";
            ContractNotxt.Text = "";
            Durationtxt.Text = "";
            Amounttxt.Text = "";

            ResultTxt.Text = "";
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(ResultTxt.Text, new Font("Microsoft Sans Serif", 18, FontStyle.Bold), Brushes.Black, new Point(10,10));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
