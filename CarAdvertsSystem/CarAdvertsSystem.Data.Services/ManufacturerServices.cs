using System.Linq;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;

using Bytes2you.Validation;

namespace CarAdvertsSystem.Data.Services
{
    public class ManufacturerServices : IManufacturerServices
    {
        private readonly IRepository<Manufacturer> manufacturerRepository;

        public ManufacturerServices(IRepository<Manufacturer> manufacturerRepository)
        {
            Guard.WhenArgument(manufacturerRepository, "Manufacturer Repository is Null!!!").IsNull().Throw();

            this.manufacturerRepository = manufacturerRepository;
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
    }
}
