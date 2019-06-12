using System;

namespace Belfer
{
    public static class AdminSQL
    {
        public static string SelectSsLCipher() => "SHOW STATUS LIKE 'Ssl_cipher';";
        public static string SelectServerTime() => "SELECT Now();";
        public static string LogIn() => "INSERT INTO event (Login, ComputerIP, Status, AppType, AppVer) VALUES(@Nick, @IP, @LoginStatus, @AppType, @AppVer);";
        public static string LogOut() => "UPDATE event SET TimeOut=Now() WHERE ID=@IdRecord;";
        public static string ChangePassword() => "UPDATE user SET Password=NewPwd WHERE Login=Nick;";
    }
    public static class OpcjeSQL
    {
        public static string SelectDBVersion() => "SELECT Value FROM opcje WHERE Name='DBVersion';";
        public static string SelectMinPasswordLength() => "SELECT Value FROM opcje WHERE Name='MinPasswordLength';";
        public static string SelectStartDateOfSemester2(string IdSchool, DateTime CurrDate)
        {
            return "Select Value FROM opcje WHERE Name='Semester2StartDate' AND Type='G' AND IdSchool='" + IdSchool + "' AND '" + CurrDate.ToShortDateString() + "' Between StartDate AND EndDate;";
        }
        public static string SelectApplicationURL() => "SELECT Value FROM opcje WHERE Name='AppURL';";

        public static string SelectMaxPasswordLength() => "SELECT Value FROM opcje WHERE Name='MaxPasswordLength';";
    }

}
