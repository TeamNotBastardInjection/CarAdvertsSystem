using CarAdvertsSystem.Data.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAdvertsSystem.Data.Models
{
    public class Picture : IPicture
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        public int AdvertId { get; set; }

        [ForeignKey("AdvertId")]
        public virtual Advert Advert { get; set; }
    }
}
