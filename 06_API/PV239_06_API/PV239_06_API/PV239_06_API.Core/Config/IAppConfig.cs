using Newtonsoft.Json;

namespace PV239_06_API.Core.Config
{
    public interface IAppConfig : IConfig
    {
        JsonSerializerSettings JsonSerializerSettings { get; }
        string DatabasePath { get; }
    }
}