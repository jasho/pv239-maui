using System;

namespace PV239_06_API.Core.Services.Interfaces
{
    public interface IPreferencesService : ISingletonService
    {
        bool ContainsType<T>();
        bool ContainsKey(string key);
        bool ContainsKey(string key, string sharedName);

        T Get<T>()
            where T : new();
        T Get<T>(string key)
            where T : new();
        string Get(string key, string defaultValue);
        string Get(string key, string defaultValue, string sharedName);
        bool Get(string key, bool defaultValue);
        bool Get(string key, bool defaultValue, string sharedName);
        int Get(string key, int defaultValue);
        int Get(string key, int defaultValue, string sharedName);
        long Get(string key, long defaultValue);
        long Get(string key, long defaultValue, string sharedName);
        float Get(string key, float defaultValue);
        float Get(string key, float defaultValue, string sharedName);
        double Get(string key, double defaultValue);
        double Get(string key, double defaultValue, string sharedName);
        DateTime Get(string key, DateTime defaultValue);
        DateTime Get(string key, DateTime defaultValue, string sharedName);

        void Set<T>(T value);
        void Set<T>(string key, T value);
        void Set(string key, string value);
        void Set(string key, string value, string sharedName);
        void Set(string key, bool value);
        void Set(string key, bool value, string sharedName);
        void Set(string key, int value);
        void Set(string key, int value, string sharedName);
        void Set(string key, long value);
        void Set(string key, long value, string sharedName);
        void Set(string key, float value);
        void Set(string key, float value, string sharedName);
        void Set(string key, double value);
        void Set(string key, double value, string sharedName);
        void Set(string key, DateTime value);
        void Set(string key, DateTime value, string sharedName);

        void Remove(string key);
        void Remove(string key, string sharedName);

        void Clear();
        void Clear(string sharedName);
    }
}