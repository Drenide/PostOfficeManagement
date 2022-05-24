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
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using PostOfficeManagement.BLL;
using RegjistrimiBO = PostOfficeManagement.BO.RegjistrimiAutomjetit;
using PostOfficeManagement.DAL;
using PostOfficeManagement.BO;

namespace PostOfficeManagement
{
    public partial class RegjistrimiAutomjetit : Form
    {
        RegjistrimiAutomjetitBLL _RegjistrimiAutomjetitBLL;
        public RegjistrimiAutomjetit()
        {

            _RegjistrimiAutomjetitBLL = new RegjistrimiAutomjetitBLL();
            InitializeComponent();
            ShikoData();
        }
        SqlDataAdapter sda;
        //SqlCommandBuilder scb;
        DataTable dt;
        public void ShikoData()
        {
            bunifuCustomDataGrid1.DataSource = _RegjistrimiAutomjetitBLL.GetAll().Tables[0];
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
            AdminForm Af = new AdminForm();
            Af.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RegjistrimiBO RegVehicle = new RegjistrimiBO();
            RegVehicle.Prodhuesi = txtProdhuesi.Text;
            RegVehicle.Modeli = txtModeli.Text;
            RegVehicle.Viti_Prodhimit = DateTime.Parse(txVitiProdhimit.Text);
            RegVehicle.Motorri = int.Parse(txtMotorri.Text);
            RegVehicle.Pesha = int.Parse(txtPesha.Text);
            RegVehicle.LlojiKarburantit = cmdFuel.Text;
            RegVehicle.PeshaMaksimale = int.Parse(txtPeshamaksimale.Text);

            bool isSaved = _RegjistrimiAutomjetitBLL.Add(RegVehicle);
            ShikoData();
            MessageBox.Show("Automjeti eshte regjistruar me sukses!");
        }


        private void btnFshij_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in bunifuCustomDataGrid1.SelectedRows)
            {
                int rowIndex = (int)row.Cells[0].Value;
                bunifuCustomDataGrid1.Rows.RemoveAt(row.Index);
                _RegjistrimiAutomjetitBLL.Delete(rowIndex);
            }
        }
        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(DataGridViewRow row in bunifuCustomDataGrid1.SelectedRows)
            {
                txtProdhuesi.Text = row.Cells[1].Value.ToString();
                txtModeli.Text = row.Cells[2].Value.ToString();
                txVitiProdhimit.Text = row.Cells[3].Value.ToString();
                txtMotorri.Text = row.Cells[4].Value.ToString();
                txtPesha.Text = row.Cells[5].Value.ToString();
                cmdFuel.Text = row.Cells[6].Value.ToString();
                txtPeshamaksimale.Text = row.Cells[7].Value.ToString();
            }

        }

        private void btnEditoA_Click(object sender, EventArgs e)
        {

            

            string constring = "Data Source=DESKTOP-NL0J09G;Initial Catalog=PostOfficeManagement;Persist Security Info=True;User ID=post;Password=123;";
            string Query = "update RegjistrimiAutomjetit set Prodhuesi='" +this.txtProdhuesi.Text + "',Modeli='" + this.txtModeli.Text + "',Viti_Prodhimit='" + this.txVitiProdhimit.Text + "',Motorri='" + this.txtMotorri.Text + "',Pesha='" + this.txtPesha.Text + "',LlojiKarburantit='" + this.cmdFuel.Text + "',PeshaMaksimale='" + this.txtPeshamaksimale.Text + "' where Id_Automjeti='" + this.txtIdAutomjeti.Text + "'   ;";
            SqlConnection sqlcon = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand(Query, sqlcon);
            SqlDataReader reader;
            //scb = new SqlCommandBuilder(sda);
            //sda.Update(dt);
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
        private void bunifuCustomDataGrid1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void Shiko_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NL0J09G;Initial Catalog=PostOfficeManagement;Persist Security Info=True;User ID=post;Password=123;");
            //SqlCommand cmd = new SqlCommand("Select Id_Automjeti,Prodhuesi,Modeli,Viti_Prodhimit,Motorri,Pesha,LlojiKarburantit,PeshaMaksimale from RegjistrimiKlientit", con);
            //sda = new SqlDataAdapter("Select Id_Automjeti,Prodhuesi,Modeli,Viti_Prodhimit,Motorri,Pesha,LlojiKarburantit,PeshaMaksimale FROM RegjistrimiKlientit", con);
            sda = new SqlDataAdapter("Select * from RegjistrimiAutomjetit", con);
            dt = new DataTable();
            sda.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-NL0J09G;Initial Catalog=PostOfficeManagement;Persist Security Info=True;User ID=post;Password=123;");
            ////SqlCommand cmd = new SqlCommand("Select Id_Automjeti,Prodhuesi,Modeli,Viti_Prodhimit,Motorri,Pesha,LlojiKarburantit,PeshaMaksimale from RegjistrimiKlientit", con);
            ////sda = new SqlDataAdapter("Select Id_Automjeti,Prodhuesi,Modeli,Viti_Prodhimit,Motorri,Pesha,LlojiKarburantit,PeshaMaksimale FROM RegjistrimiKlientit", con);
            //sda = new SqlDataAdapter("Select * from RegjistrimiAutomjetit", con);
            //dt = new DataTable();
            //sda.Fill(dt);
            //bunifuCustomDataGrid1.DataSource = dt;
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

        private void RegjistrimiAutomjetit_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

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
