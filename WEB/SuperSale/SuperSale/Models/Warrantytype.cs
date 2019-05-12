using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSale.Models
{
    public class Warrantytype
    {
        public int ServicePackTypeID { get; set; }
        public string ServiceName { get; set; }
        public int PartTypeID { get; set; }
        public string PartTypeName { get; set; }
        public int Years { get; set; }
    }
}
