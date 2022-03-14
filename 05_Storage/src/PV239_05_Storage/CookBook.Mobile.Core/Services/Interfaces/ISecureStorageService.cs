using System.Threading.Tasks;

namespace CookBook.Mobile.Core.Services
{
    public interface ISecureStorageService
    {
        Task<string?> GetAsync(string key);
        Task SetAsync(string key, string value);

        bool Remove(string key);
        void RemoveAll();

        Task<bool> ExistsAsync(string key);
    }
}