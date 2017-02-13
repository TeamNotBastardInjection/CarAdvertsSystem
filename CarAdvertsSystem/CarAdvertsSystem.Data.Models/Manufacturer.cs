using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CarAdvertsSystem.Data.Models.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using CarAdvertsSystem.Common.Constants;

namespace CarAdvertsSystem.Data.Models
{
    public class Manufacturer : IManufacturer
    {
        private ICollection<VehicleModel> models;

        public Manufacturer()
        {
            this.models = new HashSet<VehicleModel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.ManufacturerNameMinLength)]
        [MaxLength(ValidationConstants.ManufacturerNameMaxLength)]
        public string Name { get; set; }
        
        public virtual ICollection<VehicleModel> Models
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
