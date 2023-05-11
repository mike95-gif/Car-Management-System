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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee empl= new Employee();
            empl.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            login log = new login();
            log.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Client Cl = new Client();
            Cl.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Car car= new Car();
            car.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            RentalCar rental = new RentalCar();
            rental.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReturnedCar RtnCar = new ReturnedCar();
            RtnCar.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Paiment paiement= new Paiment();
            paiement.Show();

        }
    }
}
