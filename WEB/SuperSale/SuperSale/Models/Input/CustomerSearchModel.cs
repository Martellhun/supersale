using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSale.Models.Input
{
    public class CustomerSearchModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool WithWildCard { get; set; }
    }
}
