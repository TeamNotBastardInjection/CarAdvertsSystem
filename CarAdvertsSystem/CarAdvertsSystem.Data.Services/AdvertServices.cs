using System.Linq;
using Bytes2you.Validation;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;

namespace CarAdvertsSystem.Data.Services
{
    public class AdvertServices : IAdvertServices
    {
        private readonly IRepository<Advert> advertRepository;
        private readonly IUnitOfWork unitOfWork;

        public AdvertServices(IRepository<Advert> advertRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(advertRepository, "Advert Repository is Null!!!").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of Work is Null!!!").IsNull().Throw();

            this.advertRepository = advertRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddAdvert(Advert advertToAdd)
        {
            Guard.WhenArgument(advertToAdd, "Advert to Add is Null!!!").IsNull().Throw();

            using (var unitOfWork = this.unitOfWork)
            {
                this.advertRepository.Add(advertToAdd);

                unitOfWork.SaveChanges();
            }
        }

        public void DeleteAdvert(Advert advertToDelete)
        {
            Guard.WhenArgument(advertToDelete, "Advert To Delete is Null!!!!").IsNull().Throw();

            using (var unitOfWork = this.unitOfWork)
            {
                this.advertRepository.Delete(advertToDelete);

                unitOfWork.SaveChanges();
            }
        }

        public void DeleteAdvertById(object advertId)
        {
            Guard.WhenArgument(advertId, "The Id of the Advert cannot be Null!!!").IsNull().Throw();

            using (var unitOfWork = this.unitOfWork)
            {
                this.advertRepository.Delete((int)advertId);

                unitOfWork.SaveChanges();
            }
        }

        public int Count()
        {
            return this.advertRepository.All().Count();
        }

        public IQueryable<Advert> GetAllAdverts()
        {
            return this.advertRepository.All();
        }

        public Advert GetById(int id)
        {
            return this.advertRepository.GetById(id);
        }

        public IQueryable<Advert> GetAdvertsByMultipleParameters(int vehicleModelId, int cityId, int minPrice, int maxPrice, int yearFrom, int yearTo)
        {
            var adverts = this.advertRepository
                                            .All()
                                            .Where(a => a.VehicleModelId == vehicleModelId &&
                                                        a.CityId == cityId &&
                                                        a.Price >= minPrice &&
                                                        a.Price <= maxPrice &&
                                                        a.Year >= yearFrom &&
                                                        a.Year <= yearTo);
            
            return adverts;
        }

        public void UpdateAdvert(Advert advert)
        {
            using (var unitOfWork = this.unitOfWork)
            {
                this.advertRepository.Update(advert);

                unitOfWork.SaveChanges();
            }
        }

        public IQueryable<Advert> GetAllAdvertsByUserId(string userId)
        {
            var adverts = this.advertRepository
                .All()
                .Where(a => a.UserId == userId);

            return adverts;
        }
    }
}
