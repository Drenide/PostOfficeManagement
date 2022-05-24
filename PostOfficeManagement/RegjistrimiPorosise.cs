using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PostOfficeManagement.BLL;
using System.Diagnostics;
using ReceiverBO = PostOfficeManagement.BO.Receiver;
using SenderBO = PostOfficeManagement.BO.Sender;


namespace PostOfficeManagement
{
    public partial class RegjistrimiPorosise : Form
    {
        ReceiverBLL ReceiverBLL;
        SenderBLL SenderBLL;
        public RegjistrimiPorosise()
        {
            ReceiverBLL = new ReceiverBLL();
            SenderBLL = new SenderBLL();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Jeni i sigurt se deshironi te anuloni porosine?", "Anulimi i porosise", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                txtEmri.Text = "";
                txtAdresa.Text = "";
                txtQyteti.Text = "";
                txtNumriKontaktues.Text = "";
                txtMPeshaProduktit.Text = "";
                txtMEmri.Text = "";
                txtMAdresa.Text = "";
                txtMQyteti.Text = "";
                txtMNumriTelefonit.Text = "";
                txtMReference.Text = "";
                cmbShipmentType.Text = "";
                cmbPako.Text = "";
                cmbStatus.Text = "";
                cmbExchange.Text = "";
                txtMInstruksionet.Text = "";
            }
        }
        private void RadioButtonPo_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void RadioButtonPo_Click(object sender, EventArgs e)
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

        private void btnRegjistro_Click(object sender, EventArgs e)
        {
            ReceiverBO receiverAdd = new ReceiverBO();
            receiverAdd.Emri= txtMEmri.Text;
            receiverAdd.Adresa = txtMAdresa.Text;
            receiverAdd.Qyteti = txtMQyteti.Text;
            receiverAdd.NumriTelefonit = int.Parse(txtMNumriTelefonit.Text);
            receiverAdd.Reference = int.Parse(txtMReference.Text);
            receiverAdd.ShipmentType = cmbShipmentType.Text;
            receiverAdd.PeshaProduktit = int.Parse(txtMPeshaProduktit.Text);
            receiverAdd.Hapja = cmbPako.Text;
            receiverAdd.Exchange = cmbExchange.Text;
            receiverAdd.Status = cmbStatus.Text = "Waiting";
            receiverAdd.PershkrimiProduktit = txtMInstruksionet.Text;

            SenderBO senderAdd = new SenderBO();
            senderAdd.Emri = txtEmri.Text;
            senderAdd.Adresa = txtAdresa.Text;
            senderAdd.Qyteti = txtQyteti.Text;
            senderAdd.NumriKontaktues = int.Parse(txtNumriKontaktues.Text);

            bool isSaved = ReceiverBLL.Add(receiverAdd);
            bool isSavedd = SenderBLL.Add(senderAdd);
            MessageBox.Show("Porosia eshte regjistruar me sukses!");
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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
