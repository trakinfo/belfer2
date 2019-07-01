using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belfer.Ustawienia.SQL
{
    public static class TeacherSQL
    {
        public static string SelectTeacher(string SchoolID)
        {
            return $"SELECT sn.ID, u.Login,u.Nazwisko,u.Imie,sn.Status,sn.Role,sn.Owner,sn.User,sn.ComputerIP,sn.Version FROM szkola_nauczyciel sn INNER JOIN user u ON u.Login=sn.Nauczyciel WHERE sn.IdSzkola={SchoolID};";
        }
        public static string InsertTeacher()
        {
            return "INSERT INTO szkola_nauczyciel(IdSzkola,Nauczyciel,Status,Role,Owner,User,ComputerIP) VALUES (@SchoolID,@Login,@Status,@Role,@Owner,@User,@IP);";
        }
        public static string DeleteTeacher()
        {
            return "DELETE FROM szkola_nauczyciel WHERE ID=@ID;";
        }
        public static string UpdateTeacher()
        {
            return "UPDATE szkola_nauczyciel SET Role=@Rola,Status=@Status,User=@User,ComputerIP=@IP WHERE ID=@ID;";
        }
    }
}
