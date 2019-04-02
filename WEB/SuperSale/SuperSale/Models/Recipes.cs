using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperSale.Models
{
    public partial class Recipes
    {
        [Key]
        public long RecipeId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Unit Of Measurement")]
        public string UM { get; set; }
    }
}
