using CarAdvertsSystem.Data.Contracts;

using Bytes2you.Validation;


namespace CarAdvertsSystem.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICarAdvertsSystemDbContext context;

        public UnitOfWork(ICarAdvertsSystemDbContext context)
        {
            Guard.WhenArgument(context, "Db context is null!").IsNull().Throw();

            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
