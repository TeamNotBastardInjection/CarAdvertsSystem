using CarAdvertsSystem.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarAdvertsSystem.Common.Constants;
using CarAdvertsSystem.Data.Models.Contracts;

namespace CarAdvertsSystem.Data.Models
{
    public class Advert : IAdvert
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.AdvertTitleMinLength)]
        [MaxLength(ValidationConstants.AdvertTitleMaxLength)]
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public int VehicleModelId { get; set; }

        [ForeignKey("VehicleModelId")]
        public virtual VechicleModel VechicleModel { get; set; }
        
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        // Extras
        [Required]
        public int Power { get; set; }

        [Required]
        public int EngineVolume { get; set; }

        [Required]
        public EngineType EngineType { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        [Required]
        public int DistanceCoverage { get; set; }

        [Required]
        public ColorType Color { get; set; }

        public int CityId { get; set; }
        
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [MinLength(ValidationConstants.AdvertDescriptionMinLength)]
        [MaxLength(ValidationConstants.AdvertDescriptionMaxLength)]
        public string Description { get; set; }
    }
}
