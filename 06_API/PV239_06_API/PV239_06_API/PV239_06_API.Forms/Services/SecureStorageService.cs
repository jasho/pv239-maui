using System.Threading.Tasks;
using PV239_06_API.Core.Services.Interfaces;

namespace PV239_06_API.Forms.Services
{
    public class SecureStorageService : ISecureStorageService
    {
        private readonly IJsonConverterService jsonConverterService;

        public SecureStorageService(IJsonConverterService jsonConverterService)
        {
            this.jsonConverterService = jsonConverterService;
        }

        public async Task<T> GetAsync<T>()
            where T : class, new()
        {
            return await GetAsync<T>(typeof(T).Name);
        }

        public async Task<T> GetAsync<T>(string key)
            where T : class, new()
        {
            var json = await GetAsync(key);
            return !string.IsNullOrEmpty(json)
                ? jsonConverterService.DeserializeObject<T>(json)
                : new T();
        }

        public async Task<string> GetAsync(string key)
        {
            return await Xamarin.Essentials.SecureStorage.GetAsync(key);
        }

        public async Task SetAsync<T>(T value)
        {
            await SetAsync(typeof(T).Name, value);
        }

        public async Task SetAsync<T>(string key, T value)
        {
            var json = jsonConverterService.SerializeObject(value);
            await SetAsync(key, json);
        }

        public async Task SetAsync(string key, string value)
        {
            await Xamarin.Essentials.SecureStorage.SetAsync(key, value);
        }

        public bool Remove(string key)
        {
            return Xamarin.Essentials.SecureStorage.Remove(key);
        }

        public void RemoveAll()
        {
            Xamarin.Essentials.SecureStorage.RemoveAll();
        }
    }
}
