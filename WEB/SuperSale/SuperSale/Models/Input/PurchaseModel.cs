using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSale.Models
{
    public class PurchaseModel
    {
	    public long CustomerID { get; set; }
        public long CarID { get; set; }
        public IEnumerable<PurchaseItems> PurchaseItems { get; set; }
    }

   

    public class PurchaseItems
    {
        public string Name { get; set; }
        [JsonProperty("Unit Price")]
        public decimal UnitPrice { get; set; }
        [JsonProperty("Selected")]
        public bool Selected { get; set; }
        [JsonProperty("ProductID")]
        public long ProductID { get; set; }
        [JsonProperty("ProductTypeID")]
        public int ProductTypeID { get; set; }
        public ProductType ProductType { get; set; }
    }
}
