using CarAdvertsSystem.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarAdvertsSystem.Data.Models.Contracts;

namespace CarAdvertsSystem.Data.Models
{
    public class Advert : IAdvert
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public int VethicleModelId { get; set; }

        [ForeignKey("VethicleModelId")]
        public virtual VethicleModel VethicleModel { get; set; }
        
        public int UserlId { get; set; }

        [ForeignKey("UserlId")]
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

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
