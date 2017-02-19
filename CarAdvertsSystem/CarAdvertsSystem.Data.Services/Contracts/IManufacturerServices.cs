using System.Linq;
using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.Data.Services.Contracts
{
    public interface IManufacturerServices
    {
        IQueryable<Manufacturer> GetAllManufacturers();
        Manufacturer GetById(int id);
        //IQueryable<Manufacturer> GetManufacturersByCategoryId(int id);
    }
}