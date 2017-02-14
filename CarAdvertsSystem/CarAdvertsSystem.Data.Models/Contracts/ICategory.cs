using System.Collections.Generic;

namespace CarAdvertsSystem.Data.Models.Contracts
{
    public interface ICategory
    {
        int Id { get; set; }
        ICollection<VehicleModel> VethicleModels { get; set; }
        string Name { get; set; }
    }
}