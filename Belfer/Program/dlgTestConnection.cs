using Autofac;
using DataBaseService;
using Enigma;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belfer
{
    public partial class dlgTestConnection : Form
    {
        public dlgTestConnection()
        {
            InitializeComponent();
            GetConnectionParams();
            GetConnectionStatus();
        }

        private void GetConnectionStatus()
        {
            switch (AppSession.ConnStatus)
            {
                case ConnectionState.Dostępne:

                case ConnectionState.Niedostępne:

                default:
                    break;
            }
            
        }

        private void GetConnectionParams()
        {
            txtServer.Text = CryptoHelper.Decrypt(Properties.Settings.Default.ServerIP);
            txtPortNumber.Text = Properties.Settings.Default.ServerPort.ToString();
            txtDatabase.Text = CryptoHelper.Decrypt(Properties.Settings.Default.DBName);
            txtSsl.Text = AppSession.SslCipher;
            txtServerVersion.Text = AppSession.ServerInfo;
            //using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            //{
            //    var dbs = scope.Resolve<IDataBaseService>();
                
            //}
        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
