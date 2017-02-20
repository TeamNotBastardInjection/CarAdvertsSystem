using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarAdvertsSystem.Common.Constants;
using CarAdvertsSystem.Data.Models.Contracts;
using System.Collections.Generic;

namespace CarAdvertsSystem.Data.Models
{
    public class Advert : IAdvert
    {
        private ICollection<Picture> pictures;

        public Advert()
        {
            this.pictures = new HashSet<Picture>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.AdvertTitleMinLength)]
        [MaxLength(ValidationConstants.AdvertTitleMaxLength)]
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public int VehicleModelId { get; set; }

        [ForeignKey("VehicleModelId")]
        public virtual VehicleModel VehicleModel { get; set; }
        
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        
        public int Year { get; set; }

        public decimal Price { get; set; }

        public int Power { get; set; }

        public int EngineVolume { get; set; }

        public int DistanceCoverage { get; set; }
        
        public int CityId { get; set; }
        
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [MinLength(ValidationConstants.AdvertDescriptionMinLength)]
        [MaxLength(ValidationConstants.AdvertDescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<Picture> Pictures
        {
            get
            {
                return this.pictures;
            }

            set
            {
                this.pictures = value;
            }
        }
    }
}
