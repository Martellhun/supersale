using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperSale.Models
{
    public partial class ServicePack
    {
        [Key]
        public long ServicePackId { get; set; }
        public string BrandName { get; set; }
        public string CarTypeName { get; set; }
        public string ServiceTypeName { get; set; }
        public int Generation { get; set; }
        public int Engine { get; set; }
    }
}
