using Newtonsoft.Json;

namespace PV239_05_Storage.Core.Config
{
    public interface IAppConfig : IConfig
    {
        JsonSerializerSettings JsonSerializerSettings { get; }
        string DatabasePath { get; }
    }
}