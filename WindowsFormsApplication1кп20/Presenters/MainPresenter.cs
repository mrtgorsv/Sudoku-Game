using WindowsFormsApplication1кп20.Utils;

namespace WindowsFormsApplication1кп20.Presenters
{
    public class MainPresenter : PresenterBase
    {
        public MainPresenter(ISecurityManager securityManager) : base(securityManager)
        {
            //
        }

        public void SetCurrentUser(string userName)
        {
            SecurityManager.CurrentUser = userName;
        }
    }
}
