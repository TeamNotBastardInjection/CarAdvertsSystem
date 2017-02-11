using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Repositories;
using CarAdvertsSystem.Data.UnitOfWork;
using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace CarAdvertsSystem.WebFormsClient.App_Start.NinjectBindings
{
    public class DataBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x => x.From("CarAdvertsSystem.Data.Models").SelectAllClasses().BindDefaultInterfaces());
            this.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
            this.Bind<ICarAdvertsSystemDbContext>().To<ICarAdvertsSystemDbContext>().InSingletonScope();
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}