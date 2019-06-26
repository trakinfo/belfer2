using System;

namespace Belfer.Helpers.SQL
{
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
