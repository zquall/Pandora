using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using DataObjects.Item;

namespace DataObjects.Customer
{
    public class CustomerProject
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
    }
}


