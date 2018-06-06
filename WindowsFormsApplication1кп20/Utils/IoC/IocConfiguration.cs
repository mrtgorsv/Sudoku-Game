using WindowsFormsApplication1кп20.Presenters;
using Ninject.Modules;

namespace WindowsFormsApplication1кп20.Utils.IoC
{
    internal class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<GamePresenter>().ToSelf().InTransientScope();
            Bind<MainPresenter>().ToSelf().InTransientScope();
            Bind<ResultPresenter>().ToSelf().InTransientScope();
            Bind<RulesPresenter>().ToSelf().InTransientScope();

            Bind<ISecurityManager>().To<SecurityManager>().InSingletonScope();
            Bind<PresenterLocator>().To<PresenterLocator>().InSingletonScope();
        }
    }
}