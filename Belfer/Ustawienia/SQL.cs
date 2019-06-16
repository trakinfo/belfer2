using Belfer.Administrator.Model;

namespace Belfer.Ustawienia
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
	public static class SubjectSQL
	{
		public static string SelectSchoolSubject(string SchoolId, string ClassId)
		{
			return "SELECT s.ID, p.Alias FROM szkola_przedmiot s INNER JOIN przedmiot p ON p.ID=s.IdPrzedmiot WHERE s.IdSzkola='" + SchoolId + "' And p.Typ!='Z' And s.ID NOT IN (SELECT o.Przedmiot FROM obsada o WHERE o.Klasa='" + ClassId + "') ORDER BY s.Priorytet;";
		}
	}
	public static class PrivilegeSQL
	{
		public static string SelectTeacher(string SchoolID)
		{
			return "SELECT sn.ID,u.Nazwisko,u.Imie,sn.Status,sn.Role FROM szkola_nauczyciel sn INNER JOIN user u ON u.Login=sn.Nauczyciel WHERE sn.IdSzkola=" + SchoolID + ";";
		}
		public static string SelectPrivilege(int TeacherId, string SchoolYear)
		{
			return "SELECT p.ID,o.Klasa,sk.NazwaKlasy,if(pt.Typ='Z',pt.Nazwa,pt.Alias) as Alias,pt.Typ as PrzedmiotTyp, p.Typ, p.Status, p.StartDate, p.EndDate, p.Owner, p.User,p.ComputerIP,p.Version FROM przywilej p INNER JOIN obsada o ON p.IdObsada=o.ID INNER JOIN szkola_przedmiot sp ON o.Przedmiot=sp.ID INNER JOIN szkola_klasa sk ON o.Klasa = sk.ID INNER JOIN przedmiot pt ON sp.IdPrzedmiot = pt.ID WHERE p.IdNauczyciel ='" + TeacherId + "' AND sk.RokSzkolny = '" + SchoolYear + "' ORDER BY sk.KodKlasy,sp.Priorytet; ";
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
