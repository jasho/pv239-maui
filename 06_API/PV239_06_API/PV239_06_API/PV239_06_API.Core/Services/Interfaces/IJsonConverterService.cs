namespace PV239_06_API.Core.Services.Interfaces
{
    public interface IJsonConverterService : ISingletonService
    {
        string SerializeObject(object value);
        T DeserializeObject<T>(string json);
    }
}