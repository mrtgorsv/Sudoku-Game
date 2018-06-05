using WindowsFormsApplication1кп20.Utils;

namespace WindowsFormsApplication1кп20.Presenters
{
    public class PresenterBase
    {

        public ISecurityManager SecurityManager { get; set; }

        public PresenterBase(ISecurityManager securityManager)
        {
            SecurityManager = securityManager;
        }
    }
}
