using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSale.Models
{
    public class Part
    {
        public long PartID { get; set; }
        [Display(Name = "Part Name")]
        public string Name { get; set; }
        [Display(Name = "Part Type")]
        public string PartType { get; set; }
        [Display(Name = "Unit Price")]
        public decimal Price { get; set; }
        [Display(Name = "Unit of measurement")]
        public string UM { get; set; }
        [Display(Name = "Service")]
        public bool SERVICE { get; set; }
    }
}
