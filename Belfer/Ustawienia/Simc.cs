using Autofac;
using Belfer.Ustawienia;
using Belfer.Ustawienia.SQL;
using DataBaseService;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using System.Threading.Tasks;

namespace Belfer
{
    public class Simc
    {
        public Simc(string selectSimc)
        {
            this.selectSimc = selectSimc;
            FetchData();
        }

        readonly string selectSimc;
        Task<IEnumerable<Terc>> ProvinceList;
        Task<IEnumerable<Terc>> CountyList;
        Task<IEnumerable<Terc>> CommunityList;
        Task<IEnumerable<CityBySimc>> simcList;
        public IEnumerable<CityBySimc> CityListBySimc => simcList.Result;

        void FetchData()
        {
            ProvinceList = FetchTercAsync(CitySQL.SelectProvince());
            CountyList = FetchTercAsync(CitySQL.SelectCounty());
            CommunityList = FetchTercAsync(CitySQL.SelectCommunity());
            simcList = FetchSimcAsync();
        }
        async Task<IEnumerable<CityBySimc>> FetchSimcAsync()
        {
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.FetchRecordSetAsync(selectSimc, SimcModel);
            }
        }

        private CityBySimc SimcModel(IDataReader R)
        {
            var City = new CityBySimc();
            City.Code = R["sym"].ToString();
            City.PrimaryCode = R["sympodst"].ToString();
            City.Name = R["nazwa"].ToString();
            City.CommunityCode = R["gmi"].ToString();
            City.CommunityType = R["rodz_gmi"].ToString();
            City.CountyCode = R["pow"].ToString();
            City.ProvinceCode = R["woj"].ToString();
            City.ProvinceName = GetName(ProvinceList.Result, City.ProvinceCode);
            City.CountyName = GetName(CountyList.Result, City.CountyCode);
            City.CommunityName = GetName(CommunityList.Result, City.CommunityCode);
            return City;
        }

        async Task<IEnumerable<Terc>> FetchTercAsync(string selectString)
        {
            var TercList = new HashSet<Terc>();
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.FetchRecordSetAsync(selectString, (R) => new Terc() { Code = R["Kod"].ToString(), Name = R["Nazwa"].ToString() });
            }
            
        }
        private string GetName(IEnumerable<Terc> List, string Key)
        {
            var T = List.Where(x => x.Code == Key).FirstOrDefault();
            if (T == null) return string.Empty;
            return T.Name;
        }

        public class CityBySimc
        {
            string woj, pow, gmi;
            public string Name { get; set; }
            public string Code { get; set; }
            public string PrimaryCode { get; set; }
            public string CommunityType { get; set; }

            public string ProvinceCode { get => woj; set => woj = value; }
            public string CountyCode { get => string.Concat(woj, pow); set => pow = value; }
            public string CommunityCode { get => string.Concat(woj, pow, gmi); set => gmi = value; }

            public string ProvinceName { get; set; }
            public string CountyName { get; set; }
            public string CommunityName { get; set; }
        }
        class Terc
        {
            internal string Code { get; set; }
            internal string Name { get; set; }
        }
    }
}
