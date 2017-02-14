using System.Linq;
using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.Data.Services.Contracts
{
    public interface ICategoryServices
    {
        IQueryable<Category> GetAllCategories();
        Category GetById(int id);
    }
}