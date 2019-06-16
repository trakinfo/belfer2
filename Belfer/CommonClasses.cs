using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Drawing;
using System.Drawing.Printing;
using Autofac;
using DataBaseService;
using Belfer.Administrator.SQL;
using Belfer.Administrator.Model;

namespace Belfer
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
    /// <summary>
    /// Dostarcza metody i właściwości umożliwiające definiowanie przedziału czasu
    /// </summary>
    public class DateRange
    {
        DateTime startdate, enddate;
        /// <summary>
        /// Dostarcza datę początkową aktualnie ustawionego roku szkolnego lub przedziału czasu
        /// </summary>
        public DateTime StartDate { get { return startdate; } }

        /// <summary>
        /// Dostarcza datę końcową aktualnie ustawionego roku szkolnego lub przedziału czasu
        /// </summary>
        public DateTime EndDate { get { return enddate; } }
        /// <summary>
        /// Ustala datę początkową i końcową bieżącego roku szkolnego
        /// </summary>
        public DateRange()
        {
            startdate = CalcHelper.StartDateOfSchoolYear(UserSession.User.Settings.SchoolYear);
            enddate = CalcHelper.EndDateOfSchoolYear(UserSession.User.Settings.SchoolYear);
        }
        /// <summary>
        /// Ustala datę początkową i końcową danego roku szkolnego
        /// </summary>
        /// <param name="SchoolYear">Rok szkolny, którego granice zostaną ustawione</param>
        public DateRange(string SchoolYear)
        {
            if (SchoolYear.Length < 9) { return; }
            startdate = CalcHelper.StartDateOfSchoolYear(SchoolYear);
            enddate = CalcHelper.EndDateOfSchoolYear(SchoolYear);
        }
        /// <summary>
        /// Ustawia datę początkową i końcową danego przedziału czasu
        /// </summary>
        /// <param name="CustomStartDate">Dolna granica przedziału czasu</param>
        /// <param name="CustomEndDate">Górna granica przedziału czasu</param>
        public DateRange(DateTime CustomStartDate, DateTime CustomEndDate)
        {
            startdate = CustomStartDate;
            enddate = CustomEndDate;
        }
    }

    public static class Network
    {
        public static string HostName()
        {
            return Dns.GetHostName();
        }
        public static string HostIPv4()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address.ToString();
            }
        }

    }
    public static class OptionLoader
    {
        public static int GetMinPasswordLength()
        {
            try
            {
                var MinLength = 0;
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    int.TryParse(dbs.FetchSingleValueAsync(OpcjeSQL.SelectMinPasswordLength()).Result, out MinLength);
                }
                return MinLength;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int GetMaxPasswordLength()
        {
            var MaxLength = 15;
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    int.TryParse(dbs.FetchSingleValueAsync(OpcjeSQL.SelectMaxPasswordLength()).Result, out MaxLength);
                }
                return MaxLength;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string GetApplicationURL()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return dbs.FetchSingleValueAsync(OpcjeSQL.SelectApplicationURL()).Result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetDbVersion()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return dbs.FetchSingleValueAsync(OpcjeSQL.SelectDBVersion()).Result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DateTime GetServerDateTime()
        {
            try
            {
                var serverDateTime = DateTime.MinValue;
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    DateTime.TryParse(dbs.FetchSingleValueAsync(AdminSQL.SelectServerTime()).Result, out serverDateTime);
                    return serverDateTime;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string GetSslCipher()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return dbs.FetchSingleValueAsync(AdminSQL.SelectSsLCipher()).Result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public static class StringHelper
    {
        public static bool DigitOnly(string Value)
        {
            try
            {
                if (Value.Length == 0) return false;
                foreach (var S in Value)
                {
                    if (!char.IsDigit(S)) return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Verify string if it is a valid email string
        /// </summary>
        /// <param name="email">Text to verify against email principle</param>
        /// <returns>Returns true if e-mail is OK, otherwise false</returns>
        public static bool ValidateEmail(string email)
        {
            var pattern = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$";
            Regex rgx = new Regex(pattern);
            return rgx.IsMatch(email);
        }
        public static bool ValidatePassword(string pwd)
        {
            var MinLength = AppVars.MinPwdLength;
            var pattern = @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{" + MinLength + ",}";
            Regex rgx = new Regex(pattern);
            return rgx.IsMatch(pwd);
        }
        public static string RandomizePassword()
        {
            var MinPwdLength = AppVars.MinPwdLength;
            var MaxPwdLength = AppVars.MaxPwdLength;

            var PASSWORD_CHARS_LCASE = "abcdefghijkmnopqrstwxyz";
            var PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
            var PASSWORD_CHARS_NUMERIC = "23456789";
            var PASSWORD_CHARS_SPECIAL = "$?&!%";

            var charGroups = new char[][] { PASSWORD_CHARS_LCASE.ToCharArray(), PASSWORD_CHARS_UCASE.ToCharArray(), PASSWORD_CHARS_NUMERIC.ToCharArray(), PASSWORD_CHARS_SPECIAL.ToCharArray() };

            var charsLeftInGroup = new int[charGroups.Length];
            for (int i = 0; i < charsLeftInGroup.Length; i++)
            {
                charsLeftInGroup[i] = charGroups[i].Length;
            }

            var leftGroupsOrder = new int[charGroups.Length];
            for (int i = 0; i < leftGroupsOrder.Length; i++)
            {
                leftGroupsOrder[i] = i;
            }

            var randomBytes = new byte[4];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);

            var seed = BitConverter.ToInt32(randomBytes, 0);
            var random = new Random(seed);
            char[] password = null;

            if (MinPwdLength < MaxPwdLength)
            {
                password = new char[random.Next(MinPwdLength, MaxPwdLength)];
            }
            else
            {
                password = new char[MinPwdLength];
            }

            var nextCharIdx = new int();
            var nextGroupIdx = new int();
            var nextLeftGroupsOrderIdx = new int();
            var lastCharIdx = new int();
            var lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;

            for (int i = 0; i < password.Length; i++)
            {
                if (lastLeftGroupsOrderIdx == 0)
                {
                    nextLeftGroupsOrderIdx = 0;
                }
                else
                {
                    nextLeftGroupsOrderIdx = random.Next(0, lastLeftGroupsOrderIdx);
                }
                nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];
                lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;
                if (lastCharIdx == 0)
                {
                    nextCharIdx = 0;
                }
                else
                {
                    nextCharIdx = random.Next(0, lastCharIdx + 1);
                }
                password[i] = charGroups[nextGroupIdx][nextCharIdx];
                if (lastCharIdx == 0)
                {
                    charsLeftInGroup[nextGroupIdx] = charGroups[nextGroupIdx].Length;
                }
                else
                {
                    if (lastCharIdx != nextCharIdx)
                    {
                        var temp = charGroups[nextGroupIdx][lastCharIdx];
                        charGroups[nextGroupIdx][nextCharIdx] = charGroups[nextGroupIdx][nextCharIdx];
                        charGroups[nextGroupIdx][nextCharIdx] = temp;
                    }
                    charsLeftInGroup[nextGroupIdx] = charsLeftInGroup[nextGroupIdx] - 1;
                }
                if (lastLeftGroupsOrderIdx == 0)
                {
                    lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
                }
                else
                {
                    if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
                    {
                        var temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                        leftGroupsOrder[lastLeftGroupsOrderIdx] = leftGroupsOrder[nextLeftGroupsOrderIdx];
                        leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                    }
                    lastLeftGroupsOrderIdx = lastLeftGroupsOrderIdx - 1;
                }
            }
            return new string(password);

        }
    }

    public static class SeekHelper
    {
        /// <summary>
        /// Checks if a user has an Operator privilage or Administrator privilege
        /// </summary>
        /// <returns></returns>
        public static bool HasOperatorPrivilage() => UserSession.User.Role > User.UserRole.Nauczyciel;

        /// <summary>
        /// Checks if a user has an Administrator privilege
        /// </summary>
        /// <returns></returns>
        public static bool HasAdminPrivilage() => UserSession.User.Role > User.UserRole.Operator;

        /// <summary>
        /// Finds and select an item in the objectlistview according to single property of pointed type
        /// </summary>
        /// <typeparam name="T">Object model type which contains the property</typeparam>
        /// <typeparam name="T1">Property type to compare with record identyfier</typeparam>
        /// <param name="recordID">Record identyfier to compare with the property name</param>
        /// <param name="propertyName">Name of property which should be found in the object model type</param>
        /// <param name="olv">ObjectListView which owns the record and the object model</param>
        public static void SetListItem<T, T1>(T1 recordID, string propertyName, BrightIdeasSoftware.ObjectListView olv)
        {
            var Item = ((ISet<T>)olv.Objects).Where(x => ((T1)x.GetType().GetProperty(propertyName).GetValue(x)).Equals(recordID)).FirstOrDefault();
            if (Item == null) return;
            olv.SelectObject(Item);
            olv.SelectedItem.EnsureVisible();
        }

        /// <summary>
        /// Finds and select an item in the objectlistview according to two properties of pointed types
        /// </summary>
        /// <typeparam name="T">Object model type which contains the property</typeparam>
        /// <typeparam name="T1">Property type of first property to compare with record first identyfier</typeparam>
        /// <typeparam name="T2">Property type of second property to compare with record second identyfier</typeparam>
        /// <param name="Value1">Record first identyfier to compare with the first property name</param>
        /// <param name="Value2">Record second identyfier to compare with the second property name</param>
        /// <param name="propertyName1">Name of first property which should be found in the object model type</param>
        /// <param name="propertyName2">Name of second property which should be found in the object model type</param>
        /// <param name="olv">ObjectListView which owns the record and the object model</param>
        public static void SetListItem<T, T1, T2>(T1 Value1, T2 Value2, string propertyName1, string propertyName2, BrightIdeasSoftware.ObjectListView olv)
        {
            var Item = ((ISet<T>)olv.Objects)
                .Where(x => ((T1)x.GetType().GetProperty(propertyName1).GetValue(x)).Equals(Value1))
                .Where(x => ((T2)x.GetType().GetProperty(propertyName2).GetValue(x)).Equals(Value2))
                .FirstOrDefault();
            if (Item == null) return;
            olv.SelectObject(Item);
            olv.SelectedItem.EnsureVisible();
        }
    }
    /// <summary>
    /// Dostarcza metody umożliwiające wydruk tekstu
    /// </summary>
    public class PrintHelper
    {
        public Graphics G { get; set; }
        public delegate void NewRowHandler();
        public event NewRowHandler NewRow;
        public delegate void NextPageHandler(PrintDocument Doc, PrintPageEventArgs ppea);
        public event NextPageHandler NextPage;
        public bool IsPreview;
        public int PageNumber = default(int);
        public List<string> ReportHeader;
        public int[] Offset;
        public void PreviewModeChanged(bool PreviewMode) => IsPreview = PreviewMode;

        public void PrintNextPage(PrintDocument Doc, PrintPageEventArgs ppea)
        {
            if (IsPreview)
            {
                ppea.HasMorePages = true;
                NewRow?.Invoke();
                return;
            }
            if (ppea.PageSettings.PrinterSettings.PrintRange == PrintRange.SomePages)
            {
                if (!PageInRange(ppea.PageSettings.PrinterSettings.FromPage, ppea.PageSettings.PrinterSettings.ToPage))
                {
                    ppea.Graphics.Clear(Color.White);
                    //doc_PrintPage(Doc, ppea);
                    NextPage?.Invoke(Doc, ppea);
                }
                ppea.HasMorePages = PageNumber < ppea.PageSettings.PrinterSettings.ToPage;
                return;
            }
            ppea.HasMorePages = true;
        }
        private bool PageInRange(int RangeStart, int RangeEnd)
        {
            bool IsPageInRange = PageNumber >= RangeStart;
            IsPageInRange = IsPageInRange && (PageNumber <= RangeEnd);
            return IsPageInRange;
        }

        public void PrnDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            if (e.PrintAction == PrintAction.PrintToPrinter) PreviewModeChanged(false); else PreviewModeChanged(true);
            //if (e.PrintAction == PrintAction.PrintToPrinter) PH.IsPreview = false; else PH.IsPreview = true;
        }
        public void doc_EndPrint(object sender, PrintEventArgs e)
        {
            PageNumber = 0;
            for (int i = 0; i < Offset.GetLength(0); i++)
            {
                Offset[i] = 0;
            }
        }

        public void DrawText(string Text, Font TextFont, float x, float y, float PrintWidth, float PrintHeight, StringAlignment PrintAlignment, Brush FontColor, bool DrawLines = true, bool VerticalLayout = false, bool FillBackgroud = false)
        {
            x += UserSession.User.Settings.XCaliber;
            y += UserSession.User.Settings.YCaliber;
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = PrintAlignment;
            strFormat.LineAlignment = StringAlignment.Center;
            if (VerticalLayout) strFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            if (DrawLines) G.DrawRectangle(Pens.Black, x, y, PrintWidth, PrintHeight);
            if (FillBackgroud) G.FillRectangle(Brushes.LightGray, new RectangleF(x, y, PrintWidth, PrintHeight));
            G.DrawString(Text, TextFont, FontColor, new RectangleF(x, y, PrintWidth, PrintHeight), strFormat);
        }
        public void DrawText(string Text, Font TextFont, float x, float y, float PrintWidth, float PrintHeight, byte PrintAlignment, Brush FontColor, int PrintAngle, bool DrawLines = true)
        {
            x += UserSession.User.Settings.XCaliber;
            y += UserSession.User.Settings.YCaliber;
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = (StringAlignment)PrintAlignment;
            strFormat.LineAlignment = StringAlignment.Center;
            if (DrawLines) G.DrawRectangle(Pens.Black, x, y, PrintWidth, PrintHeight);
            G.TranslateTransform(x, y + PrintHeight, System.Drawing.Drawing2D.MatrixOrder.Append);
            G.RotateTransform(PrintAngle);
            G.DrawString(Text, TextFont, FontColor, new RectangleF(0, 0, PrintHeight, PrintWidth), strFormat);
            G.ResetTransform();
        }
        /// <summary>
        /// Umożliwia wydruk tekstu zawijanego do następnego wiersza
        /// </summary>
        /// <param name="PrintText">Text do wydrukowania w formie tablicy znaków</param>
        /// <param name="PrintFont">Czcionka</param>
        /// <param name="WordOffset">Wskaźnik położenia ostatnio wydrukowanego słowa przekazany przez referencję</param>
        /// <param name="x">współrzędna x przekazana przez wartość</param>
        /// <param name="y">Współrzędna y przekazana przez referencję</param>
        /// <param name="PrintWidth">Szerokość obszaru wydruku</param>
        /// <param name="PrintHeight">Wysokość obszaru wydruku</param>
        /// <param name="TextLineHeight">Wysokość linii tekstu</param>
        /// <param name="TabIndent">Wielkość wysunięcia tekstu</param>
        /// <returns></returns>
        public bool DrawWrappedText(string[] PrintText, Font PrintFont, ref int WordOffset, float x, ref float y, float PrintWidth, float PrintHeight, float TextLineHeight, int TabIndent = 0)
        {
            StringBuilder TextLine = new StringBuilder();
            do
            {
                TextLine.Append(String.Concat(PrintText[WordOffset], " "));
                if ((G.MeasureString(TextLine.ToString(), PrintFont).Width + TabIndent) > PrintWidth)
                {
                    TextLine.Remove(TextLine.ToString().Length - PrintText[WordOffset].Length - 1, PrintText[WordOffset].Length);
                    DrawText(TextLine.ToString(), PrintFont, x + TabIndent, y, PrintWidth, TextLineHeight, 0, Brushes.Black, false);
                    y += TextLineHeight;
                    WordOffset -= 1;
                    TextLine = new StringBuilder();
                }
                WordOffset += 1;
            } while (PrintText.GetUpperBound(0) >= WordOffset && PrintHeight >= y + TextLineHeight);
            if (PrintHeight >= (y + TextLineHeight))
            {
                DrawText(TextLine.ToString(), PrintFont, x + TabIndent, y, PrintWidth, TextLineHeight, 0, Brushes.Black, false);
                y += TextLineHeight;
                WordOffset = 0;
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Drukuje nr strony na górnym lub dolnym marginesie
        /// </summary>
        /// <param name="PageNumber">Nr strony</param>
        /// <param name="x">współrzędna x</param>
        /// <param name="y">współrzędna y</param>
        /// <param name="PrintWidth">Szerokość obszaru wydruku</param>
        /// <param name="Location">Lokalizacja nr strony (górny lub dolny margines)</param>
        /// <param name="HorizontalAlignment">Poziome położenie nr strony</param>
        public void DrawPageNumber(string PageNumber, float x, float y, float PrintWidth, PageNumberLocation Location, byte HorizontalAlignment = 1)
        {
            x += UserSession.User.Settings.XCaliber;
            y += UserSession.User.Settings.YCaliber;
            //var M = new CalcHelper.Math();
            var BaseFont = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);
            if (Location == PageNumberLocation.Header) { y -= CalcHelper.Math.MMtoIN(5) + BaseFont.GetHeight(G); } else { y += CalcHelper.Math.MMtoIN(5) + BaseFont.GetHeight(G); }
            var strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;
            strFormat.Alignment = (StringAlignment)HorizontalAlignment;
            G.DrawString(PageNumber, BaseFont, Brushes.Black, new Rectangle((int)x, (int)y, (int)PrintWidth, (int)BaseFont.GetHeight(G)), strFormat);
        }
        /// <summary>
        /// Drukuje nagłówek dokumentu na górnym marginesie strony
        /// </summary>
        /// <param name="x">Współrzędna początkowa pozioma</param>
        /// <param name="y">Współrzędna początkowa pionowa</param>
        /// <param name="PrintWidth">Szerokość obszaru wydruku</param>
        public void DrawHeader(float x, float y, float PrintWidth)
        {
            x += UserSession.User.Settings.XCaliber;
            y += UserSession.User.Settings.YCaliber;
            var DotPen = new Pen(Color.Black);
            //var M = new CalcHelper.Math();
            var HeaderFont = new Font("Arial", 8, FontStyle.Italic, GraphicsUnit.Point);
            y -= CalcHelper.Math.MMtoIN(5);
            G.DrawLine(DotPen, x, y, x + PrintWidth, y);
            y -= HeaderFont.GetHeight(G);
            var strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;
            strFormat.Alignment = StringAlignment.Near;
            G.DrawString(AppSession.Schools.Where(s => s.ID == UserSession.User.Settings.SchoolID).FirstOrDefault().Name, HeaderFont, Brushes.Black, new Rectangle((int)x, (int)y, (int)PrintWidth, (int)HeaderFont.GetHeight(G)), strFormat);
            strFormat.Alignment = StringAlignment.Far;
            G.DrawString("Rok szkolny: " + UserSession.User.Settings.SchoolYear, HeaderFont, Brushes.Black, new Rectangle((int)x, (int)y, (int)PrintWidth, (int)HeaderFont.GetHeight(G)), strFormat);
        }
        /// <summary>
        /// Drukuje stopkę dokumentu na dolnym marginesie strony
        /// </summary>
        /// <param name="x">Współrzędna początkowa pozioma</param>
        /// <param name="y">Współrzędna początkowa pionowa</param>
        /// <param name="PrintWidth">Szerokość obszaru wydruku</param>
        public void DrawFooter(float x, float y, float PrintWidth)
        {
            x += UserSession.User.Settings.XCaliber;
            y += UserSession.User.Settings.YCaliber;
            var DotPen = new Pen(Color.Black);
            //var M = new CalcHelper.Math();
            var FooterFont = new Font("Arial", 8, FontStyle.Italic, GraphicsUnit.Point);
            y += CalcHelper.Math.MMtoIN(5);
            G.DrawLine(DotPen, x, y, x + PrintWidth, y);
            y += FooterFont.GetHeight(G) / 2;
            var strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;
            strFormat.Alignment = StringAlignment.Near;
            G.DrawString(System.Windows.Forms.Application.ProductName + " (wersja " + System.Windows.Forms.Application.ProductVersion + ")", FooterFont, Brushes.Black, new Rectangle((int)x, (int)y, (int)PrintWidth, (int)FooterFont.GetHeight(G)), strFormat);
            strFormat.Alignment = StringAlignment.Far;
            G.DrawString(DateTime.Now.ToString(), FooterFont, Brushes.Black, new Rectangle((int)x, (int)y, (int)PrintWidth, (int)FooterFont.GetHeight(G)), strFormat);
        }
        public void DrawLine(float x0, float y0, float x1, float y1, float PenWidth = 1)
        {
            x0 += UserSession.User.Settings.XCaliber;
            y0 += UserSession.User.Settings.YCaliber;
            x1 += UserSession.User.Settings.XCaliber;
            y1 += UserSession.User.Settings.YCaliber;
            G.DrawLine(new Pen(Brushes.Black, PenWidth), x0, y0, x1, y1);
        }
        public void DrawRectangle(float PenWidth, float x0, float y0, float Width, float Height)
        {
            x0 += UserSession.User.Settings.XCaliber;
            y0 += UserSession.User.Settings.YCaliber;
            G.DrawRectangle(new Pen(Brushes.Black, PenWidth), x0, y0, Width, Height);
        }
        public void DrawImage(System.Drawing.Image img, float x, float y, float Width, float Height)
        {
            x += UserSession.User.Settings.XCaliber;
            y += UserSession.User.Settings.YCaliber;
            G.DrawImage(img, x, y, Width, Height);
        }
    }
}