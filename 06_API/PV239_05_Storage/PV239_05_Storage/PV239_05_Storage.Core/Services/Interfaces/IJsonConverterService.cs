namespace PV239_05_Storage.Core.Services.Interfaces
{
    public interface IJsonConverterService : ISingletonService
    {
        string SerializeObject(object value);
        T DeserializeObject<T>(string json);
    }
}