using System;
using System.Drawing;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Autofac;
using System.Data;
using Belfer.Administrator.Model;
using DataBaseService;
using Belfer.DataBaseContext;
using Enigma;
using Belfer.Helpers;

namespace Belfer
{
    public delegate void NewRecord(long RecordID);
    public delegate void ConnectionStatus(ConnectionState cs);
    public enum YesNo { Nie, Tak }
    public enum PageNumberLocation { Header = 0, Footer = 1 }
    public enum AnalysisOption { ByNumber, ByPercent, ByBoth }
    public enum PrivilegeAspect { Dodatkowy, Główny }
    public enum ConnectionState { Niedostępne, Dostępne }


    public static class AppVars
    {
        public static Icon AppIcon => Properties.Resources.Belfer_48;
        public static Version AppVersion { get; }
        public static string AppURL { get; }
        public static string DbVersion { get; }
        public static int MinPwdLength { get; }
        public static int MaxPwdLength { get; }
        static AppVars()
        {
            AppVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            AppURL = OptionLoader.GetApplicationURL();
            DbVersion = OptionLoader.GetDbVersion();
            MinPwdLength = OptionLoader.GetMinPasswordLength();
            MaxPwdLength = OptionLoader.GetMaxPasswordLength();
        }

    }
    public static class AppSession
    {
        static IConnectionParameters connParams;
        //public static event ConnectionStatus ConnectionStateChanged;

        static System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

        public static DateTime CurrentDateAndTime { get { return StartTime.Add(stopWatch.Elapsed); } }

        public static DateTime StartTime { get; set; }
        public static IContainer TypeContainer { get; set; }
        public static string HostIP { get; set; }
        public static string HostName { get; set; }
        public static IEnumerable<AppUser> Users { get; set; }
        public static IEnumerable<School> Schools { get; set; }
        public static List<UserSettings> UserSettings { get; set; }
        public static bool IsDirty { get; set; } = false;
        public static string SslCipher => OptionLoader.GetSslCipher();
        public static string ServerInfo => GetServerInfo();
        public static ConnectionState ConnStatus => TestConnection();


        static AppSession()
        {
            stopWatch.Start();
            SetConnectParams();
            InitializeContainer();
            //ServerInfo = GetServerInfo();
            //SslCipher = OptionLoader.GetSslCipher();
        }

        private static string GetServerInfo()
        {
            using (var scope = TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                var info = dbs.ServerInfo();
                return $"{info.ServerName} ver. {info.ServerVersion}";
            }
        }
        public static void InitializeContainer()
        {
            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<MySqlContext>().As<IDataBaseService>().WithParameter(new TypedParameter(typeof(IConnectionParameters), connParams));
                //builder.Register<IDataBaseService>(c => new MySqlContext(connParams, (s, e) => ConnectionStateChanged?.Invoke(e.CurrentState)));
                TypeContainer = builder.Build();
            }
            catch (Exception)
            {
                throw;
            }

        }
        static ConnectionState TestConnection()
        {
            try
            {

                using (var scope = TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    if (dbs.TestConnection()) return ConnectionState.Dostępne;
                }
                return ConnectionState.Niedostępne;
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return false;
                throw;
            }
        }
        public static bool SetConnectParams()
        {
            try
            {
                connParams = new ConnectionParams();
                connParams.ServerAddress = CryptoHelper.Decrypt(Properties.Settings.Default.ServerIP);
                connParams.ServerPort = Properties.Settings.Default.ServerPort;
                connParams.DBName = CryptoHelper.Decrypt(Properties.Settings.Default.DBName);
                connParams.UserName = CryptoHelper.Decrypt(Properties.Settings.Default.SysUser);
                connParams.Password = CryptoHelper.Decrypt(Properties.Settings.Default.SysPassword);
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
    }
    public static class UserSession
    {
        public static long ID { get; set; }
        public static DateTime StartTime { get; set; }
        public static AppUser User { get; set; }

        public static void Reset()
        {
            ID = 0;
            StartTime = default(DateTime);
            User = null;
        }
    }

    public class School
    {
        public int ID { get; set; }
        public Type SchoolType { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Nip { get; set; }
        public string StreetName { get; set; }
        public string PlaceNo { get; set; }
        public City Location { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public Signature Creator { get; set; }

        public override string ToString()
        {
            return Alias;
        }
        public string Address
        {
            get
            {
                var Address = string.Concat(Location.Name, ", ul. ", StreetName).TrimStart(", ".ToCharArray()).TrimEnd(", ul. ".ToCharArray());
                Address += string.Concat(" ", PlaceNo).TrimEnd(" ".ToCharArray());
                Address += string.Concat(", ", Location.PostalCode).TrimEnd(", ".ToCharArray());
                Address += string.Concat(" ", Location.PostOffice).TrimEnd(" ".ToCharArray());

                return Address;
            }
        }


        public class Type
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public override string ToString() => Name;
        }
    }
    public class UserSettings
    {
        [JsonProperty(Required = Required.Always)]
        public string User { get; set; }
        [JsonProperty(Required = Required.Always)]
        public AppUser.UserSettings Settings { get; set; } = new AppUser.UserSettings();
    }

    public class Signature
    {
        public string Owner { get; set; }
        public string User { get; set; }
        public string IP { get; set; }
        public DateTime Version { get; set; }

        string Modifier
        {
            get
            {
                var owner = AppSession.Users.Where(x => x.Login == Owner.ToLower()).FirstOrDefault();
                var user = AppSession.Users.Where(x => x.Login == User.ToLower()).FirstOrDefault();
                return string.Concat(user != null ? user.Name : "", " (Wł. ", owner != null ? owner.Name : "", ")");
            }
        }
        public override string ToString() => Modifier;
    }

    /// <summary>
    /// Przechowuje parametry komórki tabeli
    /// </summary>
    public class TableCell
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public int Size { get; set; }
    }
    public class TableCellWithAlignment : TableCell
    {
        public StringAlignment Alignment { get; set; }
    }

}
