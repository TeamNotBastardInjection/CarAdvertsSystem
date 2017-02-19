using System.Linq;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;

using Bytes2you.Validation;

namespace CarAdvertsSystem.Data.Services
{
    public class VehicleModelServices : IVehicleModelServices
    {
        private readonly IRepository<VehicleModel> vechicleModelRepository;

        public VehicleModelServices(IRepository<VehicleModel> vechicleModelRepository)
        {
            Guard.WhenArgument(vechicleModelRepository, "VehicleModel Repository is Null!!!").IsNull().Throw();

            this.vechicleModelRepository = vechicleModelRepository;
        }

        /// <summary>
        /// Get all vechicle models.
        /// </summary>
        public IQueryable<VehicleModel> GetAllVehicleModels()
        {
            return this.vechicleModelRepository.All();
        }

        /// <summary>
        /// Get vechicle model by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns vechicle model.</returns>
        public VehicleModel GetById(int id)
        {
            return this.vechicleModelRepository.GetById(id);
        }
    }
}
