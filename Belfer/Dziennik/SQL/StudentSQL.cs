namespace Belfer.Dziennik
{
    public static class StudentSQL
	{
		internal static string SelectStudent(string SchoolId, string SchoolYear)
		{
			return $"SELECT p.ID, p.IdUczen, p.IdKlasa, IFNULL(p.NrwDzienniku,0) AS NrwDzienniku, p.Promocja, p.StatusAktywacji, p.DataAktywacji, p.DataDeaktywacji, p.MasterRecord, u.Nazwisko, u.Imie, u.Imie2, u.NrArkusza, u.ImieOjca, u.NazwiskoOjca, u.ImieMatki, u.NazwiskoMatki, u.DataUr, u.Pesel, u.IdMiejsceUr, u.IdMiejsceZam, u.Ulica, u.NrDomu, u.NrMieszkania, u.Tel, u.TelKom1, u.TelKom2, IFNULL(u.Man,0) AS Man, sk.KodKlasy, sk.NazwaKlasy, sk.IsVirtual,m.Kod AS KodUr,m.Nazwa AS NazwaUr,m.Polska AS PolskaUr,m.Poczta AS PocztaUr,m.KodPocztowy AS KodPocztowyUr,m1.Nazwa AS NazwaZam,m1.Kod AS KodZam,m1.Polska AS PolskaZam,m1.Poczta AS PocztaZam,m1.KodPocztowy AS KodPocztowyZam,u.Owner,u.User,u.ComputerIP,u.Version FROM przydzial p INNER JOIN uczen u ON p.IdUczen = u.ID INNER JOIN szkola_klasa sk ON p.IdKlasa = sk.ID LEFT JOIN miejscowosc m ON u.IdMiejsceUr = m.ID LEFT JOIN miejscowosc m1 ON u.IdMiejsceZam = m1.ID WHERE sk.IdSzkola = '{SchoolId}' AND sk.RokSzkolny = '{SchoolYear}';";
		}
		internal static string SelectRepeater(string SchoolId, string SchoolYear)
		{
			return $"SELECT DISTINCT p.IdUczen FROM przydzial p INNER JOIN szkola_klasa sk ON p.IdKlasa=sk.ID WHERE sk.IdSzkola = '{SchoolId}' AND sk.RokSzkolny = '{SchoolYear}' AND p.StatusAktywacji = 1 AND p.IdUczen IN (SELECT DISTINCT p.IdUczen FROM przydzial p INNER JOIN szkola_klasa sk ON p.IdKlasa= sk.ID WHERE sk.RokSzkolny= '{CalcHelper.SchoolYear(UserSession.User.Settings.Year - 1)}' AND Promocja = 0 AND StatusAktywacji = 1)";
		}

		internal static string InsertStudent()
		{
			return "INSERT INTO uczen VALUES(null,?Nazwisko,?Imie,?Imie2,?NrArkusza,?ImieOjca,?NazwiskoOjca,?ImieMatki,?NazwiskoMatki,?DataUr,?Pesel,?IdMiejsceUr,?IdMiejsceZam,?Ulica,?NrDomu,?NrMieszkania,?Tel,?TelKom1,?TelKom2,?Man,?Owner,?User,?IP,NULL);";
		}
		internal static string InsertStudentAllocation()
		{
			return "INSERT INTO przydzial VALUES(null,?IdUczen,?IdKlasa,?NrwDzienniku,?Promocja,?StatusAktywacji,?DataAktywacji,?DataDeaktywacji,?MasterRecord,?Owner,?User,?IP,NULL);";
		}
		internal static string UpdateStudent()
		{
			return "UPDATE uczen SET Nazwisko=?Nazwisko, Imie=?Imie, Imie2=?Imie2, NrArkusza=?NrArkusza, ImieOjca=?ImieOjca, NazwiskoOjca=?NazwiskoOjca, ImieMatki=?ImieMatki, NazwiskoMatki=?NazwiskoMatki, DataUr=?DataUr, Pesel=?Pesel, IdMiejsceUr=?IdMiejsceUr, IdMiejsceZam=?IdMiejsceZam, Ulica=?Ulica, NrDomu=?NrDomu, NrMieszkania=?NrMieszkania, Tel=?Tel, TelKom1=?TelKom1, TelKom2=?TelKom2, Man=?Man, User=?User, ComputerIP=?IP WHERE ID=?ID;";
		}
		internal static string UpdateStudentAllocation()
		{
			return "UPDATE przydzial SET NrwDzienniku=?NrwDzienniku, DataAktywacji=?DataAktywacji, DataDeaktywacji=?DataDeaktywacji, User=?User, ComputerIP=?IP WHERE ID=?ID;";
		}
		internal static string DeleteStudent()
		{
			return "DELETE FROM uczen WHERE ID=?ID";
		}
	}
}
