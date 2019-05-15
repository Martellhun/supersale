using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSale.Models
{
    public class Product
    {
        public long ProductID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Unit Of Measurement")]
        public string UM { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeID { get; set; }
        public bool Selected { get; set; }
    }

    public enum ProductType
    {
        Part = 0,
        ServicePack = 1
    }
}


