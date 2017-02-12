using System.Collections.Generic;

namespace CarAdvertsSystem.Data.Models.Contracts
{
    public interface IManufacturer
    {
        int Id { get; set; }
        ICollection<VechicleModel> Models { get; set; }
        string Name { get; set; }
    }
}