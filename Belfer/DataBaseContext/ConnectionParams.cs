using Newtonsoft.Json;
using DataBaseService;

namespace Belfer.DataBaseContext 
{
    public class ConnectionParams : IConnectionParameters
	{
		[JsonProperty(Required = Required.Always)]
		public string ServerAddress { get; set; }

		[JsonProperty(Required = Required.Always)]
		public string DBName { get; set; }

		[JsonProperty(Required = Required.Always)]
		public string UserName { get; set; }

		[JsonProperty(Required = Required.Always)]
		public string Password { get; set; }

		[JsonProperty(Required = Required.Always)]
		public int SSLMode { get; set; } = 0;
        
		[JsonProperty(Required = Required.Always)]
		public string CharSet { get; set; } = "utf8";

		[JsonProperty(Required = Required.Always)]
		public int KeepAlive { get; set; } = 60;

        [JsonProperty(Required = Required.Always)]
        public uint ServerPort { get; set; } = 3306;
	}

}
