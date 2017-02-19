using System;

namespace CarAdvertsSystem.MVP.AdvertDetail
{
    public class GetPicturesEventArgs : EventArgs
    {
        public int AdvertId { get; private set; }

        public GetPicturesEventArgs(int advertId)
        {
            this.AdvertId = advertId;
        }
    }
}
