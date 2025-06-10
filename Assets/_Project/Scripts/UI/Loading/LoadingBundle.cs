using System.Collections.Generic;

namespace Gameplay
{
    public class LoadingBundle
    {
        private readonly Dictionary<string, object> _values = new();

        public void Add(string key, object value) => _values.Add(key, value);

        public T Get<T>(string key)
        {
            return _values.TryGetValue(key, out var value) ? (T)value : default;
        }

        public bool TryGet<T>(string key, out T value)
        {
            if (_values.TryGetValue(key, out var result))
            {
                value = (T)result;
                return true;
            }

            value = default;
            return false;
        }
    }

    public static class LoadinBundleKeys
    {
        public const string L_Base = nameof(L_Base);
        public const string L_Lobby = nameof(L_Lobby);
    }
}