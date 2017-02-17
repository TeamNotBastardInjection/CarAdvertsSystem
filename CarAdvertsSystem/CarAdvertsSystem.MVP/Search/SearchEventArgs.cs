using System;

namespace CarAdvertsSystem.MVP.Search
{
    public class SearchEventArgs : EventArgs
    {
        public int CityId { get; private set; }

        public int MinPrice { get; private set; }

        public int MaxPrice { get; private set; }

        public int YearFrom { get; private set; }

        public int YearTo { get; private set; }

        public int VehcicleModelId { get; private set; }

        //public int CategoryId { get; private set; }

        public SearchEventArgs(int cityId, int minPrice, int maxPrice, int yearFrom, int yearTo, int vehcicleModelId)
        {
            this.CityId = cityId;
            this.MinPrice = minPrice;
            this.MaxPrice = maxPrice;
            this.YearFrom = yearFrom;
            this.YearTo = yearTo;
            this.VehcicleModelId = vehcicleModelId;
        }
    }
}