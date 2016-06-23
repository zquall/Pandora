using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using DataObjects.Item;

namespace DataObjects.Customer
{
    public class CreditMemo
    {
        public int SellerCode { get; set; } //SalesPersonCode
        public double DiscountPercent { get; set; } // DiscountPercent
        public int DocumentId { get; set; } // DocNum
        public string InvoiceType { get; set; } // DocType
        public string DocumentType { get; set; } // U_SCG_TipoDocumento { get; set; }
        public string CustomerCode { get; set; } // CardCode
        public string CustomerName { get; set; }
        public string Comments { get; set; } //Comments
        public DateTime PostingDate { get; set; } // DocDate
        public DateTime DueDate { get; set; } // DocDueDate
        public DateTime DocumentDate { get; set; } // TaxDate
        public List<ItemDetail> ItemDetails { get; set; }
        // pedding to translate
        public string DocCurrency { get; set; }
        public string NumAtCard { get; set; }
        public bool HandWritten { get; set; }
        public bool ManualNumber { get; set; }
    }
}


