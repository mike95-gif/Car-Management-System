using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarMultiLease
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CV0FGMQ\SQLEXPRESS;Initial Catalog=MultiLeseDB;Integrated Security=True");


        private void populate()
        {
            conn.Open();
            string querry = "select * from ClientTbl";
            SqlDataAdapter da = new SqlDataAdapter(querry, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ClientDGV.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void ClientId_Enter(object sender, EventArgs e)
        {
            if (ClientId.Text == "Customer ID")
            {
                ClientId.Text = "";

                ClientId.ForeColor = Color.Black;
            }
        }

        private void ClientId_Leave(object sender, EventArgs e)
        {
            if (ClientId.Text == "")
            {
                ClientId.Text = "Customer ID";

                ClientId.ForeColor = Color.Silver;
            }
        }

        private void Nametxt_Enter(object sender, EventArgs e)
        {
            if (ClientId.Text == "Name")
            {
                ClientId.Text = " ";

                ClientId.ForeColor = Color.Black;
            }
        }

        private void Nametxt_Leave(object sender, EventArgs e)
        {
            if (ClientId.Text == "")
            {
                ClientId.Text = "Name";

                ClientId.ForeColor = Color.Silver;
            }
        }

        private void LastNametxt_Enter(object sender, EventArgs e)
        {
            if (ClientId.Text == "Last-Name")
            {
                ClientId.Text = " ";

                ClientId.ForeColor = Color.Black;
            }
        }

        private void LastNametxt_Leave(object sender, EventArgs e)
        {
            if (ClientId.Text == " ")
            {
                ClientId.Text = "Last-Name";

                ClientId.ForeColor = Color.Silver;
            }
        }

        private void Mobiletxt_Enter(object sender, EventArgs e)
        {
            if (ClientId.Text == "Mobile")
            {
                ClientId.Text = " ";

                ClientId.ForeColor = Color.Black;
            }
        }

        private void Mobiletxt_Leave(object sender, EventArgs e)
        {
            if (ClientId.Text == " ")
            {
                ClientId.Text = "Mobile";

                ClientId.ForeColor = Color.Silver;
            }
        }

        private void NIVno_Enter(object sender, EventArgs e)
        {
            if (ClientId.Text == "NIV")
            {
                ClientId.Text = " ";

                ClientId.ForeColor = Color.Black;
            }
        }

        private void NIVno_Leave(object sender, EventArgs e)
        {
            if (ClientId.Text == " ")
            {
                ClientId.Text = "NIV";

                ClientId.ForeColor = Color.Silver;
            }
        }

        private void Modeletxt_Enter(object sender, EventArgs e)
        {
            if (ClientId.Text == "Model")
            {
                ClientId.Text = " ";

                ClientId.ForeColor = Color.Black;
            }
        }

        private void Modeletxt_Leave(object sender, EventArgs e)
        {
            if (ClientId.Text == " ")
            {
                ClientId.Text = "Model";

                ClientId.ForeColor = Color.Silver;
            }
        }

        private void Addressetxt_Enter(object sender, EventArgs e)
        {
            if (ClientId.Text == "Addresse")
            {
                ClientId.Text = " ";

                ClientId.ForeColor = Color.Black;
            }
        }

        private void Addressetxt_Leave(object sender, EventArgs e)
        {
            if (ClientId.Text == " ")
            {
                ClientId.Text = "Addresse";

                ClientId.ForeColor = Color.Silver;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm main = new MainForm();
            main.Show();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            if (ClientId.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string querry = "insert into ClientTbl values('" + ClientId.Text + "', '" + Nametxt.Text + "','" + LastNametxt.Text + "','"+ Mobiletxt.Text + "','"+ NIVno.Text+ "','"+ Modeletxt.Text + "','"+ Addressetxt.Text + "')";
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

        private void ClientDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientId.Text = ClientDGV.SelectedRows[0].Cells[0].Value.ToString();
            Nametxt.Text = ClientDGV.SelectedRows[0].Cells[0].Value.ToString();
            LastNametxt.Text = ClientDGV.SelectedRows[0].Cells[0].Value.ToString();
            Mobiletxt.Text = ClientDGV.SelectedRows[0].Cells[0].Value.ToString();
            NIVno.Text = ClientDGV.SelectedRows[0].Cells[0].Value.ToString();
            Modeletxt.Text = ClientDGV.SelectedRows[0].Cells[0].Value.ToString();
            Addressetxt.Text = ClientDGV.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClientId.Text = "";
            Nametxt.Text = "";
            LastNametxt.Text = "";
            Mobiletxt.Text = "";
            NIVno.Text = "";
            Modeletxt.Text = "";
            Addressetxt.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from ClientTbl where ClientId ='" + ClientId.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            populate();
            MessageBox.Show("Client deleted successully!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Paiment paiment = new Paiment();
            paiment.Show();
        }
    }
}
