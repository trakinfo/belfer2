namespace Belfer.Ustawienia.SQL
{
    public static class TutorSQL
    {
        public static string SelectSubjectScheme(string schoolID, string schoolYear)
        {
            return $"SELECT o.ID,sk.NazwaKlasy, sk.KodKlasy FROM obsada o INNER JOIN szkola_klasa sk ON sk.ID=o.Klasa INNER JOIN szkola_przedmiot sp ON sp.ID=o.Przedmiot WHERE sk.IdSzkola = {schoolID} AND sk.RokSzkolny = '{schoolYear}' AND sp.IdPrzedmiot IN (SELECT ID FROM przedmiot WHERE Typ = 'Z') ORDER BY sk.KodKlasy;";
        }

        internal static string SelectTutor(string schoolID, string schoolYear)
        {
            return $"SELECT p.ID,p.Typ,p.Status,p.StartDate,p.EndDate,p.IdNauczyciel,sk.ID as IdKlasa,sk.KodKlasy,sk.NazwaKlasy,sn.Status as NauczycielStatus, sn.Role, u.Login,u.Nazwisko,u.Imie, p.Owner, p.User, p.ComputerIP, p.Version FROM przywilej p INNER JOIN obsada o ON o.ID = p.IdObsada INNER JOIN szkola_klasa sk ON sk.ID = o.Klasa INNER JOIN szkola_nauczyciel sn ON sn.ID = p.IdNauczyciel INNER JOIN user u ON u.Login = sn.Nauczyciel INNER JOIN szkola_przedmiot sp ON sp.ID = o.Przedmiot WHERE sk.IdSzkola = {schoolID} AND sk.RokSzkolny = '{schoolYear}' AND sp.IdPrzedmiot IN (SELECT ID FROM przedmiot WHERE Typ = 'Z');";
        }
    }
}
