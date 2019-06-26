using System.IO;
using Belfer.DataBaseContext;
using Newtonsoft.Json;

namespace Belfer.Helpers
{
    public static class JSonHelper
    {
        public static bool CreateConfigFile(string ConfigFilePath, ConnectionParams SourceObject)
        {
            try
            {
                using (StreamWriter SW = new StreamWriter(ConfigFilePath))
                {
                    var JS = new JsonSerializer();
                    JS.Formatting = Formatting.Indented;
                    JS.Serialize(SW, SourceObject);
                    return true;
                }
            }
            catch (System.Exception)
            {
                throw;
            }

        }
        public static ConnectionParams ReadConfigFile(string ConfigFilePath)
        {
            try
            {
                return JsonConvert.DeserializeObject<ConnectionParams>(File.ReadAllText(ConfigFilePath));
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
