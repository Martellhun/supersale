﻿using System;
using System.Collections.Generic;

namespace SuperSale.Models
{
    public partial class Orders
    {
        public long OrderId { get; set; }
        public long? CustomerId { get; set; }
        public long SoldBy { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime RecordedAt { get; set; }
    }
}
