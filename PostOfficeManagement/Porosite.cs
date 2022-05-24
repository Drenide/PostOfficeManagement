using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data.SqlClient;
using PostOfficeManagement.BLL;
using PorositeBO = PostOfficeManagement.BO.Porosite;
using DGVPrinterHelper;

namespace PostOfficeManagement
{
    public partial class Porosite : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NL0J09G;Initial Catalog=PostOfficeManagement;Persist Security Info=True;User ID=post;Password=123;");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adpt;
        ReceiverBLL receiverBLL;
        SenderBLL senderBLL;
        public Porosite()
        {
            receiverBLL = new ReceiverBLL();
            senderBLL = new SenderBLL();
            InitializeComponent();
            ShikoDatat();
            //ShikoData();
        }
        public void ShikoDatat()
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from Receiver", con);
            dt = new DataTable();
            adpt.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
        }
        public void ShikoData()
        {
            bunifuCustomDataGrid1.DataSource = receiverBLL.GetAll().Tables[0];

        }
        private void Porosite_Load(object sender, EventArgs e)
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
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void txtReadyToPickup_Click(object sender, EventArgs e)
        {
            string constring = "Data Source=DESKTOP-NL0J09G;Initial Catalog=PostOfficeManagement;Persist Security Info=True;User ID=post;Password=123;";
            string Query = "update Receiver set Status='" + this.cmdStatusi.Text + "' where Id_Receiver='" + this.txtIdStatusi.Text + "'   ;";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in bunifuCustomDataGrid1.SelectedRows)
            //{
            //    int rowIndex = (int)row.Cells[0].Value;
            //    bunifuCustomDataGrid1.Rows.RemoveAt(row.Index);
            //    receiverBLL.Delete(rowIndex);
            //}
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Client Report";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Gjirafa50";
            printer.FooterSpacing = 1;
            printer.PrintDataGridView(bunifuCustomDataGrid1);
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in bunifuCustomDataGrid1.SelectedRows)
            {
                int rowIndex = (int)row.Cells[0].Value;
                bunifuCustomDataGrid1.Rows.RemoveAt(row.Index);
                receiverBLL.Delete(rowIndex);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKerko_TextChanged(object sender, EventArgs e)
        {
            Data(txtKerko.Text);
        }
        public void Data(string search)
        {
            con.Open();
            string query = "select * from Receiver where Id_Receiver like '%" + search + "%'";
            adpt = new SqlDataAdapter(query, con);
            dt = new DataTable();
            adpt.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
        }
    }
}
