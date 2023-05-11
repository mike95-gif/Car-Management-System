using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
namespace CarMultiLease
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CV0FGMQ\SQLEXPRESS;Initial Catalog=MultiLeseDB;Integrated Security=True");
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void textBox2_Click(object sender, EventArgs e)
        {
            UserIdlogin.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            UserIdlogin.BackColor = SystemColors.Control;

        }


        private void textBox1_Click(object sender, EventArgs e)
        {
            userPasswordLogin.BackColor = Color.White;
            panel4.BackColor = Color.White;
            userPasswordLogin.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Username, Password ;
            Username = UserIdlogin.Text;
            Password = userPasswordLogin.Text;

            try
            {
                String querry = "SELECT * FROM UserLoginTbl WHERE Username = '" + UserIdlogin.Text + "' AND Password = '" + userPasswordLogin.Text + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(querry,conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if(dtable.Rows.Count > 0 )
                {
                    Username = UserIdlogin.Text;
                    Password = userPasswordLogin.Text;

                    //the page that need to be load next 

                    MainForm main=new MainForm();
                    main.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid login details","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UserIdlogin.Clear();
                    userPasswordLogin.Clear();

                    //To focus on username 
                    UserIdlogin.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            UserIdlogin.Clear();
            userPasswordLogin.Clear();

            UserIdlogin.Focus();
        }
    }
}
