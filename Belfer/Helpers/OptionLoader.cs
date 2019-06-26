using Autofac;
using Belfer.Administrator.SQL;
using Belfer.Helpers.SQL;
using DataBaseService;
using System;

namespace Belfer.Helpers
{
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
                    return dbs.FetchRecordAsync(AdminSQL.SelectSsLCipher(), (R) => R.GetString(1)).Result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
