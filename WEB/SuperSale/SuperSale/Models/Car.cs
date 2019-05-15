using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperSale.Models
{
    public partial class Car
    {
        public long CarId { get; set; }
        [Display(Name = "Brand")]
        public string Brand { get; set; }
        [Display(Name = "Type")]
        public string Type { get; set; }
        [Display(Name = "Generation")]
        public int Gen { get; set; }
        [Display(Name = "Engine")]
        public int Engine { get; set; }
    }
}
