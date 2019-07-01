namespace Belfer.Ustawienia.SQL
{
    public static class SchoolClassSQL
    {
        public static string SelectSchoolClassCombo(string SchoolId, string SchoolYear)
        {
            return "SELECT s.ID, s.KodKlasy, s.NazwaKlasy FROM szkola_klasa s WHERE s.IdSzkola = '" + SchoolId + "' AND s.RokSzkolny = '" + SchoolYear + "' Order By s.KodKlasy;";
        }
        public static string SelectClassCombo(string SchoolId, string SchoolYear)
        {
            return "SELECT Kod FROM klasa WHERE Kod NOT IN (SELECT s.KodKlasy FROM szkola_klasa s WHERE s.IdSzkola = '" + SchoolId + "' AND s.RokSzkolny = '" + SchoolYear + "') ORDER BY Kod;";
        }
        public static string SelectSchoolClassList(string SchoolId, string SchoolYear)
        {
            return "SELECT s.ID, s.KodKlasy, s.NazwaKlasy,s.IsVirtual,s.Owner,s.User,s.ComputerIP,s.Version FROM szkola_klasa s WHERE s.IdSzkola = '" + SchoolId + "' AND s.RokSzkolny = '" + SchoolYear + "' Order By s.KodKlasy;";
        }
        public static string SelectSchoolClassLine(string SchoolId, string SchoolYear)
        {
            return $"SELECT DISTINCT LEFT(KodKlasy,1) AS Pion FROM szkola_klasa WHERE IdSzkola='{SchoolId}' AND RokSzkolny='{SchoolYear}';";
        }
        public static string InsertSchoolClass()
        {
            return "INSERT INTO szkola_klasa(IdSzkola,KodKlasy,RokSzkolny,NazwaKlasy,IsVirtual,Owner,User,ComputerIP) VALUES (@IdSzkola,@KodKlasy,@RokSzkolny,@NazwaKlasy,@IsVirtual,@Owner,@User,@IP);";
        }

        internal static string DeleteSchoolClass()
        {
            return "DELETE FROM szkola_klasa WHERE ID=@ID;";
        }

        internal static string UpdateSchoolClass()
        {
            return "UPDATE szkola_klasa SET NazwaKlasy=@NazwaKlasy,IsVirtual=@IsVirtual,User=@User,ComputerIP=@IP WHERE ID=@ID;";
        }
    }
}
