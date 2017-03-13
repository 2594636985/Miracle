using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Aspects.Caching
{
    public sealed class LockOnWriteCache<TKey, TValue> : ICache<TKey, TValue>, IDisposable
    {
        private readonly Dictionary<TKey, TValue> _values;
        private readonly ReadWriteLock _lock;
        private bool _disposed;

        public LockOnWriteCache()
        {
            _values = new Dictionary<TKey, TValue>();
            _lock = new ReadWriteLock();

            _disposed = false;
        }

        ~LockOnWriteCache()
        {
            Dispose(false);
        }

       
        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _lock.Dispose();

            _disposed = true;
        }

        #region ICache<TKey, TValue> Members

        public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
        {
            TValue value;

            using (_lock.UpgradeableRead())
            {
                if (_values.TryGetValue(key, out value))
                    return value;

                using (_lock.Write())
                {
                    if (_values.TryGetValue(key, out value))
                        return value;

                    value = valueFactory(key);
                    _values.Add(key, value);
                }
            }

            return value;
        }

        #endregion


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
