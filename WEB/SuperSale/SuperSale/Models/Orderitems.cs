using System;
using System.Collections.Generic;

namespace SuperSale.Models
{
    public partial class Orderitems
    {
        public long OrderItemId { get; set; }
        public long OrderId { get; set; }
        public long PartId { get; set; }
        public int Quantity { get; set; }
    }
}
