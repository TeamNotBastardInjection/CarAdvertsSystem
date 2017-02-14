using Bytes2you.Validation;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using System.Linq;

namespace CarAdvertsSystem.Data.Services
{
    public class ManufacturerServices
    {
        private readonly IRepository<Manufacturer> manufacturerRepository;
        private readonly IUnitOfWork unitOfWork;

        public ManufacturerServices(IRepository<Manufacturer> manufacturerRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(manufacturerRepository, "Manufacturer Repository is Null!!!").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of Work is Null!!!").IsNull().Throw();

            this.manufacturerRepository = manufacturerRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all manufacturers.
        /// </summary>
        public IQueryable<Manufacturer> GetAllManufacturers()
        {
            return this.manufacturerRepository.All();
        }

        /// <summary>
        /// Get manufacturer by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns manufacturer.</returns>
        public Manufacturer GetById(int id)
        {
            return this.manufacturerRepository.GetById(id);
        }

        ///// <summary>
        ///// Creates new manufacturer by name.
        ///// </summary>
        ///// <param name="name"></param>
        //public void Create(string name)
        //{
        //    Guard.WhenArgument(name.ToString(), "Manufacturer to Add is Null!!!").IsNull().Throw();

        //    using (var unitOfWork = this.unitOfWork)
        //    {
        //        var model = new Manufacturer() { Name = name };

        //        this.manufacturerRepository.Add(model);

        //        unitOfWork.SaveChanges();
        //    }
        //}

        ///// <summary>
        ///// Update manufacturer name by Id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="name"></param>
        //public void UpdateManufacturerNameById(int id, string name)
        //{
        //    Guard.WhenArgument(name.ToString(), "Manufacturer to Add is Null!!!").IsNull().Throw();

        //    using (var unitOfWork = this.unitOfWork)
        //    {
        //        this.manufacturerRepository.GetById(id).Name = name;

        //        unitOfWork.SaveChanges();
        //    }
        //}

        ///// <summary>
        ///// Delete manufacturer by Id
        ///// </summary>
        ///// <param name="id"></param>
        //public void DeleteById(int id)
        //{
        //    Guard.WhenArgument(id.ToString(), "The Id of the manufacturer cannot be Null!!!").IsNull().Throw();

        //    using (var unitOfWork = this.unitOfWork)
        //    {
        //        this.manufacturerRepository.Delete(id);

        //        this.unitOfWork.SaveChanges();
        //    }
        //}
    }
}
