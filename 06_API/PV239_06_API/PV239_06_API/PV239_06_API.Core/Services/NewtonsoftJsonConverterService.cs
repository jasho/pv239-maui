using Newtonsoft.Json;
using PV239_06_API.Core.Config;
using PV239_06_API.Core.Services.Interfaces;

namespace PV239_06_API.Core.Services
{
    public class NewtonsoftJsonConverterService : IJsonConverterService
    {
        private readonly IAppConfig appConfig;

        public NewtonsoftJsonConverterService(IAppConfig appConfig)
        {
            this.appConfig = appConfig;
        }

        public string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value, appConfig.JsonSerializerSettings);
        }

        public T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, appConfig.JsonSerializerSettings);
        }
    }
}