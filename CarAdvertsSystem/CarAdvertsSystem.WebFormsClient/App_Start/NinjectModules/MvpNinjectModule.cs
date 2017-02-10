using System;
using System.Linq;
using CarAdvertsSystem.WebFormsClient.App_Start.Factories;
using CarAdvertsSystem.WebFormsClient.App_Start.Factories.Contracts;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;
using Ninject.Parameters;
using WebFormsMvp;
using WebFormsMvp.Binder;
using Ninject.Extensions.Factory;

namespace CarAdvertsSystem.WebFormsClient.App_Start.NinjectModules
{
    public class MvpNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();

            this.Bind<ICustomPresenterFactory>().ToFactory().InSingletonScope();

            this.Bind<IPresenter>()
                .ToMethod(this.GetPresenter)
                .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null));
        }

        private IPresenter GetPresenter(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = (Type) parameters[0].GetValue(context, null);
            var viewInstance = (IView) parameters[1].GetValue(context, null);

            var ctorParameter = new ConstructorArgument("view", viewInstance);

            return (IPresenter) context.Kernel.Get(presenterType, ctorParameter);
        }
    }
}