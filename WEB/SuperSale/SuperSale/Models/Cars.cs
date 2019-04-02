using System;
using System.Collections.Generic;

namespace SuperSale.Models
{
    public partial class Cars
    {
        public long CarId { get; set; }
        public byte BrandId { get; set; }
        public byte TypeId { get; set; }
        public string Generation { get; set; }
        public int Engine { get; set; }
    }
}
