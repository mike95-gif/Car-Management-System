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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int startpoint = 0 ;

        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            progressBar1.Value= startpoint;
            if (progressBar1.Value == 100) {
                progressBar1.Value = 0;
                timer1.Stop();
                login log= new login();
                log.Show();
                this.Hide();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
