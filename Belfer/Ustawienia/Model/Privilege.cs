using Belfer.Administrator.Model;
using System;
using System.Data;

namespace Belfer.Ustawienia.Model
{
    public class Privilege
    {
        public int ID { get; set; }
        public int TeacherID { get; set; }
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        public string SubjectType { get; set; }
        public PrivilegeAspect PrivilegeType { get; set; }
        public User.UserStatus PrivilegeStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Signature Creator { get; set; }

        public static Privilege CreatePrivilege(IDataReader R)
        {
            DateTime.TryParse(R["StartDate"].ToString(), out DateTime startDate);
            DateTime.TryParse(R["EndDate"].ToString(), out DateTime endDate);
            return new Privilege
            {
                ID = Convert.ToInt32(R["ID"]),
                TeacherID = Convert.ToInt32(R["IdNauczyciel"]),
                ClassID = Convert.ToInt32(R["Klasa"]),
                ClassName = R["NazwaKlasy"].ToString(),
                SubjectName = R["Alias"].ToString(),
                SubjectType = R["PrzedmiotTyp"].ToString(),
                PrivilegeType = (PrivilegeAspect)Convert.ToInt64(R["Typ"]),
                PrivilegeStatus = (User.UserStatus)Convert.ToInt64(R["Status"]),
                StartDate = startDate,
                EndDate = endDate,
                Creator = new Signature
                {
                    Owner = R["Owner"].ToString(),
                    User = R["User"].ToString(),
                    IP = R["ComputerIP"].ToString(),
                    Version = Convert.ToDateTime(R["Version"])
                }
            };
        }
    }
}
