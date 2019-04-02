using System;
using System.Collections.Generic;

namespace SuperSale.Models
{
    public partial class Parts
    {
        public long PartId { get; set; }
        public int? PartType { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Um { get; set; }
        public bool Service { get; set; }
    }
}
