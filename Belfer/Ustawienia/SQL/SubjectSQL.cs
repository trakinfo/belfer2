namespace Belfer.Ustawienia.SQL
{
    public static class SubjectSQL
    {
        public static string SelectSchoolSubject(string SchoolId, string ClassId)
        {
            return $"SELECT s.ID, p.Alias FROM szkola_przedmiot s INNER JOIN przedmiot p ON p.ID=s.IdPrzedmiot WHERE s.IdSzkola='{SchoolId}' And p.Typ!='Z' And s.ID NOT IN (SELECT o.Przedmiot FROM obsada o WHERE o.Klasa='{ClassId}') ORDER BY s.Priorytet;";
        }
        public static string SelectSchoolSubject(string SchoolId)
        {
            return $"SELECT s.ID, p.Nazwa, s.Priorytet, s.Owner, s.User, s.ComputerIP, s.Version FROM szkola_przedmiot s INNER JOIN przedmiot p ON p.ID=s.IdPrzedmiot WHERE s.IdSzkola='{SchoolId}' ORDER BY s.Priorytet;";
        }
        public static string SelectSubject(string SchoolId)
        {
            return $"SELECT p.ID, p.Alias, p.Nazwa, p.Typ FROM przedmiot p WHERE p.ID NOT IN (SELECT s.ID FROM szkola_przedmiot s WHERE IdSzkola='{SchoolId}') ORDER BY p.Priorytet;";
        }
        public static string SelectSubject()
        {
            return $"SELECT p.ID, p.Alias, p.Nazwa, p.Typ, p.Priorytet, p.Owner, p.User, p.ComputerIP, p.Version FROM przedmiot p ORDER BY p.Priorytet;";
        }

    }
}
