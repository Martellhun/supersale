using System;
using System.Collections.Generic;

namespace SuperSale.Models
{
    public partial class CarParts
    {
        public long ConnectionId { get; set; }
        public long CarId { get; set; }
        public long PartId { get; set; }
        public byte? TypeId { get; set; }
    }
}
