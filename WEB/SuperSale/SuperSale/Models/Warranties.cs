using System;
using System.Collections.Generic;

namespace SuperSale.Models
{
    public partial class Warranties
    {
        public long WarrantyId { get; set; }
        public long CustomerId { get; set; }
        public long CarId { get; set; }
        public int PartTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte Status { get; set; }
    }
}
