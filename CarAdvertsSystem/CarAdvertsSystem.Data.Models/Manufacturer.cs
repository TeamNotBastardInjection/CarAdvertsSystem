using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CarAdvertsSystem.Data.Models.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAdvertsSystem.Data.Models
{
    public class Manufacturer : IManufacturer
    {
        private ICollection<VethicleModel> models;

        public Manufacturer()
        {
            this.models = new HashSet<VethicleModel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(20)]
        public string Name { get; set; }
        
        public virtual ICollection<VethicleModel> Models
        {
            get
            {
                return this.models;
            }

            set
            {
                this.models = value;
            }
        }
    }
}
