using CookBook.Mobile.Core.Services;
using Newtonsoft.Json;
using System;
using Xamarin.Essentials;

namespace CookBook.Mobile.Services
{
    public class PreferencesService : IPreferencesService
    {
        public bool ContainsType<T>()
        {
            return ContainsKey(typeof(T).Name);
        }

        public bool ContainsKey(string key)
        {
            return Preferences.ContainsKey(key);
        }

        public bool ContainsKey(string key, string sharedName)
        {
            return Preferences.ContainsKey(key, sharedName);
        }

        public T Get<T>()
            where T : new()
        {
            return Get<T>(typeof(T).Name);
        }

        public T Get<T>(string key)
            where T : new()
        {
            var valueString = Get(key, null);

            return valueString is null
                ? new()
                : JsonConvert.DeserializeObject<T?>(valueString) ?? new();
        }

        public T? Get<T>(string key, T? defaultValue)
            where T : new()
        {
            var valueString = Get(key, null);

            return valueString is null
                ? defaultValue
                : JsonConvert.DeserializeObject<T?>(valueString);
        }

        public string? Get(string key, string? defaultValue)
        {
            return Preferences.Get(key, defaultValue);
        }

        public string? Get(string key, string? defaultValue, string sharedName)
        {
            return Preferences.Get(key, defaultValue, sharedName);
        }

        public bool Get(string key, bool defaultValue)
        {
            return Preferences.Get(key, defaultValue);
        }

        public bool Get(string key, bool defaultValue, string sharedName)
        {
            return Preferences.Get(key, defaultValue, sharedName);
        }

        public int Get(string key, int defaultValue)
        {
            return Preferences.Get(key, defaultValue);
        }

        public int Get(string key, int defaultValue, string sharedName)
        {
            return Preferences.Get(key, defaultValue, sharedName);
        }

        public long Get(string key, long defaultValue)
        {
            return Preferences.Get(key, defaultValue);
        }

        public long Get(string key, long defaultValue, string sharedName)
        {
            return Preferences.Get(key, defaultValue, sharedName);
        }

        public float Get(string key, float defaultValue)
        {
            return Preferences.Get(key, defaultValue);
        }

        public float Get(string key, float defaultValue, string sharedName)
        {
            return Preferences.Get(key, defaultValue, sharedName);
        }

        public double Get(string key, double defaultValue)
        {
            return Preferences.Get(key, defaultValue);
        }

        public double Get(string key, double defaultValue, string sharedName)
        {
            return Preferences.Get(key, defaultValue, sharedName);
        }

        public DateTime Get(string key, DateTime defaultValue)
        {
            return Preferences.Get(key, defaultValue);
        }

        public DateTime Get(string key, DateTime defaultValue, string sharedName)
        {
            return Preferences.Get(key, defaultValue, sharedName);
        }

        public void Set<T>(T value)
            where T : notnull
        {
            Set(typeof(T).Name, value);
        }

        public void Set<T>(string key, T value)
            where T : notnull
        {
            var json = JsonConvert.SerializeObject(value);
            Set(key, json);
        }

        public void Set(string key, string value)
        {
            Preferences.Set(key, value);
        }

        public void Set(string key, string value, string sharedName)
        {
            Preferences.Set(key, value, sharedName);
        }

        public void Set(string key, bool value)
        {
            Preferences.Set(key, value);
        }

        public void Set(string key, bool value, string sharedName)
        {
            Preferences.Set(key, value, sharedName);
        }

        public void Set(string key, int value)
        {
            Preferences.Set(key, value);
        }

        public void Set(string key, int value, string sharedName)
        {
            Preferences.Set(key, value, sharedName);
        }

        public void Set(string key, long value)
        {
            Preferences.Set(key, value);
        }

        public void Set(string key, long value, string sharedName)
        {
            Preferences.Set(key, value, sharedName);
        }

        public void Set(string key, float value)
        {
            Preferences.Set(key, value);
        }

        public void Set(string key, float value, string sharedName)
        {
            Preferences.Set(key, value, sharedName);
        }

        public void Set(string key, double value)
        {
            Preferences.Set(key, value);
        }

        public void Set(string key, double value, string sharedName)
        {
            Preferences.Set(key, value, sharedName);
        }

        public void Set(string key, DateTime value)
        {
            Preferences.Set(key, value);
        }

        public void Set(string key, DateTime value, string sharedName)
        {
            Preferences.Set(key, value, sharedName);
        }

        public void Remove(string key)
        {
            Preferences.Remove(key);
        }

        public void Remove(string key, string sharedName)
        {
            Preferences.Remove(key, sharedName);
        }

        public void Clear()
        {
            Preferences.Clear();
        }

        public void Clear(string sharedName)
        {
            Preferences.Clear(sharedName);
        }
    }
}