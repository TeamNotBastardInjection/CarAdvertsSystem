using Bytes2you.Validation;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using System.Linq;

namespace CarAdvertsSystem.Data.Services
{
    public class VehicleModelServices
    {
        private readonly IRepository<VehicleModel> vechicleModelRepository;
        private readonly IUnitOfWork unitOfWork;

        public VehicleModelServices(IRepository<VehicleModel> vechicleModelRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(vechicleModelRepository, "VehicleModel Repository is Null!!!").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of Work is Null!!!").IsNull().Throw();

            this.vechicleModelRepository = vechicleModelRepository;
            this.unitOfWork = unitOfWork;
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
