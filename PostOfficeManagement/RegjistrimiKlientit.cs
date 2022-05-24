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
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
using PostOfficeManagement.BLL;
using RegjistrimiBO = PostOfficeManagement.BO.RegjistrimiKlientit;

namespace PostOfficeManagement
{
    public partial class RegjistrimiKlientit : Form
    {
        RegjistrimiKlientitBLL RegjistrimiKlientitBLL;
        public RegjistrimiKlientit()
        {
            
            RegjistrimiKlientitBLL = new RegjistrimiKlientitBLL();
            InitializeComponent();
            ShikoData();
        }
        public void ShikoData()
        {
            bunifuCustomDataGrid1.DataSource = RegjistrimiKlientitBLL.GetAll().Tables[0];
        }
        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm af = new AdminForm();
            af.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void btnFshijKlientin_Click(object sender, EventArgs e)
        {

        }

        private void btnEditoK_Click(object sender, EventArgs e)
        {
            
        }
        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void btnRegjistroC_Click(object sender, EventArgs e)
        {
            RegjistrimiBO regjistro = new RegjistrimiBO();
            regjistro.Name = txName.Text;
            regjistro.Password = TxPassword.Text;
            regjistro.Emri = txEmri.Text;
            regjistro.Mbiemri = txMbiemri.Text;
            regjistro.Telefon = int.Parse(txTelefon.Text);
            regjistro.Adresa = txAddress.Text;
            regjistro.Qyteti = txQyteti.Text;
            regjistro.FacebookLink = txFBLINK.Text;
            regjistro.Role_Id = int.Parse(txRoleid.Text);

            bool isSaved = RegjistrimiKlientitBLL.Add(regjistro);
            ShikoData();
            MessageBox.Show("Klienti eshte regjistruar me sukses!");
        }

        private void btnFshijC_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in bunifuCustomDataGrid1.SelectedRows)
            {
                int rowIndex = (int)row.Cells[0].Value;
                bunifuCustomDataGrid1.Rows.RemoveAt(row.Index);
                RegjistrimiKlientitBLL.Delete(rowIndex);
            }
        }

        private void btnEditoC_Click(object sender, EventArgs e)
        {
            string constring = "Data Source=DESKTOP-NL0J09G;Initial Catalog=PostOfficeManagement;Persist Security Info=True;User ID=post;Password=123;";
            string Query = "update RegjistrimiKlientit set Name='" + this.txName.Text + "',Password='" + this.TxPassword.Text + "',Emri='" + this.txEmri.Text + "',Mbiemri='" + this.txMbiemri.Text + "',Telefon='" + this.txTelefon.Text + "',Adresa='" + this.txAddress.Text + "',Qyteti='" + this.txQyteti.Text + "',FacebookLink='" + this.txFBLINK.Text + "',Role_Id='" + this.txRoleid.Text + "' where Id_Klienti='" + this.txIdKlienti.Text + "'   ;";
            SqlConnection sqlcon = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand(Query, sqlcon);
            SqlDataReader reader;
            try
            {
                sqlcon.Open();
                reader = cmd.ExecuteReader();
                MessageBox.Show("Updated");
                while (reader.Read())
                {

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm Af = new AdminForm();
            Af.Show();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Jeni i sigurt se deshironi te largoheni?", "Dalja nga programi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void bunifuCustomDataGrid1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in bunifuCustomDataGrid1.SelectedRows)
            {
                txName.Text = row.Cells[1].Value.ToString();
                TxPassword.Text = row.Cells[2].Value.ToString();
                txEmri.Text = row.Cells[3].Value.ToString();
                txMbiemri.Text = row.Cells[4].Value.ToString();
                txTelefon.Text = row.Cells[5].Value.ToString();
                txAddress.Text = row.Cells[6].Value.ToString();
                txQyteti.Text = row.Cells[7].Value.ToString();
                txFBLINK.Text = row.Cells[8].Value.ToString();
                txRoleid.Text = row.Cells[9].Value.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.instagram.com/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.linkedin.com/");
        }
    }
}
