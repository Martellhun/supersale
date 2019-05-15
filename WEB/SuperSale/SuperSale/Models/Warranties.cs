using System;
using System.Collections.Generic;

namespace SuperSale.Models
{
    public partial class Warranties
    {
        public long OrderID { get; set; }
        public string CarBrand { get; set; }
        public string CarType { get; set; }
        public string PartType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
