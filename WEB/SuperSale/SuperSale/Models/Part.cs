using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSale.Models
{
    public class Part
    {
        public long PartID { get; set; }
        public string Name { get; set; }
        public string PartType { get; set; }
        public decimal Price { get; set; }
        public string UM { get; set; }
        public bool SERVICE { get; set; }
    }
}
