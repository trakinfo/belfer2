namespace Belfer.Administrator.SQL
{
    public static class AdminSQL
    {
        public static string SelectSsLCipher() => "SHOW STATUS LIKE 'Ssl_cipher';";
        public static string SelectServerTime() => "SELECT Now();";
    }
}
