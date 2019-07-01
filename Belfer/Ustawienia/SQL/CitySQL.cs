using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belfer.Ustawienia.SQL
{
    public static class CitySQL
    {
        internal static string SelectCity()
        {
            return "SELECT m.ID, m.Kod, m.Nazwa, m.NazwaMiejscownik, m.Polska, m.Poczta, m.KodPocztowy FROM miejscowosc m Order By m.Nazwa;";
        }

        internal static string SelectAllPlaceFromSimc()
        {
            return "SELECT s.woj, s.pow, s.gmi, s.rodz_gmi, s.nazwa, s.sym, s.sympodst FROM simc s Order By s.nazwa;";
        }

        internal static string SelectSomePlaceFromSimc()
        {
            return "SELECT s.woj, s.pow, s.gmi, s.rodz_gmi, s.nazwa, s.sym, s.sympodst FROM simc s INNER JOIN miejscowosc m ON m.Kod=s.sym Order By s.nazwa;";
        }

        internal static string SelectPlaceFromSimc()
        {
            return "SELECT s.woj, s.pow, s.gmi, s.rodz_gmi, s.nazwa, s.sym, s.sympodst FROM simc s WHERE s.sym NOT IN (Select Kod From miejscowosc WHERE Kod is not null) Order By s.nazwa;";
        }
        internal static string SelectPlaceFromSimc(string CityCode)
        {
            return "SELECT s.woj, s.pow, s.gmi, s.rodz_gmi, s.nazwa, s.sym, s.sympodst FROM simc s WHERE s.sym=" + CityCode + ";";
        }

        internal static string SelectCommunity()
        {
            return "SELECT g.Kod,g.Nazwa FROM gmina g;";
        }

        internal static string SelectCounty()
        {
            return "SELECT p.Kod,p.Nazwa FROM powiat p;";
        }

        internal static string SelectProvince()
        {
            return "SELECT w.Kod,w.Nazwa FROM wojewodztwo w;";
        }

        internal static string InsertCity()
        {
            return "INSERT INTO miejscowosc (Kod,Nazwa,Polska,Owner,User,ComputerIP) VALUES(@Kod,@Nazwa,@Polska,@Owner,@User,@ComputerIP);";
        }
    }
}
