using System;
using WindowsFormsApplication1кп20.Utils;

namespace WindowsFormsApplication1кп20.Presenters
{
    public class PresenterBase :IDisposable
    {

        public ISecurityManager SecurityManager { get; set; }

        public PresenterBase(ISecurityManager securityManager)
        {
            SecurityManager = securityManager;
        }

        public void Dispose()
        {
            OnDispose();
        }

        protected virtual void OnDispose()
        {
            //
        }
    }
}
