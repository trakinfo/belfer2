using Belfer.Administrator.Model;

namespace Belfer.Ustawienia.SQL
{
    public static class SchoolSQL
    {
        public static string SelectSchool()
        {
            return "SELECT s.ID, s.Nazwa, s.Alias, s.NIP, s.Ulica, s.Nr, m.ID as IdMiejscowosc, m.Kod, m.Nazwa as Miejscowosc, m.KodPocztowy, m.Poczta, s.Telefon, s.Fax, s.Email, s.IdTypSzkoly, ts.Typ, ts.Opis, s.Owner, s.User, s.ComputerIP, s.Version FROM szkola s LEFT JOIN miejscowosc m ON s.IdMiejscowosc=m.ID INNER JOIN typy_szkol ts ON s.IdTypSzkoly=ts.ID;";
        }
        public static string SelectSchool(string User, User.UserStatus Status)
        {
            return "SELECT sn.ID,sn.IdSzkola,sn.Role FROM szkola_nauczyciel sn WHERE sn.Nauczyciel = '" + User + "' AND sn.Status='" + (byte)Status + "';";
        }
        public static string SelectSchoolType()
        {
            return "SELECT t.ID, t.Typ, t.Opis, t.Owner, t.User, t.ComputerIP, t.Version FROM typy_szkol t;";
        }

        public static string InsertSchool()
        {
            return "INSERT INTO szkola(IdTypSzkoly, Nazwa, Alias, NIP, Ulica, Nr, IdMiejscowosc, Telefon, Fax, Email, Owner, User, ComputerIP) VALUES(@IdTyp,@Nazwa,@Alias,@Nip,@Ulica,@Nr,@IdMiejscowosc,@Telefon,@Fax,@Email,@Owner,@User,@IP);";
        }
        public static string InsertSchoolType()
        {
            return "INSERT INTO typy_szkol(Typ,Opis, Owner, User, ComputerIP) VALUES(@Typ,@Opis,@Owner,@User,@IP)";
        }
        public static string UpdateSchool()
        {
            return "UPDATE szkola SET Nazwa=@Nazwa,Alias=@Alias,NIP=@Nip,Ulica=@Ulica,Nr=@Nr,IdMiejscowosc=@IdMiejscowosc,Telefon=@Telefon,Fax=@Fax,Email=@Email,User=@User,ComputerIP=@IP WHERE ID=@ID;";
        }
        internal static string UpdateSchoolType()
        {
            return "UPDATE typy_szkol SET Typ=@Nazwa,Opis=@Opis,User=@User,ComputerIP=@IP WHERE ID=@ID;";
        }
        public static string DeleteSchool()
        {
            return "DELETE FROM szkola WHERE ID=@ID;";
        }

        internal static string DeleteSchoolType()
        {
            return "DELETE FROM typy_szkol WHERE ID=@ID;";
        }
    }
}
