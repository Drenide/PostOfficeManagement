using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using PostOfficeManagement.BLL;
using PostOfficeManagement.BO;

namespace PostOfficeManagement
{
    public partial class AdminLogin : Form
    {
        private UserBLL UserBLL;
        public AdminLogin()
        {
            UserBLL = new UserBLL();
            InitializeComponent();
           
        }

        private void txtPassEnter(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(@"Password"))
            {
                txtPassword.Text = "";
            }
        }

        private void txtPassLeave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(@""))
            {
                txtPassword.Text = "Password";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login ss = new Login();
            ss.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Users users = new Users
            {
                Name = txtName.Text,
                Password = txtPassword.Text
            };
            UserBLL.GetUsers(users);
            if (users.Role_Id == 2)
            {
                DialogResult dr = MessageBox.Show("Ky user eshte i perdoruesit.Deshironi qe te kyqeni?", "Login", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    MessageBox.Show("Ju keni hyre me sukses!");
                    this.Hide();
                    Menu s = new Menu();
                    s.Show();
                }
            }
            else if (users.Role_Id == 1)
            {
                MessageBox.Show("Ju keni hyre me sukses!");
                AdminForm s = new AdminForm();
                s.Show();
            }
            else
            {
                MessageBox.Show("Ky user nuk ekziston.Ju lutem,kontrolloni perseri!");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Jeni i sigurt se deshironi te largoheni?", "Dalja nga programi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtNameEnter(object sender, EventArgs e)
        {
            if (txtName.Text.Equals(@"Admin"))
            {
                txtName.Text = "";
            }
        }

        private void txtNameLeave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(@""))
            {
                txtPassword.Text = "Admin";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                    break;
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("sq");
                    break;


            }
            this.Controls.Clear();
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.instagram.com/");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.linkedin.com/");
        }
    }
}
