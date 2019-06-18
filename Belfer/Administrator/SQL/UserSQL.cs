namespace Belfer.Administrator.SQL
{
    public static class UserSQL
    {
        public static string SelectSysUser()
        {
            return "SELECT USER();";
        }
        public static string SelectUsers()
        {
            return "SELECT u.Login, u.Nazwisko, u.Imie, u.Sex, u.Faximile, u.email, u.Password, u.Role, u.Status FROM `user` u WHERE u.Role>0;";
        }
        public static string SelectAllUsers()
        {
            return "SELECT u.Login, u.Nazwisko, u.Imie, u.Sex, u.Faximile, u.email, u.Password, u.Role, u.Status, u.Owner, u.User, u.ComputerIP, u.Version FROM `user` u;";
        }
        public static string SelectSomeUsers(string SchoolID)
        {
            return "SELECT u.Login, u.Nazwisko, u.Imie, u.Sex, u.Faximile, u.email, u.Password, u.Role, u.Status, u.Owner, u.User, u.ComputerIP, u.Version FROM `user` u WHERE u.Role>0 AND u.Login NOT IN (SELECT sn.Nauczyciel FROM szkola_nauczyciel sn WHERE sn.IdSzkola ='" + SchoolID + "');";
        }
        public static string InsertUser()
        {
            return "INSERT INTO user (Login,Nazwisko,Imie,Email,Password,Role,Status,Sex,Owner,User,ComputerIP) VALUES (@Login,@LastName,@FirstName,@Email,@Password,@Role,@Status,@Sex,@Owner,@User,@IP);";
        }

        public static string UpdateUser()
        {
            return "UPDATE user SET Nazwisko=@Nazwisko,Imie=@Imie,Email=@Email,Role=@Rola,Status=@Status,Sex=@Sex,User=@User,ComputerIP=@IP WHERE Login=@Login;";
        }
        public static string DeleteUser() => "DELETE FROM user WHERE Login=@Login;";
        public static string CountUser(string Login) => "SELECT COUNT(Login) FROM user WHERE Login='" + Login + "';";
        public static string LogIn() => "INSERT INTO event (Login, ComputerIP, Status, AppType, AppVer) VALUES(@Nick, @IP, @LoginStatus, @AppType, @AppVer);";
        public static string LogOut() => "UPDATE event SET TimeOut=Now() WHERE ID=@IdRecord;";
        public static string ChangePassword() => "UPDATE user SET Password=@NewPwd,User=@UserName,ComputerIP=@HostIP WHERE Login=@Nick;";

    }
}
