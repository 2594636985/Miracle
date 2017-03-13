using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Aspects.Caching
{
    public sealed class Cache<TKey, TValue> : ICache<TKey, TValue>
    {

        private readonly Dictionary<TKey, TValue> _values;

        public Cache()
        {
            _values = new Dictionary<TKey, TValue>();
        }

        public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
        {
            TValue value;

            if (_values.TryGetValue(key, out value))
                return value;

            value = valueFactory(key);
            _values.Add(key, value);

            return value;
        }

    }
}
