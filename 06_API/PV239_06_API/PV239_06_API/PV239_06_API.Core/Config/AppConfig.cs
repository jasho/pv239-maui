using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PV239_06_API.Core.Config
{
    public class AppConfig : IAppConfig
    {
        public JsonSerializerSettings JsonSerializerSettings { get; }
        public string DatabasePath { get; }

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

            DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3");
        }
    }
}