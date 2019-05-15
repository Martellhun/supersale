using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperSale.Models
{
    public partial class ServicePack
    {
        [Key]
        public long ServicePackId { get; set; }
        [Display(Name = "Car Brand")]
        public string BrandName { get; set; }
        [Display(Name = "Car Type")]
        public string CarTypeName { get; set; }
        [Display(Name = "Type of service")]
        public string ServiceTypeName { get; set; }
        [Display(Name = "Car Generation")]
        public int Generation { get; set; }
        [Display(Name = "Car Engine")]
        public int Engine { get; set; }
    }
}
