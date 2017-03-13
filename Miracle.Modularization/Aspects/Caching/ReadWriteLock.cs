using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Miracle.Modularization.Aspects.Caching
{
    public sealed class ReadWriteLock : IDisposable
    {
        private readonly ReaderWriterLockSlim _lock;
        private bool _disposed;
        public ReadWriteLock()
        {
            _lock = new ReaderWriterLockSlim();

            _disposed = false;
        }

     
        ~ReadWriteLock()
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

     
        public IDisposable UpgradeableRead()
        {
            _lock.EnterUpgradeableReadLock();

            return new AnonymousDisposable(_ => _lock.ExitUpgradeableReadLock());
        }

     
        public IDisposable Read()
        {
            _lock.EnterReadLock();

            return new AnonymousDisposable(_ => _lock.ExitReadLock());
        }

      
        public IDisposable Write()
        {
            _lock.EnterWriteLock();

            return new AnonymousDisposable(_ => _lock.ExitWriteLock());
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
