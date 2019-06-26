using System.IO;
using Newtonsoft.Json;

namespace Belfer.DataBaseContext
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
                //using (StreamReader SR = new StreamReader(ConfigFilePath))
                //{
                //	var JS = new JsonSerializer();
                //                TargetObject = (ConnectionParams)JS.Deserialize(SR, typeof(ConnectionParams));
                //                return true;
                //}
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        //public static JObject ReadConfigFile(string ConfigFilePath)
        //{
        //    try
        //    {
        //        using (StreamReader SR = new StreamReader(ConfigFilePath))
        //        {
        //            JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(SR));
        //            return o;
        //        }
        //    }
        //    catch (System.Exception)
        //    {
        //        throw;
        //    }
        //}
        //public static JsonSchema GetSchema(System.Type ObjectType)
        //{
        //    try
        //    {
        //        var SchemaGenerator = new JsonSchemaGenerator();
        //        var schema = SchemaGenerator.Generate(ObjectType);
        //        schema.Title = ObjectType.Name;
        //        schema.Type = JsonSchemaType.Object;
        //        return schema;
        //    }
        //    catch (System.Exception)
        //    {
        //        throw;
        //    }
        //}
        //public static bool ValidateParams(JObject CP, System.Type ObjectType)
        //{
        //    try
        //    {
        //        JsonSchema schema = GetSchema(ObjectType);
        //        return CP.IsValid(schema);
        //    }
        //    catch (System.Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
