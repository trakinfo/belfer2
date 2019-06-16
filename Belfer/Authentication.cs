using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Data;
using Belfer.Ustawienia;
using Enigma;
using System.Threading.Tasks;
using Autofac;
using DataBaseService;
using Belfer.Administrator.SQL;
using Belfer.Administrator.Model;

namespace Belfer
{
    public static class Authentication
    {
        private static bool VerifyUser(string UserName, string Password)
        {
            try
            {
                var User = AppSession.Users.Where(x => x.Login == UserName).Where(x => x.Status == Administrator.Model.User.UserStatus.Aktywny).FirstOrDefault();
                if (User == null) return false;

                if (AuthenticateUser(User.Password, Password))
                {
                    SetUserSession(User);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool VerifyDBversion(string version)
        {
            var msg = $"Wersja programu jest niezgodna z wersją bazy danych!\nPraca nie może być kontynuowana, aplikacja zostanie zamknięta.\nPrzy ponownym uruchomieniu program zaktualizuje się automatycznie. Jeśli automatyczna aktualizacja zawiedzie, to pobierz i zainstaluj nową wersję programu dostępną pod adresem {AppVars.AppURL}. \n\nWersja programu: {AppVars.AppVersion.ToString()}\nWersja bazy danych: {version}";
            var AppVerMatch = string.Compare(string.Concat(AppVars.AppVersion.Major.ToString(), ".", AppVars.AppVersion.Minor.ToString()), version) == 0;
            if (!AppVerMatch)
            {
                throw new Exception(msg);
            }
            return true;
        }

        internal static bool AuthenticateUser(string StoredPassword, string SuppliedPassword)
        {
            try
            {
                if (string.IsNullOrEmpty(StoredPassword) || string.IsNullOrEmpty(SuppliedPassword))
                {
                    throw new ArgumentNullException();
                }
                return HashHelper.ComparePasswords(Convert.FromBase64String(StoredPassword), SuppliedPassword);
            }
            catch (FormatException)
            {
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task<long> LogUserEnterAttempt(string userName, byte status)
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.AddRecordAsync(UserSQL.LogIn(), CreateInsertParams(userName, status));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static IDictionary<string, object> CreateInsertParams(string userName, byte status)
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            sqlParamWithValue.Add("@Nick", userName);
            sqlParamWithValue.Add("@IP", AppSession.HostIP);
            sqlParamWithValue.Add("@LoginStatus", status);
            sqlParamWithValue.Add("@AppType", "D");
            sqlParamWithValue.Add("@AppVer", AppVars.AppVersion);
            return sqlParamWithValue;
        }

        private static async Task LogUserExit(long IdEvent)
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    await dbs.UpdateRecordAsync(UserSQL.LogOut(), new Tuple<string, object>("@IdRecord", IdEvent));
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static async Task<IEnumerable<AppUser>> GetUsers()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(UserSQL.SelectUsers(), UserModel);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static AppUser UserModel(IDataReader R)
        {
            return new AppUser
            {
                Login = R["Login"].ToString(),
                FirstName = R["Imie"].ToString(),
                LastName = R["Nazwisko"].ToString(),
                Sex = (User.UserSex)Convert.ToUInt64(R["Sex"].ToString()),
                Status = (User.UserStatus)Convert.ToUInt64(R["Status"]),
                Role = (User.UserRole)Convert.ToUInt64(R["Role"]),
                //Password = R["Password"].ToString(),
                Password = System.Text.Encoding.UTF8.GetString((byte[])R["Password"]),
                Email = R["Email"].ToString(),
                Faximile = R["Faximile"] as System.Drawing.Image
            };
        }

        public static async Task<bool> Login()
        {
            try
            {
                using (var dlg = new dlgLogin())
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        if (VerifyUser(dlg.txtUserName.Text, dlg.txtPassword.Text)) return true;
                        await LogUserEnterAttempt(dlg.txtUserName.Text.Trim(), 0);
                        var msg = "Podane hasło jest nieprawidłowe, użytkownik nie istnieje lub konto jest wyłączone!";
                        MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        return false;
                    }
                }
                if (Login().Result) return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task Logout()
        {
            try
            {
                await LogUserExit(UserSession.ID);
                if (UserSession.User.Settings.IsDirty) SaveUserSettings(UserSession.User);
                UserSession.Reset();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void SetUserSession(AppUser User)
        {
            try
            {
                UserSession.ID = LogUserEnterAttempt(User.Login, 1).Result;
                UserSession.StartTime = AppSession.CurrentDateAndTime;
                UserSession.User = User;
                User.SchoolTokenList = LoadUserToken(User).Result;
                User.Settings = LoadUserSettings(User.Login);
                User.PrivilageSet = LoadUserPrivilages(User);
                User.ExclusionSet = LoadUserExclusions(User);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static IEnumerable<Exclusion> LoadUserExclusions(AppUser user)
        {
            //todo: 2019-05-01 zrobić listę wykluczeń
            return null;
        }

        private static ISet<Privilege> LoadUserPrivilages(AppUser user)
        {
            //todo: 2019-05-01 Było pusto, trzeba zrobić listę przywilejów
            return null;
        }

        public static async Task<IEnumerable<AppUser.UserSchoolToken>> LoadUserToken(AppUser User)
        {
            if (User.Role == AppUser.UserRole.Administrator)
            {
                var AdminToken = new List<AppUser.UserSchoolToken>();
                foreach (var S in AppSession.Schools)
                {
                    AdminToken.Add(new AppUser.UserSchoolToken { SchoolID = S.ID, UserRole = Administrator.Model.User.UserRole.Administrator });
                }
                return AdminToken;
            }
            return await GetUserSchoolToken(User);
        }
        private static async Task<IEnumerable<AppUser.UserSchoolToken>> GetUserSchoolToken(AppUser User)
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(SchoolSQL.SelectSchool(User.Login, AppUser.UserStatus.Aktywny), TokenModel);
                }
                //return Token;
            }
            catch (System.Data.SqlTypes.SqlNullValueException)
            {
                return new List<AppUser.UserSchoolToken>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static AppUser.UserSchoolToken TokenModel(IDataReader R)
        {
            return new AppUser.UserSchoolToken()
            {
                SchoolID = Convert.ToInt32(R["IdSzkola"]),
                UserRole = (User.UserRole)Convert.ToByte(R["Role"]),
                UserID = Convert.ToInt32(R["ID"])
            };
        }

        private static AppUser.UserSettings LoadUserSettings(string login)
        {
            try
            {
                //UserSettings US = null;
                var US = AppSession.UserSettings.Where(x => x.User == login).FirstOrDefault();
                //if (US == null) throw new NullReferenceException();
                return US.Settings;
            }
            catch (NullReferenceException)
            {
                var NewUS = new AppUser.UserSettings();
                GetWorkingParams(NewUS);
                return NewUS;
            }

            catch (Exception)
            {

                throw;
            }

        }
        public static bool GetWorkingParams(AppUser.UserSettings US)
        {
            using (var dlg = new dlgWorkingParams(US))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //US.IsDirty = true;
                    US.SchoolID = ((School)dlg.cbSzkola.SelectedItem).ID;
                    US.Year = (int)dlg.nudStartYear.Value;
                    US.ConfigChanged();
                    return true;
                }
                return false;
            }
        }
        private static void SaveUserSettings(AppUser User)
        {
            try
            {
                var US = AppSession.UserSettings.Where(x => x.User == User.Login).FirstOrDefault();
                US.Settings = User.Settings;
                AppSession.IsDirty = true;
                User.Settings.IsDirty = false;
            }
            catch (NullReferenceException)
            {
                var US = new UserSettings() { User = User.Login };
                US.Settings = User.Settings;
                AppSession.UserSettings.Add(US);
                AppSession.IsDirty = true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static List<UserSettings> GetUserSettings()
        {
            var ConfigFile = Path.Combine(Application.LocalUserAppDataPath, "User.json");
            try
            {
                string jsonUS = File.ReadAllText(ConfigFile);
                if ((string.IsNullOrEmpty(jsonUS)) || (string.IsNullOrWhiteSpace(jsonUS))) throw new ArgumentNullException();

                var US = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserSettings>>(jsonUS);
                US.ForEach(u => u.Settings.IsDirty = false);
                return US;
            }
            catch (ArgumentNullException)
            {
                return new List<UserSettings>();
            }
            catch (FileNotFoundException)
            {
                return new List<UserSettings>();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void SaveSettings(List<UserSettings> US)
        {
            try
            {
                var P = Path.Combine(Application.LocalUserAppDataPath, "User.json");
                using (StreamWriter SW = new StreamWriter(P))
                {
                    var JS = new Newtonsoft.Json.JsonSerializer();
                    JS.Formatting = Newtonsoft.Json.Formatting.Indented;
                    JS.Serialize(SW, US);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<IEnumerable<School>> GetSchools(string selectString)
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(selectString, SchoolModel);
                }
            }
            catch (System.Data.SqlTypes.SqlNullValueException)
            {
                return new List<School>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static School SchoolModel(IDataReader R)
        {
            return new School
            {
                ID = Convert.ToInt32(R["ID"]),
                Name = R["Nazwa"].ToString(),
                Alias = R["Alias"].ToString(),
                Nip = R["NIP"].ToString(),
                StreetName = R["Ulica"].ToString(),
                PlaceNo = R["Nr"].ToString(),
                Location = new City()
                {
                    ID = R["IdMiejscowosc"] == DBNull.Value ? 0 : Convert.ToInt32(R["IdMiejscowosc"]),
                    Name = R["Miejscowosc"].ToString(),
                    Code = R["Kod"].ToString(),
                    PostalCode = R["KodPocztowy"].ToString(),
                    PostOffice = R["Poczta"].ToString()
                },
                SchoolType = new School.Type
                {
                    ID = Convert.ToInt32(R["IdTypSzkoly"]),
                    Name = R["Typ"].ToString(),
                    Description = R["Opis"].ToString()
                },
                PhoneNo = R["Telefon"].ToString(),
                FaxNo = R["Fax"].ToString(),
                Email = R["Email"].ToString(),
                Creator = new Signature
                {
                    Owner = R["Owner"].ToString(),
                    User = R["User"].ToString(),
                    IP = R["ComputerIP"].ToString(),
                    Version = (DateTime)R["Version"]
                }
            };
        }

        public static void ChangePassword()
        {
            try
            {
                using (var dlg = new dlgPassword())
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        var User = (AppUser)dlg.cbUserName.SelectedItem;
                        UpdatePassword(User, dlg.txtNewPassword.Text.Trim());
                    }
                    else
                    {
                        return;
                    }
                }
                ChangePassword();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static bool ChangePassword(User UserData, bool adminMode)
        {
            try
            {
                using (var dlg = new dlgPassword(UserData, adminMode))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        UpdatePassword(UserData, dlg.txtNewPassword.Text.Trim());
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static void UpdatePassword(User usr, string pwd)
        {
            try
            {
                var pwdHash = HashHelper.CreatePassword(pwd);
                usr.Password = Convert.ToBase64String(pwdHash);
                //usr.UpdatePassword();
                MessageBox.Show("Hasło zostało zmienione!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
