using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarMultiLease
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-CV0FGMQ\SQLEXPRESS;Initial Catalog=MultiLeseDB;Integrated Security=True");


        private void populate()
        {
            Con.Open();
            string query = " select * from  EmployeeTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder= new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Addbtn_Click(object sender, EventArgs e)
        {
            if (UserId.Text == "" || UserName.Text == "" || UserPassword.Text == "")
            {
                MessageBox.Show("Area missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into  EmployeeTbl values(" + UserId.Text + ", '" + UserName.Text + "', '" + UserPassword.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New Employee successfully added ");
                    UserId.Text = "";
                    UserName.Text = "";
                    UserPassword.Text = "";
                    Con.Close();
                    populate();
                }
                catch(Exception Myex) 
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void Employee_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(UserId.Text == "")
            {
                MessageBox.Show("Missing Information ");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from EmplUserTbl where Id = " + UserId.Text + "; ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee account Deleted succesfully");
                    Con.Close();
                    populate();
                }catch(Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UserId.Text = UserDGV.SelectedRows[0].Cells[0].Value.ToString();
            UserName.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            UserPassword.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (UserId.Text == "" || UserName.Text == "" || UserPassword.Text == "")
            {
                MessageBox.Show("Area missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update EmplUserTbl set UserName='" + UserName.Text + "', UserPassword = '" + UserPassword.Text + "' where Id=" + UserId.Text + " ;";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New Employee successfully updated");
                    UserId.Text = "";
                    UserName.Text = "";
                    UserPassword.Text = "";
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void UserId_Enter(object sender, EventArgs e)
        {
            if(UserId.Text=="Employee ID")
            {
                UserId.Text = "";

                UserId.ForeColor = Color.Black;
            }
        }

        private void UserId_Leave(object sender, EventArgs e)
        {
            if (UserId.Text == "")
            {
                UserId.Text = "Employee ID";

                UserId.ForeColor = Color.Silver;
            }
        }

        private void UserName_Enter(object sender, EventArgs e)
        {
            if (UserName.Text == "Name")
            {
                UserName.Text = "";

                UserName.ForeColor = Color.Black;
            }
        }

        private void UserName_Leave(object sender, EventArgs e)
        {
            if (UserName.Text == "")
            {
                UserName.Text = "Name";

                UserName.ForeColor = Color.Silver;
            }
        }

       

       

        private void UserPassword_Enter(object sender, EventArgs e)
        {
            if (UserPassword.Text == "Password")
            {
                UserPassword.Text = "";

                UserPassword.ForeColor = Color.Black;
            }
        }

        private void UserPassword_Leave(object sender, EventArgs e)
        {
            if (UserPassword.Text == "")
            {
                UserPassword.Text = "Password";

                UserPassword.ForeColor = Color.Silver;
            }
        }

    }
}
