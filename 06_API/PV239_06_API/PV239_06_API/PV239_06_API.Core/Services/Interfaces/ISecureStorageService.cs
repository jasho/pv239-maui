using System.Threading.Tasks;

namespace PV239_06_API.Core.Services.Interfaces
{
    public interface ISecureStorageService : ISingletonService
    {
        Task<T> GetAsync<T>()
            where T : class, new();
        Task<T> GetAsync<T>(string key)
            where T : class, new();
        Task<string> GetAsync(string key);
        Task SetAsync(string key, string value);
        bool Remove(string key);
        void RemoveAll();

        Task SetAsync<T>(T value);
        Task SetAsync<T>(string key, T value);
    }
}