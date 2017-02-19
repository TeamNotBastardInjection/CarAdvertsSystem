using System.Collections.Generic;

namespace CarAdvertsSystem.Data.Services.Contracts
{
    public interface IPictureServices
    {
        ICollection<string> GetAllPictureNamesByAdvertId(int advertId);

        string GetFirstPicturesNameByAdvertId(int advertId);
    }
}
