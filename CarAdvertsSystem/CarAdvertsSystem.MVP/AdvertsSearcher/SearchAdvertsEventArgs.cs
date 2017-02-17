using System;
using System.Data.Entity.Core.Mapping;

namespace CarAdvertsSystem.MVP.AdvertsSearcher
{
    public class SearchAdvertsEventArgs : EventArgs
    {
        public int CityId { get; private set; }

        public int MinPrice { get; private set; }

        public int MaxPrice { get; private set; }

        public int YearFrom { get; private set; }

        public int YearTo { get; private set; }

        public int VehcicleModelId { get; private set; }
    }
}