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

                this.unitOfWork.SaveChanges();
            }
        }

        public void DeleteAdvertById(object advertId)
        {
            Guard.WhenArgument(advertId, "The Id of the Advert cannot be Null!!!").IsNull().Throw();

            using (var unitOfWork = this.unitOfWork)
            {
                this.advertRepository.Delete((int)advertId);

                this.unitOfWork.SaveChanges();
            }
        }

        public Advert GetByTitle(string title)
        {
            return this.advertRepository.GetByTitle(title);
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
    }
}
