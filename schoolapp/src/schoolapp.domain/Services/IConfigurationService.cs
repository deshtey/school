using System.Threading.Tasks;

namespace schoolapp.Domain.Services
{
    public interface IConfigurationService
    {
        Task<T> GetConfigValueAsync<T>(string key, T defaultValue = default);
        Task SetConfigValueAsync<T>(string key, T value);
        Task<bool> ConfigExistsAsync(string key);
        Task DeleteConfigAsync(string key);
        Task<Dictionary<string, object>> GetAllConfigsAsync();
    }
}