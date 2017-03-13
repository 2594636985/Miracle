using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.Modularization.Aspects.Caching
{
    public sealed class AnonymousDisposable : IDisposable
    {
        private readonly Action<bool> _dispose;
        private bool _disposed;
     
        public AnonymousDisposable(Action<bool> dispose)
        {
            if (dispose == null)
                throw new ArgumentNullException("dispose");

            _dispose = dispose;

            _disposed = false;
        }

     
        ~AnonymousDisposable()
        {
            Dispose(false);
        }

       
        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            _dispose(disposing);

            _disposed = true;
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
