using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.Item
{
    public class ItemDetail
    {
        public bool TaxLiable { get; set; }
        public string ItemCode { get; set; }
        public string TaxCode { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public int WarehouseCode { get; set; }
        public int DiscountPercent { get; set; }
    }
}
