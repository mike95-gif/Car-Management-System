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
    public partial class ReturnedCar : Form
    {
        public ReturnedCar()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm main = new MainForm();
            main.Show();
        }
    }
}
