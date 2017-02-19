using System;

namespace CarAdvertsSystem.MVP.Search
{
    public class GetPicturePathEventArgs : EventArgs
    {
        public int AdvertId { get; private set; }

        public GetPicturePathEventArgs(int advertId)
        {
            this.AdvertId = advertId;
        }
    }
}
