using CookBook.Mobile.Core.Services;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CookBook.Mobile.Services
{
    public class SecureStorageService : ISecureStorageService
    {
        public async Task<string?> GetAsync(string key)
        {
            var value = await SecureStorage.GetAsync(key);
            return value is null or ""
                ? null
                : value;
        }

        public async Task SetAsync(string key, string value)
        {
            await SecureStorage.SetAsync(key, value);
        }

        public bool Remove(string key)
        {
            return SecureStorage.Remove(key);
        }

        public void RemoveAll()
        {
            SecureStorage.RemoveAll();
        }

        public async Task<bool> ExistsAsync(string key)
        {
            return (await GetAsync(key)) is not null;
        }
    }
}