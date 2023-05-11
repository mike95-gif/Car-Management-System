using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Car : Form
    {
        public Car()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CV0FGMQ\SQLEXPRESS;Initial Catalog=MultiLeseDB;Integrated Security=True");
        
        private void populate()
        {
            conn.Open();
            string querry = "select * from CarMntTbl";
            SqlDataAdapter da = new SqlDataAdapter(querry,conn);
            SqlCommandBuilder builder= new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CARDGV.DataSource= ds.Tables[0];
            conn.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm main = new MainForm();
            main.Show();
        }
       
        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (NIVno.Text == "" || ModelTxt.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string querry = "insert into CarMntTbl values('" + NIVno.Text + "', '" + ModelTxt.Text + "','" + Pricetxt.Text + "','" + StatusTxt.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(querry, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car added Successfully ");
                    conn.Close();
                }
                catch(Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Car_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if(NIVno.Text == "")
            {
                MessageBox.Show("Enter the NIV");
            }
            else
            {
                try
                {
                    conn.Open();
                    string querry = "delete from CarMntTbl where NIVno= '" + NIVno.Text + "'; ";
                    SqlCommand cmd = new SqlCommand(querry, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Deleted Succesfully");
                    conn.Close();
                    populate();
                }
                catch(Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void CARDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NIVno.Text = CARDGV.SelectedRows[0].Cells[0].Value.ToString();
            Pricetxt.Text = CARDGV.SelectedRows[0].Cells[1].Value.ToString();
            ModelTxt.Text = CARDGV.SelectedRows[0].Cells[2].Value.ToString();
            StatusTxt.SelectedItem = CARDGV.SelectedRows[3].Cells[0].Value.ToString();
        }
    }
}
