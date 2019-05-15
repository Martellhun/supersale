using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSale.Models
{
    public class ProcessPurchaseParams
    {
        public string UserEmail { get; set; }
        public long CustomerID { get; set; }
        public long CarID { get; set; }
        public IEnumerable<ServiceItem> ServicePackIDList { get; set; }
	    public IEnumerable<PartItem> Parts { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class ServiceItem {
        public long ServiceID { get; set; }
        public int ServiceType { get; set; }
    }

    public class PartItem
    {
        public long PartID { get; set; }
        public int Quantity { get; set; }
    }
}
