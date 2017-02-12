using System.Collections.Generic;

namespace CarAdvertsSystem.Data.Models.Contracts
{
    public interface ICategory
    {
        int Id { get; set; }
        ICollection<VechicleModel> VethicleModels { get; set; }
        CategoryType Name { get; set; }
    }
}