using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Inventory_Application
{

    public partial class frmLogin : Form
    {

        private static string user;
        public string username
        {
            get { return user; }
            set { user = value; }
        }
        public frmLogin()
        {
            InitializeComponent();

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnFunction();
        }
        private void btnFunction()
        {       
            Database databaseObj = new Database();
            using (SQLiteConnection connection = new SQLiteConnection(databaseObj.strConnection))
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                connection.Open();

                string query = "SELECT * FROM tblAccount WHERE username = @username AND password = @password";

                using (SQLiteCommand command = new SQLiteCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@username", txtUser.Text);
                    command.Parameters.AddWithValue("@password", txtPass.Text);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.Hide();
                            user = reader["fname"].ToString();
                            frmMain formMain = new frmMain();
                            formMain.Show();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username or Password! Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUser.Text = "";
                            txtPass.Text = "";
                        }
                        reader.Close();
                    }
                }

                connection.Close();



            }
            
           
         
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFunction();
            }
        }
    }
}
