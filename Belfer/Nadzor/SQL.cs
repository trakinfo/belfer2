using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belfer.Nadzor
{
	public static class KontrolaSQL
	{
		/// <summary>
		/// Kwerenda wybiera uczniów z danej szkoły wg przydziału w danym roku szkolnym z uwzględnieniem przydziałów nieaktywnych
		/// </summary>
		/// <param name="Szkola"> Identyfikator szkoły</param>
		/// <param name="RokSzkolny">Rok szkolny</param>
		public static string SelectStudent(string Szkola, string RokSzkolny)
		{
			return "SELECT u.ID As IdUczen,Concat_WS(' ',u.Nazwisko,u.Imie) AS Student, p.IdKlasa, p.StatusAktywacji, p.DataAktywacji, p.DataDeaktywacji, p.MasterRecord,sk.NazwaKlasy From uczen u INNER JOIN przydzial p ON u.ID = p.IdUczen INNER JOIN szkola_klasa sk ON p.IdKlasa = sk.ID WHERE sk.RokSzkolny = '" + RokSzkolny + "' AND sk.IdSzkola='" + Szkola + "';";
		}
		public static string SelectPrzedmiot(string Szkola, string RokSzkolny)
		{
			return "SELECT DISTINCT o.Przedmiot,if(p.Alias='gw','godz. wychowawcza',p.Nazwa) AS Nazwa,o.Grupa,sp.Priorytet,o.Klasa,p.ID,p.Typ FROM obsada o INNER JOIN szkola_przedmiot sp ON sp.ID = o.Przedmiot INNER JOIN przedmiot p ON sp.IdPrzedmiot = p.ID INNER JOIN szkola_klasa sk ON o.Klasa = sk.ID WHERE sk.RokSzkolny = '" + RokSzkolny + "' AND sk.IdSzkola='" + Szkola + "' ORDER BY o.Klasa,sp.Priorytet; ";
		}
		public static string SelectLekcja(string Szkola, string RokSzkolny, DateRange SchoolYearDateRange)
		{
			//return $"SELECT t.ID,t.Data,o.Przedmiot,if(p.Alias='gw','godz. wychowawcza',p.Nazwa) AS Nazwa,sp.Grupa,o.Klasa,sp.Priorytet FROM temat t INNER JOIN lekcja l ON l.ID=t.IdLekcja INNER JOIN obsada o ON o.ID=l.IdObsada INNER JOIN szkola_przedmiot sp ON o.Przedmiot=sp.ID INNER JOIN przedmiot p ON p.ID=sp.IdPrzedmiot WHERE t.Status=1 AND t.Data BETWEEN '{SchoolYearDateRange.StartDate.ToShortDateString()}' AND '{SchoolYearDateRange.EndDate.ToShortDateString()}' AND o.RokSzkolny='{RokSzkolny}' AND sp.IdSzkola='{Szkola}' AND t.ID NOT IN (SELECT t.ID FROM temat t, zastepstwo z WHERE t.IdLekcja=z.IdLekcja AND t.Data=z.Data AND z.Status=1) UNION SELECT z.ID,z.Data,z.IdPrzedmiotSzkola AS Przedmiot,if(p.Alias='gw','godz. wychowawcza',p.Nazwa) AS Nazwa,sp.Grupa,o.Klasa,sp.Priorytet FROM zastepstwo z INNER JOIN lekcja l ON z.IdLekcja=l.ID INNER JOIN obsada o ON o.ID=l.IdObsada INNER JOIN szkola_przedmiot sp ON z.IdPrzedmiotSzkola=sp.ID INNER JOIN przedmiot p ON p.ID=sp.IdPrzedmiot WHERE z.Data BETWEEN '{SchoolYearDateRange.StartDate.ToShortDateString()}' AND '{SchoolYearDateRange.EndDate.ToShortDateString()}' AND o.RokSzkolny='{RokSzkolny}' AND sp.IdSzkola='{Szkola}' AND z.Status = 1 AND z.IdPrzedmiotSzkola IS NOT NULL ORDER BY Data;";

			return $"SELECT t.ID,t.Data,o.Przedmiot,if (p.Alias = 'gw','godz. wychowawcza',p.Nazwa) AS Nazwa, l.IdGrupa,o.Klasa,sp.Priorytet FROM temat t INNER JOIN lekcja l ON l.ID = t.IdLekcja INNER JOIN obsada o ON o.ID = l.IdObsada INNER JOIN szkola_przedmiot sp ON o.Przedmiot = sp.ID INNER JOIN przedmiot p ON p.ID = sp.IdPrzedmiot INNER JOIN szkola_klasa sk ON o.Klasa = sk.ID WHERE t.Status = 1 AND t.Data BETWEEN '{SchoolYearDateRange.StartDate.ToShortDateString()}' AND '{SchoolYearDateRange.EndDate.ToShortDateString()}' AND sk.RokSzkolny = '{RokSzkolny}' AND sp.IdSzkola = '{Szkola}' AND t.ID NOT IN (SELECT t.ID FROM temat t, zastepstwo z WHERE t.IdLekcja = z.IdLekcja AND t.Data = z.Data AND z.Status = 1) UNION SELECT z.ID,z.Data,z.IdPrzedmiot AS Przedmiot,if (p.Alias = 'gw','godz. wychowawcza',p.Nazwa) AS Nazwa, z.IdGrupa,o.Klasa,sp.Priorytet FROM zastepstwo z INNER JOIN lekcja l ON z.IdLekcja = l.ID INNER JOIN obsada o ON o.ID = l.IdObsada INNER JOIN szkola_przedmiot sp ON z.IdPrzedmiot = sp.ID INNER JOIN przedmiot p ON p.ID = sp.IdPrzedmiot INNER JOIN szkola_klasa sk ON o.Klasa = sk.ID WHERE z.Data BETWEEN '{SchoolYearDateRange.StartDate.ToShortDateString()}' AND '{SchoolYearDateRange.EndDate.ToShortDateString()}' AND sk.RokSzkolny = '{RokSzkolny}' AND sp.IdSzkola = '{Szkola}' AND z.Status = 1 AND z.IdPrzedmiot IS NOT NULL ORDER BY Data;";
		}

		public static string SelectGrupaPrzedmiotowaBySchool(string Szkola, string RokSzkolny)
		{
			return $"SELECT g.ID,g.IdPrzedmiot as Przedmiot,p.IdUczen,p.IdKlasa,sg.StartDate,sg.EndDate FROM grupa g INNER JOIN sklad_grupa sg ON g.ID = sg.IdGrupa INNER JOIN przydzial p ON p.ID = sg.IdPrzydzial INNER JOIN szkola_klasa sk ON sk.ID = p.IdKlasa WHERE sk.RokSzkolny = '{RokSzkolny}' AND sk.IdSzkola = '{Szkola}';";
		}
		public static string CountAbsence(string Szkola, string RokSzkolny, DateRange SchoolYearDateRange)
		{
			//return $"SELECT f.IdUczen,o.Przedmiot,f.Typ,COUNT(f.ID) AS Abs,f.Data FROM frekwencja f RIGHT JOIN przydzial p ON f.IdUczen = p.IdUczen INNER JOIN szkola_klasa sk ON p.Klasa = sk.ID INNER JOIN lekcja l ON l.ID = f.IdLekcja INNER JOIN obsada o ON o.ID = l.IdObsada WHERE f.Typ <> 's' AND f.Data BETWEEN '{SchoolYearDateRange.StartDate.ToShortDateString()}' AND '{SchoolYearDateRange.EndDate.ToShortDateString()}' AND p.RokSzkolny='{RokSzkolny}' AND sk.IdSzkola='{Szkola}' AND p.StatusAktywacji = 1 AND f.ID NOT IN (SELECT fk.ID FROM frekwencja fk INNER JOIN zastepstwo z ON fk.IdLekcja = z.IdLekcja WHERE f.Data = z.Data AND z.Status = 1) GROUP BY f.IdUczen,o.Przedmiot,f.Data,f.Typ UNION ALL SELECT f.IdUczen,z.IdPrzedmiotSzkola AS Przedmiot,f.Typ,COUNT(f.ID) AS Abs, f.Data FROM frekwencja f INNER JOIN lekcja l ON f.IdLekcja = l.ID INNER JOIN obsada o ON o.ID = l.IdObsada INNER JOIN zastepstwo z ON l.ID = z.IdLekcja INNER JOIN szkola_klasa sk ON o.Klasa = sk.ID WHERE f.Typ <> 's' AND f.Data BETWEEN '{SchoolYearDateRange.StartDate.ToShortDateString()}' AND '{SchoolYearDateRange.EndDate.ToShortDateString()}' AND o.RokSzkolny='{RokSzkolny}' AND sk.IdSzkola='{Szkola}' AND z.Status = 1 AND f.Data = z.Data AND z.IdPrzedmiotSzkola IS NOT NULL Group BY f.IdUczen,z.IdPrzedmiotSzkola,f.Data,f.Typ; ";
			return $"SELECT f.IdUczen,o.Przedmiot,f.Typ,COUNT(f.ID) AS Abs,f.Data FROM frekwencja f RIGHT JOIN przydzial p ON f.IdUczen = p.IdUczen INNER JOIN szkola_klasa sk ON p.IdKlasa = sk.ID INNER JOIN lekcja l ON l.ID = f.IdLekcja INNER JOIN obsada o ON o.ID = l.IdObsada WHERE f.Typ <> 's' AND f.Data BETWEEN '{SchoolYearDateRange.StartDate.ToShortDateString()}' AND '{SchoolYearDateRange.EndDate.ToShortDateString()}' AND sk.RokSzkolny = '{RokSzkolny}' AND sk.IdSzkola = '{Szkola}' AND p.StatusAktywacji = 1 AND f.ID NOT IN(SELECT fk.ID FROM frekwencja fk INNER JOIN 	zastepstwo z ON fk.IdLekcja = z.IdLekcja WHERE f.Data = z.Data AND z.Status = 1) GROUP BY f.IdUczen,o.Przedmiot,f.Data,f.Typ UNION ALL SELECT f.IdUczen,z.IdPrzedmiot AS Przedmiot,f.Typ,COUNT(f.ID) AS Abs, f.Data FROM frekwencja f INNER JOIN lekcja l ON f.IdLekcja = l.ID INNER JOIN obsada o ON o.ID = l.IdObsada INNER JOIN zastepstwo z ON l.ID = z.IdLekcja INNER JOIN szkola_klasa sk ON o.Klasa = sk.ID WHERE f.Typ <> 's' AND f.Data BETWEEN '{SchoolYearDateRange.StartDate.ToShortDateString()}' AND '{SchoolYearDateRange.EndDate.ToShortDateString()}' AND sk.RokSzkolny = '{RokSzkolny}' AND sk.IdSzkola = '{Szkola}' AND z.Status = 1 AND f.Data = z.Data AND z.IdPrzedmiot IS NOT NULL Group BY f.IdUczen,z.IdPrzedmiot,f.Data,f.Typ;";
		}
		public static string SelectWynik(string Szkola, string RokSzkolny, string Okres)
		{
			return "SELECT w.IdUczen,so.Ocena,so.Waga As WagaOceny,k.Waga As WagaKolumny,o.Klasa,o.Przedmiot,sp.IdPrzedmiot FROM wynik w INNER JOIN skala_ocen so ON w.IdOcena = so.ID INNER JOIN kolumna k ON w.IdKolumna = k.ID INNER JOIN obsada o ON k.IdObsada = o.ID INNER JOIN szkola_przedmiot sp ON o.Przedmiot = sp.ID INNER JOIN szkola_klasa sk ON o.Klasa = sk.ID WHERE so.Typ = 'P' And so.Waga > 0 AND k.Typ = 'C1' AND sk.IdSzkola = '" + Szkola + "' AND sk.RokSzkolny = '" + RokSzkolny + "';";
		}
	}
	public static class PoprawkaSQL
	{
		/// <summary>
		/// Kwerenda pobiera listę uczniów dopuszczonych do egzaminu poprawkowego, wraz z przedmiotami i nauczycielami prowadzącymi 
		/// </summary>
		/// <param name="Szkola">Identyfikator szkoły, ogranicza zakres danych do uczniów wskazanej szkoły</param>
		/// <param name="RokSzkolny">Ogranicza zakres danych do wskazanego roku szkolnego</param>
		/// <returns></returns>
		public static string SelectStudent(string Szkola, string RokSzkolny)
		{
			return "SELECT u.ID AS IdStudent,CONCAT_WS(' ',u.Nazwisko,u.Imie) AS Student,sk.Nazwa_Klasy AS Klasa,CONCAT_WS(' ',n.Nazwisko,n.Imie) AS Nauczyciel,pt.Nazwa AS Przedmiot FROM przydzial p INNER JOIN poprawka pk ON p.ID = pk.IdPrzydzial INNER JOIN szkola_klasa sk ON sk.ID = p.Klasa INNER JOIN uczen u ON p.IdUczen = u.ID INNER JOIN obsada o ON pk.IdObsada = o.ID INNER JOIN szkola_nauczyciel sn On o.Nauczyciel = sn.ID INNER JOIN nauczyciel n ON n.ID = sn.IdNauczyciel INNER JOIN szkola_przedmiot sp ON sp.ID = o.Przedmiot INNER JOIN przedmiot pt ON pt.ID = sp.IdPrzedmiot WHERE pk.Typ = 'R' AND sk.IdSzkola = '" + Szkola + "' AND p.RokSzkolny = '" + RokSzkolny + "' ORDER BY sp.Priorytet,u.Nazwisko,u.Imie;";
		}
	}
	public static class StatystykaSQL
	{
		/// <summary>
		/// Kwerenda zlicza oceny w poszczególnych klasach z poszczególnych przedmiotów i dla poszczególnych nauczycieli
		/// </summary>
		/// <param name="Szkola">Identyfikator szkoły, której kwerenda dotyczy</param>
		/// <param name="RokSzkolny">Rok szkolny, którego kwerenda dotyczy</param>
		/// <param name="Okres">Okres roku szkolnego ( semestr I lub rok szkolny)</param>
		/// <returns></returns>
		public static String SelectLiczbaOcen(String Szkola, String RokSzkolny, String Okres)
		{
			return "SELECT COUNT(w.ID) AS LiczbaOcen,o.Klasa,sp.IdPrzedmiot,o.Nauczyciel,so.Waga FROM wyniki w INNER JOIN kolumna k ON w.IdKolumna=k.ID INNER JOIN obsada o ON k.IdObsada=o.ID INNER JOIN szkola_przedmiot sp ON o.Przedmiot=sp.ID INNER JOIN skala_ocen so ON so.ID=w.IdOcena WHERE sp.IdSzkola='" + Szkola + "' AND o.RokSzkolny='" + RokSzkolny + "' AND k.Typ='" + Okres + "'  AND sp.IdPrzedmiot NOT IN (SELECT ID FROM przedmiot WHERE Typ='Z') AND so.Waga>=0 GROUP BY o.Klasa, w.IdOcena, sp.IdPrzedmiot, o.Nauczyciel;";
		}
		/// <summary>
		/// Kwerenda pobiera aktywną obsadę wszystkich przedmiotów w szkole w danym roku szkolnym dla wskazanego okresu
		/// </summary>
		/// <param name="Szkola">Identyfikator szkoły</param>
		/// <param name="RokSzkolny">Rok szkolny</param>
		/// <param name="DataKoncowaOkresu">Data końca semestru lub roku szkolnego</param>
		/// <returns></returns>
		public static string SelectObsada(string Szkola, string RokSzkolny, DateTime DataKoncowaOkresu)
		{
			return "SELECT DISTINCT sp.IdPrzedmiot,o.Przedmiot As IdSzkolaPrzedmiot,p.Nazwa As Przedmiot,o.Nauczyciel AS IdNauczyciel,Concat_WS(' ',n.Nazwisko,n.Imie) AS Nauczyciel,o.Klasa,sk.Nazwa_Klasy,sk.IsVirtual FROM obsada o INNER JOIN szkola_przedmiot sp ON o.Przedmiot=sp.ID INNER JOIN przedmiot p ON sp.IdPrzedmiot=p.ID INNER JOIN szkola_nauczyciel sn ON o.Nauczyciel=sn.ID INNER JOIN nauczyciel n ON n.ID = sn.IdNauczyciel INNER JOIN szkola_klasa sk ON o.Klasa = sk.ID WHERE sp.IdSzkola = '" + Szkola + "' AND o.RokSzkolny = '" + RokSzkolny + "' AND p.Typ NOT IN('Z', 'F') AND Date(o.DataAktywacji) <= '" + DataKoncowaOkresu.ToShortDateString() + "' AND(Date(o.DataDeaktywacji) > '" + DataKoncowaOkresu.ToShortDateString() + "' OR o.DataDeaktywacji IS NULL) ORDER BY sp.Priorytet, n.Nazwisko, n.Imie, sk.Nazwa_Klasy;";
		}
		/// <summary>
		/// Kweredna pobiera liczbę uczniów w klasach, łącznie z uczniami nauczanymi indywidualnie
		/// </summary>
		/// <param name="Szkola">Identyfikator szkoły</param>
		/// <param name="RokSzkolny">Rok szkolny</param>
		/// <param name="DataKoncowaOkresu">Końcowa data okresu (semestru lub roku szkolnego)</param>
		/// <returns></returns>
		public static string SelectStanKlasy(String Szkola, String RokSzkolny, DateTime DataKoncowaOkresu)
		{
			return "SELECT p.Klasa,COUNT(p.ID) As StanKlasy FROM przydzial p INNER JOIN szkola_klasa sk ON sk.ID = p.Klasa WHERE sk.IdSzkola = '" + Szkola + "' AND p.RokSzkolny = '" + RokSzkolny + "' AND DATE(p.DataAktywacji) <= '" + DataKoncowaOkresu.ToShortDateString() + "' AND(DATE(p.DataDeaktywacji) > '" + DataKoncowaOkresu.ToShortDateString() + "' OR p.DataDeaktywacji is null) Group BY p.Klasa;";
		}
		/// <summary>
		/// Kwerenda pobiera liczbę uczniów w klasach wirtualnych z uwzględnieniem przedmiotów nauczanych indywidualnie
		/// </summary>
		/// <param name="Szkola">Identyfikator szkoły</param>
		/// <param name="RokSzkolny">Rok szkolny</param>
		/// <param name="DataKoncowaOkresu">Końcowa data okresu (semestru lub roku szkolnego)</param>
		/// <returns></returns>
		public static string SelectStanKlasyWirtualnej(String Szkola, String RokSzkolny, DateTime DataKoncowaOkresu)
		{
			return "SELECT o.Klasa AS KlasaWirtualna,p.Klasa,sp.IdPrzedmiot,COUNT(ni.IdPrzydzial) AS StanKlasy FROM obsada o INNER JOIN nauczanie_indywidualne ni ON o.ID=ni.IdObsada INNER JOIN szkola_przedmiot sp ON sp.ID=o.Przedmiot INNER JOIN przydzial p ON p.ID = ni.IdPrzydzial WHERE sp.IdSzkola='" + Szkola + "' AND p.RokSzkolny='" + RokSzkolny + "' AND DATE(o.DataAktywacji) <= '" + DataKoncowaOkresu.ToShortDateString() + "' AND (DATE(o.DataDeaktywacji) > '" + DataKoncowaOkresu.ToShortDateString() + "' OR o.DataDeaktywacji is null) GROUP BY o.Klasa,sp.IdPrzedmiot;";
		}
		/// <summary>
		/// Kwerenda zlicza uczniów należących do grup przedmiotowych wg klas i przedmiotów 
		/// </summary>
		/// <param name="Szkola">Identyfikator szkoły</param>
		/// <param name="RokSzkolny">Rok szkolny</param>
		/// <returns></returns>
		public static string CountGroupMember(string Szkola, string RokSzkolny)
		{
			return "SELECT Count(g.IdSzkolaPrzedmiot) AS StanGrupy,p.Klasa,sp.IdPrzedmiot,g.IdSzkolaPrzedmiot FROM grupa g INNER JOIN przydzial p ON p.ID=g.IdPrzydzial INNER JOIN szkola_przedmiot sp ON sp.ID=g.IdSzkolaPrzedmiot WHERE p.RokSzkolny = '" + RokSzkolny + "' AND sp.IdSzkola = '" + Szkola + "' AND p.StatusAktywacji = 1 GROUP BY Klasa,IdPrzedmiot,IdSzkolaPrzedmiot;";
		}
	}
}
