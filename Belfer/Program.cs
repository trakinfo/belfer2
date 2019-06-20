using System;
using System.Windows.Forms;
using Belfer.Ustawienia;
using Belfer.DataBaseContext;

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
                //if (AppSession.Conn.State == System.Data.ConnectionState.Open) AppSession.Conn.Close();
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
                var cs = new ConnectionAssistant();
                if (cs.TryConnect())
                {
                    if (Authentication.VerifyDBversion(AppVars.DbVersion))
                    {
                        SetAppSession();
                        return true;
                    }
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
            AppSession.ConnStatus = ConnectionState.Dostępne;
            AppSession.StartTime = OptionLoader.GetServerDateTime();
            AppSession.HostIP = Network.HostIPv4();
            AppSession.HostName = Network.HostName();
            AppSession.Users = Authentication.GetUsers().Result;
            AppSession.Schools = Authentication.GetSchools(SchoolSQL.SelectSchool()).Result;
            AppSession.UserSettings = Authentication.GetUserSettings();
        }

    }
}
