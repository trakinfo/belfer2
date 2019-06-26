using System;
using System.Windows.Forms;
using Belfer.Ustawienia;
using Belfer.DataBaseContext;
using System.IO;

namespace Belfer
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //InitializeContainer();
            if (VerifyConnection())
            {
                Application.ApplicationExit += Application_ApplicationExit;
                Application.Run(new MainForm());
            }
            else
            {
                Application.Exit();
            }
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            try
            {
                if (AppSession.IsDirty) Authentication.SaveSettings(AppSession.UserSettings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK);
            }
        }

        private static bool VerifyConnection()
        {
            try
            {
                if (AppSession.ConnStatus == ConnectionState.Dostępne)
                {
                    if (Authentication.VerifyDBversion(AppVars.DbVersion))
                    {
                        SetAppSession();
                        return true;
                    }
                }
                if (LoadConnectParams())
                {
                    AppSession.SetConnectParams();
                    AppSession.InitializeContainer();
                    return VerifyConnection();
                    //if (VerifyConnection()) return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK);
            }
            return false;
        }

        private static void SetAppSession()
        {
            AppSession.StartTime = OptionLoader.GetServerDateTime();
            AppSession.HostIP = Network.HostIPv4();
            AppSession.HostName = Network.HostName();
            AppSession.Users = Authentication.GetUsers().Result;
            AppSession.Schools = Authentication.GetSchools(SchoolSQL.SelectSchool()).Result;
            AppSession.UserSettings = Authentication.GetUserSettings();
        }
        static bool IsDirty;
        static bool LoadConnectParams()
        {
            try
            {
                var ConfigFile = Path.Combine(Application.LocalUserAppDataPath, "Belfer.json");
                if (!IsDirty && File.Exists(ConfigFile))
                {
                    IsDirty = true;
                    var ECP = JSonHelper.ReadConfigFile(ConfigFile);
                        SaveConnectParams(ECP);
                        return true;
                }
                var dlg = new dlgConnectParams();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    SaveConnectParams(dlg.ConnectParams);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }



        static void SaveConnectParams(ConnectionParams EncryptedConnectParams)
        {
            Properties.Settings.Default.ServerIP = EncryptedConnectParams.ServerAddress;
            Properties.Settings.Default.ServerPort = EncryptedConnectParams.ServerPort;
            Properties.Settings.Default.DBName = EncryptedConnectParams.DBName;
            Properties.Settings.Default.SysUser = EncryptedConnectParams.UserName;
            Properties.Settings.Default.SysPassword = EncryptedConnectParams.Password;
            Properties.Settings.Default.Charset = EncryptedConnectParams.CharSet;
            Properties.Settings.Default.KeepAlive = EncryptedConnectParams.KeepAlive;
            Properties.Settings.Default.SSL = EncryptedConnectParams.SSLMode;

            Properties.Settings.Default.Save();
        }
    }
}
