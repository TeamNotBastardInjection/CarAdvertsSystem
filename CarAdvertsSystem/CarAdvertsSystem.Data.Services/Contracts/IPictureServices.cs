using System.Collections.Generic;
using System.Linq;
using CarAdvertsSystem.Data.Models;

namespace CarAdvertsSystem.Data.Services.Contracts
{
    public interface IPictureServices
    {
        IQueryable<Picture> GetPicturesByAdvertId(int advertId);

        string GetFirstPicturesNameByAdvertId(int advertId);
    }
}
