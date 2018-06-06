using WindowsFormsApplication1кп20.Presenters;

namespace WindowsFormsApplication1кп20.Utils.IoC
{
    public class PresenterLocator
    {
        public MainPresenter MainPresenter => IocKernel.Get<MainPresenter>();
        public GamePresenter GamePresenter => IocKernel.Get<GamePresenter>();
        public ResultPresenter ResultPresenter => IocKernel.Get<ResultPresenter>();
        public RulesPresenter RulesPresenter => IocKernel.Get<RulesPresenter>();
    }
}