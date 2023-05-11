using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;

namespace CarMultiLease
{
    public partial class RentalCar : Form
    {
        public RentalCar()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CV0FGMQ\SQLEXPRESS;Initial Catalog=MultiLeseDB;Integrated Security=True");

        private void populate()
        {
            conn.Open();
            string querry = "select * from RentalTbl";
            SqlDataAdapter da = new SqlDataAdapter(querry, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm main = new MainForm();
            main.Show();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            if (NIVno.Text == "" || ClientId.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string querry = "insert into RentalTbl values('" + NIVno.Text + "', '" + ClientId.Text + "','" + Modeletxt.Text + "','" + Emailtxt.Text + "','"+ Kilometre.Text+ "','"+ Mobiletxt .Text+ "','"+ Duration .SelectedItem.ToString()+ "','"+ Pricetxt.Text+ "')";
                    SqlCommand cmd = new SqlCommand(querry, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car added Successfully ");
                    conn.Close();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NIVno.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            ClientId.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Modeletxt.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            Emailtxt.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            Kilometre.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            Mobiletxt.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            Duration.SelectedItem = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            Pricetxt.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

        }

        private void RentalCar_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NIVno.Text = "";
            ClientId.Text = "";
            Modeletxt.Text = "";
            Emailtxt.Text = "";
            Kilometre.Text = "";
            Mobiletxt.Text = "";
            Duration.SelectedItem = "";
            Pricetxt.Text = "";
        }

        private void ClientId_Enter(object sender, EventArgs e)
        {
            if (ClientId.Text == "Customer Id")
            {
                ClientId.Text = "";

                ClientId.ForeColor = Color.Black;
            }
        }

        private void ClientId_Leave(object sender, EventArgs e)
        {
            if (ClientId.Text == "")
            {
                ClientId.Text = "Customer Id";

                ClientId.ForeColor = Color.Silver;
            }
        }
    }
}
