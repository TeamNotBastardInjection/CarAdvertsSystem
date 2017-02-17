using Bytes2you.Validation;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertsSystem.Data.Services
{
    public class CityServices : ICityServices
    {
        private readonly IRepository<City> cityRepository;
        private readonly IUnitOfWork unitOfWork;

        public CityServices(IRepository<City> cityRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(cityRepository, "City Repository is Null!!!").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of Work is Null!!!").IsNull().Throw();

            this.cityRepository = cityRepository;
            this.unitOfWork = unitOfWork;
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
