using Autofac;
using Belfer.Ustawienia;
using DataBaseService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace Belfer
{
    public class City : Simc.CityBySimc
    {
        string postalCode;
        string postOffice = string.Empty;

        public int ID { get; set; }
        public bool Poland { get; set; }
        public string PostOffice { get => postOffice; set => postOffice = value; }
        public string PostalCode { get => string.IsNullOrEmpty(postalCode) ? "" : postalCode.Insert(2, "-"); set => postalCode = value; }


        public override string ToString()
        {
            return $"{Address}, {Location}".TrimEnd(", ".ToCharArray());
        }

        public string Address
        {
            get
            {
                var Address = string.Concat(Name.ToUpper(), ", ", PostalCode).Trim(", ".ToCharArray());
                Address += string.Concat(" ", PostOffice).TrimEnd(" ".ToCharArray());

                return Address;
            }
        }

        public string Location
        {
            get
            {
                var location = string.Concat("gm: ", CommunityName).TrimEnd("gm: ".ToCharArray());
                location = string.Concat(location, "; pow: ", CountyName).TrimEnd("; pow: ".ToCharArray());
                location = string.Concat(location, "; woj: ", ProvinceName != null ? ProvinceName.ToLower() : null).TrimEnd("; woj: ".ToCharArray());
                return location;
            }
        }

        static internal long? AddCity()
        {
            using (var dlg = new dlgCity())
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) return dlg.AddCity();
                return null;
            }
        }

        internal static class ComboItems
        {
            static IEnumerable<Simc.CityBySimc> GetSimc()
            {
                var S = new Simc(CitySQL.SelectSomePlaceFromSimc());
                return S.CityListBySimc;
            }
            public static IList<City> GetCities()
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return dbs.FetchRecordSetAsync(CitySQL.SelectCity(), CityModel).Result.ToList();
                }
            }

            private static City CityModel(IDataReader R)
            {
                var simcList = GetSimc();
                var city = new City();
                city.ID = Convert.ToInt32(R["ID"]);
                city.Code = R["Kod"].ToString();
                city.Name = R["Nazwa"].ToString();
                city.Poland = Convert.ToBoolean(R["Polska"]);
                city.PostOffice = R["Poczta"].ToString();
                city.PostalCode = R["KodPocztowy"].ToString();
                if (city.Poland)
                {
                    city.ProvinceName = simcList.Where(x => x.Code == city.Code).FirstOrDefault().ProvinceName;
                    city.CountyName = simcList.Where(x => x.Code == city.Code).FirstOrDefault().CountyName;
                    city.CommunityName = simcList.Where(x => x.Code == city.Code).FirstOrDefault().CommunityName;
                }
                return city;
            }

            static internal int GetCityIndex(int CityID, System.Windows.Forms.ComboBox.ObjectCollection Items)
            {
                foreach (var item in Items)
                {
                    if (((City)item).ID == CityID) return Items.IndexOf(item);
                }
                return 0;
            }
        }
    }
    
}
