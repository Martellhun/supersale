using System;
using System.Collections.Generic;

namespace SuperSale.Models
{
    public partial class ServicePacks
    {
        public long ServicePackId { get; set; }
        public byte CarId { get; set; }
        public int ServicePackTypeId { get; set; }
    }
}
