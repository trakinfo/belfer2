using System;
using System.Drawing;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Autofac;
using DataBaseService;
using System.Data;

namespace Belfer
{
    public delegate void NewRecord(long RecordID);
    public enum YesNo { Nie, Tak }
    public enum PageNumberLocation { Header = 0, Footer = 1 }
    public enum AnalysisOption { ByNumber, ByPercent, ByBoth }
    public enum PrivilegeAspect { Dodatkowy, Główny }


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

        static AppSession()
        {
            stopWatch.Start();
            //SslCipher = OptionLoader.GetSslCipher();
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
    public class User
    {
        public enum UserRole : byte { Rodzic = 0, Czytelnik = 1, Nauczyciel = 2, Operator = 4, Administrator = 8 }
        public enum UserStatus : byte { Aktywny = 1, Nieaktywny = 0 }
        public enum UserSex : byte { M = 1, K = 0 }

        //public static event EventHandler RaiseUpdateUserPassword;
        //public event EventHandler RaiseUpdateUserData;

        [JsonProperty(Required = Required.AllowNull)]
        public string Login { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public string FirstName { get; set; }
        [JsonIgnore]
        public string LastName { get; set; }
        [JsonIgnore]
        public UserRole Role { get; set; }
        [JsonIgnore]
        public UserStatus Status { get; set; }
        [JsonIgnore]
        public UserSex Sex { get; set; }
        [JsonIgnore]
        public string Email { get; set; }
        [JsonIgnore]
        public Image Faximile { get; set; }
        [JsonIgnore]
        public Signature Creator { get; set; }

        public string Name { get { return string.Concat(LastName, " ", FirstName); } }

        public override string ToString() { return string.Concat(Login, " (", Name, ")"); }

        void UpdatePassword()
        {
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                dbs.UpdateRecordAsync(AdminSQL.ChangePassword(), CreateUpdateParams());
            }
        }
        IDictionary<string, object> CreateUpdateParams()
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            sqlParamWithValue.Add("@NewPwd", Password);
            sqlParamWithValue.Add("@Nick", Login);
            sqlParamWithValue.Add("@UserName", UserSession.User.Login);
            sqlParamWithValue.Add("@HostIP", AppSession.HostIP);
            return sqlParamWithValue;
        }

        public void Reset()
        {
            Login = default(string);
            Password = default(string);
            FirstName = default(string);
            LastName = default(string);
            Role = default(UserRole);
            Status = default(UserStatus);
            Sex = default(UserSex);
            Email = default(string);
            Faximile = default(System.Drawing.Image);
        }
    }
    public class AppUser : User
    {

        [JsonProperty(Required = Required.AllowNull)]
        public UserSettings Settings { get; set; }
        public IEnumerable<UserSchoolToken> SchoolTokenList { get; set; }
        public IEnumerable<Privilege> PrivilageSet { get; set; }
        public IEnumerable<Exclusion> ExclusionSet { get; set; }

        public class UserSettings
        {
            public static event EventHandler RaiseConfigChanged;

            int year = CalcHelper.StartDateOfSchoolYear().Year;
            int schoolId;
            bool landscape;
            int leftMargin = 39, topMargin = 39;
            Font textFont = new Font("Times New Roman", 9.75f), headerFont = new Font("Arial", 12, FontStyle.Bold), subheaderFont = new Font("Arial", 11.25f, FontStyle.Bold);
            float absenceLevel = 50F, avg = 1.5F;
            byte scoreCount = 0;
            float xcaliber = -3.937f, ycaliber = -7.9f;

            [JsonProperty(Required = Required.AllowNull)]
            public int SchoolID { get => schoolId; set { schoolId = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public int Year { get => year; set { year = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public bool Landscape { get => landscape; set { landscape = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public int LeftMargin { get => leftMargin; set { leftMargin = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public int TopMargin { get => topMargin; set { topMargin = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public Font TextFont { get => textFont; set { textFont = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public Font HeaderFont { get => headerFont; set { headerFont = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public Font SubHeaderFont { get => subheaderFont; set { subheaderFont = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public float AbsenceLevel { get => absenceLevel; set { absenceLevel = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public float Avg { get => avg; set { avg = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public byte ScoreCount { get => scoreCount; set { scoreCount = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public float XCaliber { get => xcaliber; set { xcaliber = value; IsDirty = true; } }
            [JsonProperty(Required = Required.AllowNull)]
            public float YCaliber { get => ycaliber; set { ycaliber = value; IsDirty = true; } }


            [JsonIgnore]
            public string SchoolYear { get => CalcHelper.SchoolYear(year); }
            [JsonIgnore]
            public bool IsDirty { get; set; } = false;

            public void ConfigChanged()
            {
                RaiseConfigChanged?.Invoke(this, new EventArgs());
            }
        }
        public class UserSchoolToken
        {
            public int SchoolID { get; set; }
            public UserRole UserRole { get; set; }
            public int UserID { get; set; }
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
