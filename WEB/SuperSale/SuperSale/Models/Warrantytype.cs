using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSale.Models
{
    public class Warrantytype
    {
        public int ServicePackTypeID { get; set; }
        [Display(Name = "Type of service")]
        public string ServiceName { get; set; }
        public int PartTypeID { get; set; }
        [Display(Name = "Part guaranteed")]
        public string PartTypeName { get; set; }
        [Display(Name = "Years of guarantee")]
        public int Years { get; set; }
    }
}
