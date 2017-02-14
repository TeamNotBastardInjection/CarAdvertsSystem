using System.Linq;
using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.Data.Services.Contracts
{
    public interface IVehicleModelServices
    {
        IQueryable<VehicleModel> GetAllVehicleModels();
        VehicleModel GetById(int id);
    }
}