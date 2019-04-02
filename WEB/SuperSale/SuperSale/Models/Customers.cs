using System;
using System.Collections.Generic;

namespace SuperSale.Models
{
    public partial class Customers
    {
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
    }
}
