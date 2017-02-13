using Bytes2you.Validation;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Models.Contracts;
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

        /// <summary>
        /// Creates new vechicle model by name.
        /// </summary>
        /// <param name="name"></param>
        public void Create(string name)
        {
            Guard.WhenArgument(name.ToString(), "VehicleModel to Add is Null!!!").IsNull().Throw();

            using (var unitOfWork = this.unitOfWork)
            {
                var model = new VehicleModel() { Name = name };

                this.vechicleModelRepository.Add(model);

                unitOfWork.SaveChanges();
            }
        }

        /// <summary>
        /// Update vechicle model name by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void UpdateVehicleModelNameById(int id, string name)
        {
            Guard.WhenArgument(name.ToString(), "VehicleModel to Add is Null!!!").IsNull().Throw();

            using (var unitOfWork = this.unitOfWork)
            {
                this.vechicleModelRepository.GetById(id).Name = name;

                unitOfWork.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a Vechicle Model by Id.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            Guard.WhenArgument(id.ToString(), "The Id of the Vechicle Model cannot be Null!!!").IsNull().Throw();

            using (var unitOfWork = this.unitOfWork)
            {
                this.vechicleModelRepository.Delete(id);

                this.unitOfWork.SaveChanges();
            }
        }
    }
}
