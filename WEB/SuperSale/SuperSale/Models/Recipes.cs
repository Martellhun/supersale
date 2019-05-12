using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperSale.Models
{
    public partial class Recipes
    {
        public int Quantity { get; set; }
        public string UM { get; set; }
        public string PartName { get; set; }
        public string ServiceName { get; set; }
    }
}
