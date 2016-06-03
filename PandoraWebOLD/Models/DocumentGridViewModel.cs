using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandoraWeb.Models
{
    public class DocumentGridViewModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal Amount => Quantity * UnitPrice;
    }
}