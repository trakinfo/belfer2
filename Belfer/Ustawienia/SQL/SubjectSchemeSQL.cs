using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belfer.Ustawienia.SQL
{
    public static class SubjectSchemeSQL
    {
        public static string SelectScheme(string SchoolId, string SchoolYear)
        {
            return "SELECT o.ID, sk.NazwaKlasy, p.Nazwa, o.Grupa, o.Kategoria, o.GetToAverage, o.DataAktywacji, o.DataDeaktywacji, o.LiczbaGodzin, o.Owner, o.User, o.ComputerIP, o.Version FROM obsada o INNER JOIN szkola_klasa sk ON o.Klasa = sk.ID INNER JOIN szkola_przedmiot sp ON o.Przedmiot = sp.ID INNER JOIN przedmiot p ON p.ID = sp.IdPrzedmiot WHERE sk.IdSzkola = '" + SchoolId + "' AND sk.RokSzkolny = '" + SchoolYear + "' ORDER BY sk.KodKlasy, sp.Priorytet;";
        }
        public static string SelectScheme(string SchoolId, string PreviousSchoolYear, string ClassCodeList)
        {
            return "SELECT o.Przedmiot, sk.KodKlasy, sk.NazwaKlasy, p.Nazwa, o.Grupa, o.Kategoria, o.GetToAverage, o.LiczbaGodzin FROM obsada o INNER JOIN szkola_klasa sk ON o.Klasa = sk.ID INNER JOIN szkola_przedmiot sp ON o.Przedmiot = sp.ID INNER JOIN przedmiot p ON p.ID = sp.IdPrzedmiot WHERE sk.IdSzkola = '" + SchoolId + "' AND sk.RokSzkolny = '" + PreviousSchoolYear + "'AND sk.KodKlasy IN (" + ClassCodeList + ") ORDER BY sk.KodKlasy,sp.Priorytet;";
        }
        public static string InsertScheme()
        {
            return "INSERT INTO obsada(Klasa,Przedmiot,Grupa,Kategoria,GetToAverage,DataAktywacji,DataDeaktywacji,LiczbaGodzin,Owner,User,ComputerIP) VALUES (@Klasa,@Przedmiot,@Grupa,@Kategoria,@Avg,@StartDate,@EndDate,@LiczbaGodzin,@Owner,@User,@IP);";
        }

        public static string UpdateScheme()
        {
            return "UPDATE obsada SET Grupa=@Grupa,Kategoria=@Kategoria,GetToAverage=@Avg,DataAktywacji=@DataAktywacji,DataDeaktywacji=@DataDeaktywacji,LiczbaGodzin=@LiczbaGodzin,User=@User,ComputerIP=@IP WHERE ID=@ID;";
        }
        public static string DeleteScheme()
        {
            return "DELETE FROM obsada WHERE ID=@ID;";
        }

    }
}
