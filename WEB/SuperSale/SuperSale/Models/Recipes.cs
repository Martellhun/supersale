using System;
using System.Collections.Generic;

namespace SuperSale.Models
{
    public partial class Recipes
    {
        public long RecipeId { get; set; }
        public long ServicePackId { get; set; }
        public long PartId { get; set; }
        public int Quantity { get; set; }
    }
}
