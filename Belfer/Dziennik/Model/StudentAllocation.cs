using Belfer.Administrator.Model;
using System;

namespace Belfer
{
    public class StudentAllocation
    {
        DateTime startDate, endDate;
        public StudentAllocation()
        {
            var schoolYearRange = new DateRange();
            startDate = schoolYearRange.StartDate;
            endDate = schoolYearRange.EndDate;
        }
        /// <summary>
        /// Identyfikator przydziału ucznia w danym roku szkolnym
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Dane personalne ucznia
        /// </summary>
        public Student Student { get; set; }
        /// <summary>
        /// Dane przydziału ucznia do oddziału klasowego w danym roku szkolnym
        /// </summary>
        public SchoolClass StudentClass { get; set; }
        /// <summary>
        /// Numer ucznia w dzienniku
        /// </summary>
        public int StudentNo { get; set; }
        /// <summary>
        /// Informacja o promocji ucznia do następnej klasy
        /// </summary>
        public YesNo IsPromoted { get; set; }
        /// <summary>
        /// Status aktywacji przydziału ucznia w danym roku szkolnym
        /// </summary>
        public User.UserStatus Status { get; set; }
        /// <summary>
        /// Data aktywacji przydziału ucznia w danym roku szkolnym
        /// </summary>
        public DateTime StartDate
        {
            get => startDate;
            set
            {
                if (value != DateTime.MinValue) startDate = value;
            }
        }
        /// <summary>
        /// Data deaktywacji przydziału ucznia w danym roku szkolnym
        /// </summary>
        public DateTime EndDate
        {
            get => endDate;
            set
            {
                if (value != DateTime.MinValue) endDate = value;
            }
        }
        /// <summary>
        /// Ostatni (aktualny) przydział ucznia aktywnego lub nieaktywnego
        /// </summary>
        public YesNo MasterRecord { get; set; }
        /// <summary>
        /// Dane osoby, która wprowadziła rekord do tabeli bazy danych
        /// </summary>
        public Signature Creator { get; set; }
    }
}
