using System;
using System.Collections.Generic;

namespace SuperSale.Models
{
    public partial class UserDetails
    {
        public long UserId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Street { get; set; }
        public string Streettype { get; set; }
        public int Adress { get; set; }
    }
}
