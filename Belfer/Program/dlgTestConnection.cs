using Enigma;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Belfer
{
    public partial class dlgTestConnection : Form
    {
        public event ConnectionStatus ConnectionStateChanged;
        public dlgTestConnection()
        {
            InitializeComponent();
            lblConnectionStatus.Text = default;
            GetConnectionParams();
            
        }

        private void GetConnectionParams()
        {
            txtServer.Text = Properties.Settings.Default.ServerIP.ToString();
            txtPortNumber.Text = Properties.Settings.Default.ServerPort.ToString();
            txtDatabase.Text = CryptoHelper.Decrypt(Properties.Settings.Default.DBName);
            CmdTest_Click(this, new EventArgs());
        }

        private void CmdOK_Click(object sender, EventArgs e) => Close();

        private void CmdTest_Click(object sender, EventArgs e)
        {
            var status = AppSession.ConnStatus;
           
            if (status == ConnectionState.Dostępne)
            {
                txtServer.Text = AppSession.ServerInfo;
                var ssl = AppSession.SslCipher;
                txtSsl.Text = ssl.Length == 0 ? "Bez szyfrowania" : ssl;
                lblConnectionStatus.ForeColor = Color.Green;
                lblConnectionStatus.Text = status.ToString();
            }
            else
            {
                txtServer.Text = Properties.Settings.Default.ServerIP.ToString();
                lblConnectionStatus.ForeColor = Color.Red;
                lblConnectionStatus.Text = status.ToString();
            }
            ConnectionStateChanged?.Invoke(status);
        }
    }
}
