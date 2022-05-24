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
using System.Configuration;
using System.Diagnostics;
using PostOfficeManagement.BLL;
using RegjistrimiBO = PostOfficeManagement.BO.RegjistrimiPunetorit;

namespace PostOfficeManagement
{
    public partial class RegjistrimiPunetorit : Form
    {
        RegjistrimiPunetoritBLL RegjistrimiPunetoritBLL;
        public RegjistrimiPunetorit()
        {
            
            RegjistrimiPunetoritBLL = new RegjistrimiPunetoritBLL();
            InitializeComponent();
            ShikoData();
        }
        private void ShikoData()
        {
            bunifuCustomDataGrid1.DataSource = RegjistrimiPunetoritBLL.GetAll().Tables[0];
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
            this.Hide();
            AdminForm af = new AdminForm();
            af.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RegjistrimiBO RegEmployee = new RegjistrimiBO();
            RegEmployee.Emri = txtEmri.Text;
            RegEmployee.Mbiemri = txtMbiemri.Text;
            RegEmployee.Datelindja = DateTime.Parse(txBirthday.Text);
            RegEmployee.NumriPersonal = int.Parse(txtNumriPersonal.Text);
            RegEmployee.DL = txtDL.Text;
            RegEmployee.PatentShoferi = txtPatentShoferi.Text;
            RegEmployee.KategoriaPatentes = txtKategoriaPunes.Text;
            RegEmployee.PunesuarPrej = DateTime.Parse(txPrej.Text);
            RegEmployee.DeriMe = DateTime.Parse(txDeri.Text);

            bool isSaved = RegjistrimiPunetoritBLL.Add(RegEmployee);
            ShikoData();
            MessageBox.Show("Punetori eshte regjistruar me sukses!");
        }


        private void btnFshijP_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in bunifuCustomDataGrid1.SelectedRows)
            {
                int rowIndex = (int)row.Cells[0].Value;
                bunifuCustomDataGrid1.Rows.RemoveAt(row.Index);
                RegjistrimiPunetoritBLL.Delete(rowIndex);
            }
        }

        private void btnEditoP_Click(object sender, EventArgs e)
        {
            string constring = "Data Source=DESKTOP-NL0J09G;Initial Catalog=PostOfficeManagement;Persist Security Info=True;User ID=post;Password=123;";
            string Query = "update RegjistrimiPunetorit set Emri='" + this.txtEmri.Text + "',Mbiemri='" + this.txtMbiemri.Text + "',Datelindja='" + this.txBirthday.Text + "',NumriPersonal='" + this.txtNumriPersonal.Text + "',DL='" + this.txtDL.Text + "',PatentShoferi='" + this.txtPatentShoferi.Text + "',KategoriaPatentes='" + this.txtKategoriaPunes.Text + "',PunesuarPrej='" + this.txPrej.Text + "',DeriMe='" + this.txDeri.Text + "' where Id_Punetori='" + this.txt_idpunetori.Text + "'   ;";
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

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in bunifuCustomDataGrid1.SelectedRows)
            {
                txtEmri.Text = row.Cells[1].Value.ToString();
                txtMbiemri.Text = row.Cells[2].Value.ToString();
                txBirthday.Text = row.Cells[3].Value.ToString();
                txtNumriPersonal.Text = row.Cells[4].Value.ToString();
                txtDL.Text = row.Cells[5].Value.ToString();
                txtPatentShoferi.Text = row.Cells[6].Value.ToString();
                txtKategoriaPunes.Text = row.Cells[7].Value.ToString();
                txPrej.Text = row.Cells[8].Value.ToString();
                txDeri.Text = row.Cells[9].Value.ToString();
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
