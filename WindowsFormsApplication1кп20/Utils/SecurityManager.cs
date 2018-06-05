namespace WindowsFormsApplication1кп20.Utils
{
    public interface ISecurityManager
    {
        string CurrentUser { get; set; }
    }

    public class SecurityManager : ISecurityManager
    {
        public string CurrentUser { get; set; }
    }
}