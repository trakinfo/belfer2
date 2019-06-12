using System;

namespace Belfer
{
    public class Student
    {
        private string pesel = "";
        DateTime birthDate = new DateTime(1900, 1, 1);
        /// <summary>
        /// Identyfikator ucznia w bazie danych
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Nazwisko
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Pierwsze imię
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Drugie imię
        /// </summary>
        public string SecondName { get; set; }
        /// <summary> Nr arkusza ocen ucznia </summary>
        public string RegistryNo { get; set; }
        /// <summary>
        /// Pierwsze imię ojca
        /// </summary>
        public string FatherFirstName { get; set; }
        /// <summary>
        /// Nazwisko ojca
        /// </summary>
        public string FatherLastName { get; set; }
        /// <summary>
        /// Pierwsze imię matki
        /// </summary>
        public string MotherFirstName { get; set; }
        /// <summary>
        /// Nazwisko matki
        /// </summary>
        public string MotherLastName { get; set; }
        /// <summary>
        /// Data urodzenia
        /// </summary>
        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                if (value > birthDate) birthDate = value;
            }
        }
        /// <summary>
        /// Nr identyfikacyjny PESEL
        /// </summary>
        public string Pesel { get => pesel; set { if (CalcHelper.ValidatePesel(value)) pesel = value; } }
        /// <summary>
        /// Płeć
        /// </summary>
        public User.UserSex Sex { get; set; }
        /// <summary>
        /// Miejsce urodzenia
        /// </summary>
        public City BirthPlace { get; set; }
        /// <summary>
        /// Miejsce zamieszkania
        /// </summary>
        public City ResidencePlace { get; set; }
        /// <summary>
        /// Nazwa ulicy, przy której znajduje się posesja
        /// </summary>
        public string StreetName { get; set; }
        /// <summary>
        /// Nr domu (posesji) 
        /// </summary>
        public string PropertyNo { get; set; }
        /// <summary>
        /// Nr mieszkania 
        /// </summary>
        public string ApartmentNo { get; set; }
        /// <summary>
        /// Nr telefonu głównego (stacjonarnego)
        /// </summary>
        public string PhoneNo { get; set; }
        /// <summary>
        /// Nr telefonu komórkowego
        /// </summary>
        public string MobilePhoneNo { get; set; }
        /// <summary>
        /// Nr drugiego telefonu komórkowego
        /// </summary>
        public string MobilePhoneNo2 { get; set; }
        /// <summary>
        /// Dane osoby, która wprowadziła dane do bazy danych
        /// </summary>
        public Signature Creator { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
        public string FullName { get => $"{LastName} {FirstName} {SecondName}"; }
        public string MotherFullName { get => $"{MotherLastName} {MotherFirstName}".Trim(' '); }
        public string FatherFullName { get => $"{FatherLastName} {FatherFirstName}".Trim(' '); }
        /// <summary>
        /// Adres zamieszkania w formacie ulica nr domu/nr mieszkania
        /// </summary>
        public string Address
        {
            get
            {
                var No = $"{PropertyNo}/{ApartmentNo}".Trim('/');
                return $"{StreetName} {No}";
            }
        }
        /// <summary>
        /// Pełny adres zawierający dodatkowo miejscowość zamieszkania
        /// </summary>
        public string FullAddress { get => $"{Address}, {ResidencePlace.ToString()}".Trim(", ".ToCharArray()); }
    } 
}