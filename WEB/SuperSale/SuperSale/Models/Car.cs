using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperSale.Models
{
    public partial class Car
    {
        public long CarId { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int Gen { get; set; }
        public int Engine { get; set; }
    }
}
