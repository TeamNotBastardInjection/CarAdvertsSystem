using Bytes2you.Validation;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using System.Linq;

namespace CarAdvertsSystem.Data.Services
{
    public class CityServices : ICityServices
    {
        private readonly IRepository<City> cityRepository;

        public CityServices(IRepository<City> cityRepository)
        {
            Guard.WhenArgument(cityRepository, "City Repository is Null!!!").IsNull().Throw();

            this.cityRepository = cityRepository;
        }

        /// <summary>
        /// Get all cities.
        /// </summary>
        public IQueryable<City> GetAllCities()
        {
            return this.cityRepository.All();
        }

        /// <summary>
        /// Get city by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns city.</returns>
        public City GetById(int id)
        {
            return this.cityRepository.GetById(id);
        }

    }
}
