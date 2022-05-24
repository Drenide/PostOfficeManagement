using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PostOfficeManagement
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }



        private void btnRegjistroPunetorin_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegjistrimiPunetorit rp = new RegjistrimiPunetorit();
            rp.Show();
        }

        private void btnRegjistroKlientin_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegjistrimiKlientit rk = new RegjistrimiKlientit();
            rk.Show();
        }

        private void btnRegjistroAutomjetin_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegjistrimiAutomjetit ra = new RegjistrimiAutomjetit();
            ra.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin al = new AdminLogin();
            al.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Jeni i sigurt se deshironi te largoheni?", "Dalja nga programi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
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
