using System.Linq;
using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.Data.Services.Contracts
{
    public interface IAdvertServices
    {
        void AddAdvert(Advert advertToAdd);
        int Count();
        void DeleteAdvert(Advert advertToDelete);
        void DeleteAdvertById(object advertId);
        IQueryable<Advert> GetAllAdverts();
        Advert GetById(int id);

        void UpdateAdvert(Advert advert);

        IQueryable<Advert> GetAdvertsByMultipleParameters(int vehicleModelId, int cityId, int minPrice, int maxPrice,
            int yearFrom, int yearTo);
    }
}