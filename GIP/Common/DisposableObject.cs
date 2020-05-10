using System;

namespace GIP.Common
{
    public class DisposableObject : IDisposable
    {
        ~DisposableObject()
        {
            Dispose(false);
            return;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            return;
        }

        protected virtual void Dispose(bool aDisposing)
        {
            return;
        }
    }
}
