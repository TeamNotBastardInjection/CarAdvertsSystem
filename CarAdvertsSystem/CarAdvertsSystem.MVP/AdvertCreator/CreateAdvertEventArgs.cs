using System;

namespace CarAdvertsSystem.MVP.AdvertCreator
{
    public class CreateAdvertEventArgs : EventArgs
    {
        public string Title { get; private set; }

        public string UserId { get; private set; }
        public int CityId { get; private set; }
        public int VehicleModelId { get; private set; }
        public int Price { get; private set; }
        public int Power { get; private set; }
        public int DistanceCovarage { get; private set; }
        public string Description { get; private set; }
        public int Year { get; private set; }

        public CreateAdvertEventArgs(
            string title,
            string userId,
            int cityId,
            int vehicleModelId,
            int price,
            int power,
            int distanceCovarage,
            string description,
            int year)
        {
            this.Title = title;
            this.UserId = userId;
            this.CityId = cityId;
            this.VehicleModelId = vehicleModelId;
            this.Price = price;
            this.Power = power;
            this.DistanceCovarage = distanceCovarage;
            this.Description = description;
            this.Year = year;
        }
    }
}
