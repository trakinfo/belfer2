using Autofac;
using Belfer.Administrator.Model;
using Belfer.Helpers.SQL;
using DataBaseService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Belfer.Helpers
{
    public static class CalcHelper
    {
        /// <summary>
        /// Rok szkolny w formacie 'yyyy/yyyy+1'
        /// </summary>
        /// <param name="year">Liczba całkowita oznaczająca rok kalendarzowy będący pierwszym członem roku szkolnego</param>
        /// <returns>yyyy/yyyy+1</returns>
        public static string SchoolYear(int year)
        {
            return $"{year}/{year + 1}";
        }
        public static DateTime StartDateOfSchoolYear()
        {
            if (DateTime.Today.Month > 8)
            {
                return new DateTime(DateTime.Today.Year, 9, 1);
            }
            else
            {
                return new DateTime(DateTime.Today.Year - 1, 9, 1);
            }
        }

        public static DateTime StartDateOfSchoolYear(string SchoolYear)
        {
            if (SchoolYear.Length < 4) { return default(DateTime); }
            int Year = default(int);
            if (int.TryParse(SchoolYear.Substring(0, 4), out Year)) { return new DateTime(Year, 9, 1); } else { return default(DateTime); }
        }
        public static DateTime EndDateOfSchoolYear(string SchoolYear)
        {
            if (SchoolYear.Length < 9) { return default(DateTime); }
            int Year = default(int);
            if (int.TryParse(SchoolYear.Substring(5, 4), out Year)) { return new DateTime(Year, 8, 31); } else { return default(DateTime); }
        }
        public static bool ValidateNip(string NipNumber)
        {
            try
            {
                long Total;
                byte ctrlFigure, ctrlDigit;
                if (NipNumber.Trim().Length != 10) return false;
                if (!StringHelper.DigitOnly(NipNumber)) return false;
                const string WeightNumber = "657234567";
                Total = 0;
                for (int i = 0; i < WeightNumber.Length; i++)
                {
                    byte WeightDigit, NipDigit;
                    byte.TryParse(WeightNumber.Substring(i, 1), out WeightDigit);
                    byte.TryParse(NipNumber.Substring(i, 1), out NipDigit);
                    Total += WeightDigit * NipDigit;
                }
                ctrlFigure = (byte)(Total % 11);
                byte.TryParse(NipNumber.Substring(NipNumber.Length - 1, 1), out ctrlDigit);
                return ctrlFigure == ctrlDigit;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static User.UserSex GetSexFromPesel(string Pesel)
        {
            if (!ValidatePesel(Pesel)) return User.UserSex.K;
            int Sex;
            int.TryParse(Pesel.ElementAt(9).ToString(), out Sex);
            return (User.UserSex)(Sex % 2);
        }

        public static DateTime GetBirthDateFromPesel(string Pesel)
        {
            if (!ValidatePesel(Pesel)) return AppSession.CurrentDateAndTime;
            int Year, Month, Day;
            int.TryParse(Pesel.Substring(0, 2).ToString(), out Year);
            int.TryParse(Pesel.Substring(2, 2), out Month);
            int.TryParse(Pesel.Substring(4, 2), out Day);

            if (Month - 20 > 0 && Month - 20 < 13) return new DateTime(2000 + Year, Month - 20, Day);
            else if (Month - 80 > 0) return new DateTime(1800 + Year, Month - 80, Day);
            else return new DateTime(1900 + Year, Month, Day);
        }
        public static bool ValidatePesel(string Pesel)
        {
            try
            {
                if (Pesel.Length != 11 || !StringHelper.DigitOnly(Pesel)) return false;
                const string Weight = "1379137913";
                int Total = 0;
                for (int i = 0; i < Weight.Length; i++)
                {
                    int w, p;
                    int.TryParse(Weight.ElementAt(i).ToString(), out w);
                    int.TryParse(Pesel.ElementAt(i).ToString(), out p);
                    Total += w * p;
                }
                var Reminder = Total % 10;
                var ctrlDigit = 10 - Reminder;
                if (ctrlDigit == 10) ctrlDigit = 0;
                return Pesel.Last().ToString() == ctrlDigit.ToString();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidateSimc(string Number)
        {
            try
            {
                long Total;
                byte ctrlFigure, ctrlDigit;
                if (Number.Trim().Length != 6) return false;
                if (!StringHelper.DigitOnly(Number)) return false;
                const string WeightNumber = "234567";
                Total = 0;
                for (int i = 0; i < WeightNumber.Length; i++)
                {
                    byte WeightDigit, SimcDigit;
                    byte.TryParse(WeightNumber.Substring(i, 1), out WeightDigit);
                    byte.TryParse(Number.Substring(i, 1), out SimcDigit);
                    Total += WeightDigit * SimcDigit;
                }
                ctrlFigure = (byte)(Total % 11);
                ctrlFigure %= 10;
                byte.TryParse(Number.Substring(Number.Length - 1, 1), out ctrlDigit);
                return ctrlFigure == ctrlDigit;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DateTime StartDateOfSemester2(DateTime CurrDate)
        {
            try
            {
                var StartDate = DateTime.Today;
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    var val = dbs.FetchSingleValueAsync(OpcjeSQL.SelectStartDateOfSemester2(UserSession.User.Settings.SchoolID.ToString(), CurrDate)).Result;
                    DateTime.TryParse(val, out StartDate);
                }
                return StartDate;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DateTime StartDateOfWeek(DateTime Date)
        {
            int Offset = (Date.DayOfWeek == 0 ? 7 : (int)Date.DayOfWeek) - 1;
            return Date.AddDays(-Offset);
        }
        public static DateTime EndDateOfWeek(DateTime Date)
        {
            int Offset = 7 - (Date.DayOfWeek == 0 ? 7 : (int)Date.DayOfWeek);
            return Date.AddDays(Offset);
        }

        public static class Math
        {
            public static double Mediana(IEnumerable<double> Numbers)
            {
                if (Numbers.Count() == 0)
                {
                    throw new InvalidOperationException("Nie można obliczyć mediany z pustego zbioru!");
                }
                var sortedNumbers = Numbers.OrderBy(x => x).ToArray(); //from number in Numbers orderby number select number;
                int NumberIndex = sortedNumbers.Count() / 2;
                if (sortedNumbers.Count() % 2 == 0)
                {
                    return (float)(sortedNumbers[NumberIndex] + sortedNumbers[NumberIndex - 1]) / 2;
                }
                else
                {
                    return sortedNumbers[NumberIndex];
                }
            }
            /// <summary>
            /// Znajduje wartość występującą najczęściej w zbiorze liczb
            /// </summary>
            /// <param name="Numbers">Zbiór liczb do przeszukania</param>
            /// <returns>Liczba najczęściej występująca w zbiorze</returns>
            public static double Dominanta(IEnumerable<double> Numbers)
            {
                if (Numbers.Count() == 0) { throw new InvalidOperationException("Nie można obliczyć dominanty z pustego zbioru!"); }
                double modal = 0;

                var DistinctNumbers = Numbers.Distinct().ToArray();
                foreach (var Number in DistinctNumbers)
                {
                    if (Numbers.Where(x => x == Number).Count() > Numbers.Where(x => x == modal).Count()) { modal = Number; }
                }
                return modal;
            }
            public static float INtoMM(float Inch) { return Inch / (float)3.937; }
            public static float MMtoIN(float mm) { return mm * (float)3.937; }
            public static int RoundToNearest(double value, double midpoint)
            {
                double decimalpoints = System.Math.Abs(value - System.Math.Floor(value));
                if (decimalpoints > midpoint)
                    return (int)System.Math.Ceiling(value);
                else
                    return (int)System.Math.Floor(value);
            }
        }
    }
}
