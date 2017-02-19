using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertsSystem.MVP.AdvertDetail
{
    public class GetAdvertsByIdEventArgs : EventArgs
    {
        public int AdvertId { get; private set; }

        public GetAdvertsByIdEventArgs(int advertId)
        {
            this.AdvertId = advertId;
        }
    }
}
