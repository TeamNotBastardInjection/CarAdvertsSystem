using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(30)]
        public string Name { get; set; }

        public ICollection<Advert> Adverts
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