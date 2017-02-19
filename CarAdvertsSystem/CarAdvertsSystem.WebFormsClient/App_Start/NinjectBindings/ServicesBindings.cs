using CarAdvertsSystem.Data.Services;
using CarAdvertsSystem.Data.Services.Contracts;
using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace CarAdvertsSystem.WebFormsClient.App_Start.NinjectBindings
{
    public class ServicesBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x => x.From("CarAdvertsSystem.Data.Services").SelectAllClasses().BindDefaultInterfaces());
        }
    }
}