using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace PostOfficeManagement
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            //this.Hide();
            //Ballina b = new Ballina();
            //b.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            this.Hide();
            Porosite p = new Porosite();
            p.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button3.Height;
            SidePanel.Top = button3.Top;
            this.Hide();
            RegjistrimiPorosise rp = new RegjistrimiPorosise();
            rp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Jeni i sigurt se deshironi te largoheni?", "Dalja nga programi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Jeni i sigurt se deshironi te largoheni nga Menu dhe te ktheheni te pjesa e Login?", "Dalja nga programi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                this.Hide();
                Login ss = new Login();
                ss.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.instagram.com/");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.linkedin.com/");
        }
    }
}
