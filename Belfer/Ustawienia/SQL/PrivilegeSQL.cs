namespace Belfer.Ustawienia.SQL
{
    public static class PrivilegeSQL
    {
        public static string SelectTeacher(string SchoolID)
        {
            return "SELECT sn.ID,u.Nazwisko,u.Imie,sn.Status,sn.Role FROM szkola_nauczyciel sn INNER JOIN user u ON u.Login=sn.Nauczyciel WHERE sn.IdSzkola=" + SchoolID + ";";
        }
        public static string SelectPrivilege(int TeacherId, string SchoolYear)
        {
            return "SELECT p.ID,p.IdNauczyciel,o.Klasa,sk.NazwaKlasy,if(pt.Typ='Z',pt.Nazwa,pt.Alias) as Alias,pt.Typ as PrzedmiotTyp, p.Typ, p.Status, p.StartDate, p.EndDate, p.Owner, p.User,p.ComputerIP,p.Version FROM przywilej p INNER JOIN obsada o ON p.IdObsada=o.ID INNER JOIN szkola_przedmiot sp ON o.Przedmiot=sp.ID INNER JOIN szkola_klasa sk ON o.Klasa = sk.ID INNER JOIN przedmiot pt ON sp.IdPrzedmiot = pt.ID WHERE p.IdNauczyciel ='" + TeacherId + "' AND sk.RokSzkolny = '" + SchoolYear + "' ORDER BY sk.KodKlasy,sp.Priorytet; ";
        }
        public static string SelectExclusion(int TeacherId, string SchoolYear)
        {
            return "SELECT w.IdPrzydzial, w.IdPrzywilej, Concat_WS(' ',u.Nazwisko,u.Imie) AS Student, sk.NazwaKlasy, if(pt.Typ='Z',pt.Nazwa,pt.Alias) as Alias, w.StartDate, w.EndDate, w.Owner, w.User, w.ComputerIP, w.Version FROM wykluczenie w INNER JOIN przydzial p ON w.IdPrzydzial = p.ID INNER JOIN przywilej pj ON w.IdPrzywilej = pj.ID INNER JOIN uczen u ON u.ID = p.IdUczen INNER JOIN szkola_Klasa sk ON sk.ID = p.IdKlasa INNER JOIN obsada o ON o.ID = pj.IdObsada INNER JOIN szkola_przedmiot sp ON o.Przedmiot = sp.ID INNER JOIN przedmiot pt ON sp.IdPrzedmiot = pt.ID WHERE sk.RokSzkolny = '" + SchoolYear + "' AND pj.IdNauczyciel = '" + TeacherId + "' ORDER BY sk.KodKlasy, sp.Priorytet, p.NrwDzienniku, u.Nazwisko, u.Imie;";
        }
        //public static string SelectExclusion(string PrivilegeId)
        //{
        //	return "SELECT w.IdPrzydzial, w.IdPrzywilej,Concat_WS(' ',u.Nazwisko,u.Imie) AS Student,w.Owner,w.User,w.ComputerIP,w.Version FROM wykluczenie w INNER JOIN przydzial p ON w.IdPrzydzial = p.ID INNER JOIN przywilej pj ON w.IdPrzywilej = pj.ID INNER JOIN uczen u ON u.ID = p.IdUczen WHERE w.IdPrzywilej ='" + PrivilegeId + "' ORDER BY p.NrwDzienniku,u.Nazwisko,u.Imie;";
        //}
        public static string SelectScheme(string SchoolId, string SchoolYear, string TeacherId)
        {
            return "SELECT o.ID, sk.NazwaKlasy, p.Nazwa,o.DataAktywacji,o.DataDeaktywacji FROM obsada o INNER JOIN szkola_klasa sk ON o.Klasa = sk.ID INNER JOIN szkola_przedmiot sp ON o.Przedmiot = sp.ID INNER JOIN przedmiot p ON p.ID = sp.IdPrzedmiot WHERE sk.IdSzkola = '" + SchoolId + "' AND sk.RokSzkolny = '" + SchoolYear + "' AND o.ID NOT IN (SELECT p.IdObsada FROM przywilej p WHERE p.IdNauczyciel='" + TeacherId + "') ORDER BY sk.KodKlasy, sp.Priorytet;";
        }
        public static string InsertPrivilege()
        {
            return "INSERT INTO przywilej(IdObsada,IdNauczyciel,Typ,Status,StartDate,EndDate,Owner,User,ComputerIP) VALUES(@SchemeId,@TeacherId,@Type,@Status,@StartDate,@EndDate,@Owner,@User,@IP);";
        }
        public static string DeletePrivilege()
        {
            return "DELETE FROM przywilej WHERE ID=@ID;";
        }

        internal static string DeleteExclusion()
        {
            return "DELETE FROM wykluczenie WHERE IdPrzydzial=@AllocationID AND IdPrzywilej=@PrivilegeID;";
        }

        internal static string UpdatePrivilege()
        {
            return "UPDATE przywilej SET Typ=@Typ,Status=@Status,StartDate=@DataAktywacji,EndDate=@DataDeaktywacji,User=@User,ComputerIP=@IP WHERE ID=@ID;";
        }
        internal static string SelectStudent(int ClassID, int PrivilegeID)
        {
            return $"SELECT p.ID,p.NrwDzienniku,u.Nazwisko,u.Imie,p.StatusAktywacji,p.DataAktywacji,p.DataDeaktywacji FROM uczen u INNER JOIN przydzial p ON p.IdUczen=u.ID WHERE p.IdKlasa = {ClassID} AND p.ID NOT IN (SELECT w.IdPrzydzial FROM wykluczenie w WHERE w.IdPrzywilej = {PrivilegeID}) AND p.StatusAktywacji=1 ORDER BY p.NrwDzienniku,u.Nazwisko,u.Imie;";
        }
        internal static string InsertExclusion()
        {
            return "INSERT INTO wykluczenie(IdPrzydzial,IdPrzywilej,StartDate,EndDate,Owner,User,ComputerIP) VALUES(@AllocationID,@PrivilegeID,@StartDate,@EndDate,@Owner,@User,@IP);";
        }
        internal static string UpdateExclusion()
        {
            return "UPDATE wykluczenie SET StartDate=@DataAktywacji,EndDate=@DataDeaktywacji,User=@User,ComputerIP=@IP WHERE IdPrzydzial=@IdPrzydzial AND IdPrzywilej=@IdPrzywilej;";
        }
    }
}
