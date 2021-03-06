using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using PostOfficeManagement.BO;
using PostOfficeManagement.BLL;



namespace PostOfficeManagement
{
    public partial class Login : Form
    {
        private KlientiBLL _KlientiBLL;


        public Login()
        {
            _KlientiBLL = new KlientiBLL();
            InitializeComponent();
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Jeni i sigurt se deshironi te largoheni?", "Dalja nga programi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            Klienti klienti = new Klienti
            {
                Name = txtUsername.Text,
                Password = txtPassword.Text
            };
            _KlientiBLL.MerreKlientin(klienti);
            if(klienti.Role_Id == 1)
            {
                MessageBox.Show("Ky username eshte i ndaluar!Ju lutem,shkruani Userin tuaj!");
            }
            else if(klienti.Role_Id == 2)
            {
                MessageBox.Show("Ju keni hyre me sukses!");
                this.Hide();
                Menu s = new Menu();
                s.Show();
            }
            else
            {
                MessageBox.Show("Ky user nuk ekziston.Ju lutem,kontrolloni perseri!");
            }
        }

        private void TextUserEnter(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals(@"Username"))
            {
                txtUsername.Text = "";
            }
        }

        private void TextUserLeave(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals(@""))
            {
                txtUsername.Text = "Username";
            }
        }

        private void txtUserEnter(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(@"Password"))
            {
                txtPassword.Text = "";
            }
        }

        private void txtUserLeave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(@""))
            {
                txtPassword.Text = "Password";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            AdminLogin Ad = new AdminLogin();
            Ad.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
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

        private void label2_Click(object sender, EventArgs e)
        {

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
