using System.Linq;
using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.Data.Services.Contracts
{
    public interface ICityServices
    {
        IQueryable<City> GetAllCities();
        City GetById(int id);
    }
}