using System.Collections.Generic;
using Newtonsoft.Json;
using System.Drawing;
using Autofac;
using DataBaseService;
using Belfer.Administrator.SQL;

namespace Belfer.Administrator.Model
{
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

        public int UpdatePassword()
        {
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return dbs.UpdateRecordAsync(UserSQL.ChangePassword(), CreateUpdateParams()).Result;
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
}
