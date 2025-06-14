using System.Collections.Generic;

namespace Gameplay
{
    public class LoadingBundle
    {
        private Dictionary<BundleKeys, object> _bundle = new();

        public void Add(in BundleKeys key, in object value) => _bundle[key] = value;

        public bool Remove(in BundleKeys key) => _bundle.Remove(key);

        public T Get<T>(BundleKeys key) => (T)_bundle[key];

        public bool TryGet(in BundleKeys key, out object value)
        {
            if (_bundle.TryGetValue(key, out object result))
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }
    }
}