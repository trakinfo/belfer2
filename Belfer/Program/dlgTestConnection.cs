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
            GetConnectionParams();
            CmdTest_Click(this, new EventArgs());
        }

        private void GetConnectionParams()
        {
            txtServer.Text = AppSession.ServerInfo;
            txtPortNumber.Text = Properties.Settings.Default.ServerPort.ToString();
            txtDatabase.Text = CryptoHelper.Decrypt(Properties.Settings.Default.DBName);
            var ssl = AppSession.SslCipher;
            txtSsl.Text = ssl.Length == 0 ? "Bez szyfrowania" : ssl;
        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CmdTest_Click(object sender, EventArgs e)
        {
            var status = AppSession.ConnStatus;
            if (status == ConnectionState.Dostępne)
            {
                lblConnectionStatus.ForeColor = Color.Green;
                lblConnectionStatus.Text = status.ToString();
            }
            else
            {
                lblConnectionStatus.ForeColor = Color.Red;
                lblConnectionStatus.Text = status.ToString();
            }
            ConnectionStateChanged?.Invoke(status);
        }
    }
}
