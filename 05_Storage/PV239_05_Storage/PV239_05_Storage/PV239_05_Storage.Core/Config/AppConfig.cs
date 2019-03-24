using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PV239_05_Storage.Core.Config
{
    public class AppConfig : IAppConfig
    {
        public JsonSerializerSettings JsonSerializerSettings { get; }

        public AppConfig()
        {
            JsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Converters = new List<JsonConverter>
                {
                    new StringEnumConverter (true)
                }
            };
        }
    }
}