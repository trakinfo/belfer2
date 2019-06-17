using Autofac;
using DataBaseService;
using Enigma;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows.Forms;

namespace Belfer.DataBaseContext
{
    public class ConnectionAssistant
    {
        bool IsDirty;
        IConnectionParameters connParams;
        public static ConnectionStatus ConnectionStateChanged;

        public ConnectionAssistant()
        {
            LoadConnectParams();
        }
        void InitializeContainer()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<MySqlContext>().As<IDataBaseService>().WithParameter(new TypedParameter(typeof(IConnectionParameters), connParams));
            builder.Register<IDataBaseService>(c => new MySqlContext(connParams, (s, e) => ConnectionStateChanged?.Invoke(e.CurrentState)));
            AppSession.TypeContainer = builder.Build();
        }
        private bool TestConnection()
        {
            try
            {
                InitializeContainer();
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    if (dbs.TestConnection()) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool TryConnect()
        {
            try
            {
                if (TestConnection())
                {
                    return true;
                }
                else
                {
                    if (SetConnectParams())
                    {
                        LoadConnectParams();
                        if (TryConnect()) return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool SetConnectParams()
        {
            try
            {
                var ConfigFile = Path.Combine(Application.LocalUserAppDataPath, "Belfer.json");
                if (!IsDirty && File.Exists(ConfigFile))
                {
                    IsDirty = true;
                    JObject ECP = JSonHelper.ReadConfigFile(ConfigFile);
                    if (JSonHelper.ValidateParams(ECP, typeof(ConnectionParams)))
                    {
                        SaveConnectParams(ECP);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Plik configuracyjny jest niezgodny z wymaganym schematem!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                var dlg = new dlgConnectParams();
                if (dlg.ShowDialog() == DialogResult.OK) return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool LoadConnectParams()
        {
            try
            {
                connParams = new ConnectionParams();
                connParams.ServerAddress = CryptoHelper.Decrypt(Properties.Settings.Default.ServerIP);
                //uint portNr = 0;
                //uint.TryParse(CryptoHelper.Decrypt(Properties.Settings.Default.ServerPort.ToString()), out portNr);
                connParams.ServerPort = Properties.Settings.Default.ServerPort;
                connParams.DBName = CryptoHelper.Decrypt(Properties.Settings.Default.DBName);
                connParams.UserName = CryptoHelper.Decrypt(Properties.Settings.Default.SysUser);
                connParams.Password = CryptoHelper.Decrypt(Properties.Settings.Default.SysPassword);
                //var sslMode = 0;
                //int.TryParse(Properties.Settings.Default.SSL, out sslMode);
                connParams.SSLMode = Properties.Settings.Default.SSL;
                connParams.CharSet = Properties.Settings.Default.Charset;
                connParams.KeepAlive = Properties.Settings.Default.KeepAlive;
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void SaveConnectParams(JObject EncryptedConnectParams)
        {
            Properties.Settings.Default.ServerIP = (string)EncryptedConnectParams["ServerAddress"];
            Properties.Settings.Default.ServerPort = (uint)EncryptedConnectParams["ServerPort"];
            Properties.Settings.Default.DBName = (string)EncryptedConnectParams["DBName"];
            Properties.Settings.Default.SysUser = (string)EncryptedConnectParams["UserName"];
            Properties.Settings.Default.SysPassword = (string)EncryptedConnectParams["Password"];
            Properties.Settings.Default.Charset = (string)EncryptedConnectParams["CharSet"];
            Properties.Settings.Default.KeepAlive = (int)EncryptedConnectParams["KeepAlive"];
            Properties.Settings.Default.SSL = (int)EncryptedConnectParams["SSLMode"];

            Properties.Settings.Default.Save();
        }
    }
}
