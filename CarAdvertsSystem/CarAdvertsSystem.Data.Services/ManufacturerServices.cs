using Bytes2you.Validation;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using System.Linq;
using CarAdvertsSystem.Data.Services.Contracts;

namespace CarAdvertsSystem.Data.Services
{
    public class ManufacturerServices : IManufacturerServices
    {
        private readonly IRepository<Manufacturer> manufacturerRepository;
        private readonly IUnitOfWork unitOfWork;

        public ManufacturerServices(IRepository<Manufacturer> manufacturerRepository,
            IUnitOfWork unitOfWork)
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

        /// <summary>
        /// Get models by this id.
        /// Get manufacturersId by this models.
        /// Get manufacturers by this ids.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns IQeryable<Manufacturer>.</returns>
        //public IQueryable<Manufacturer> GetManufacturersByCategoryId(int id)
        //{
        //    var manufacturers = vehicleModelRepository.All()
        //                            .Where(vm => vm.CategoryId == id)
        //                            .Select(vm => this.GetById(vm.ManufacturerId));

        //    return manufacturers;
        //}

    }
}
