using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CarAdvertsSystem.Common.Constants;
using CarAdvertsSystem.Data.Models.Contracts;

namespace CarAdvertsSystem.Data.Models
{
    public class City : ICity
    {
        private ICollection<Advert> adverts;

        public City()
        {
            this.adverts = new HashSet<Advert>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.CityNameMinLength)]
        [MaxLength(ValidationConstants.CityNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Advert> Adverts
        {
            get
            {
                return this.adverts;
            }

            set
            {
                this.adverts = value;
            }
        }
    }
}