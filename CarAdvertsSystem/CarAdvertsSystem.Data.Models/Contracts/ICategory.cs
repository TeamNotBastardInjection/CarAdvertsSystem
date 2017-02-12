using System.Collections.Generic;

namespace CarAdvertsSystem.Data.Models.Contracts
{
    public interface ICategory
    {
        int Id { get; set; }
        ICollection<VethicleModel> VethicleModels { get; set; }
        CategoryType Name { get; set; }
    }
}