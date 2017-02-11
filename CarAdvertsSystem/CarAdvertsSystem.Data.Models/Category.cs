using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertsSystem.Data.Models
{
    public class Category
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
