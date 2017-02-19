using System;
using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;

namespace CarAdvertsSystem.Data.Services
{
    public class PictureServices : IPictureServices
    {
        private readonly IRepository<Picture> pictureRepository;

        public PictureServices(IRepository<Picture> pictureRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(pictureRepository, "Picture Repository is Null!!!").IsNull().Throw();

            this.pictureRepository = pictureRepository;
        }

        public ICollection<string> GetAllPictureNamesByAdvertId(int advertId)
        {
            var picturesPaths = this.pictureRepository.All().Where(p => p.AdvertId == advertId).Select(p => p.Name).ToList();

            return picturesPaths;
        }

        public string GetFirstPicturesNameByAdvertId(int advertId)
        {
            var picturePath = this.pictureRepository.All()
                .FirstOrDefault(p => p.AdvertId == advertId)?.Name;



            return picturePath;
        }
    }
}
