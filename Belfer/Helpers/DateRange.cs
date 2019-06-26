using System;

namespace Belfer.Helpers
{
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
}
