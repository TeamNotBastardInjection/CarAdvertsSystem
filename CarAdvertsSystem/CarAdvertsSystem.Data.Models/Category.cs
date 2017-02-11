using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CarAdvertsSystem.Data.Models.Contracts;

namespace CarAdvertsSystem.Data.Models
{
    public class Category : ICategory
    {
        private ICollection<Manufacturer> manufacturers;

        public Category()
        {
            this.manufacturers = new HashSet<Manufacturer>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        public CategoryType Name { get; set; }

        public ICollection<Manufacturer> Manufacturers
        {
            get
            {
                return this.manufacturers;
            }

            set
            {
                this.manufacturers = value;
            }
        }
    }
}
