
namespace BusinessOneObjects.Request
{
    /// <remarks/>
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sap.com/SBO/DIS")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sap.com/SBO/DIS", IsNullable = false)]
    public class AddObject
    {
        public AddObject()
        {
            BOM = new BOM();
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public BOM BOM { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CommandID { get; set; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeHeader
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public string SessionID { get; set; }
    }


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class BOM
    {
        public BOM()
        {
            BO = new Bombo();
        }

        /// <remarks/>
        public Bombo BO { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class Bombo
    {
        public Bombo()
        {
            AdmInfo = new BOMBOAdmInfo();
            Documents = new BOMBORow[0];
            Document_Lines =  new BOMBORowLines[0];
        }

        public BOMBOAdmInfo AdmInfo { get; set; }

        [System.Xml.Serialization.XmlArrayItemAttribute("row", IsNullable = false)]
        public BOMBORow[] Documents { get; set; }

        [System.Xml.Serialization.XmlArrayItemAttribute("row", IsNullable = false)]
        public BOMBORowLines[] Document_Lines { get; set; }
    }



    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class BOMBOAdmInfo
    {
        /// <remarks/>
        public string Object { get; set; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class BOMBORow
    {
        public uint DocNum { get; set; }
        public uint DocDate { get; set; }
        public uint DocDueDate { get; set; }
        public uint TaxDate { get; set; }
        public uint SalesPersonCode { get; set; }

        public decimal DiscountPercent { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string CardCode { get; set; }
        public string Comments { get; set; }

        public string U_SCG_TipoDocumento { get; set; }
        public string U_UDF_NombreCliente { get; set; }
        public string U_SCG_DireccionProy { get; set; }


        public string DocCurrency { get; set; }
        public string NumAtCard { get; set; }
        public string HandWritten { get; set; }
        public string ManualNumber { get; set; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class BOMBORowLines
    {
        public string TaxLiable { get; set; }
        public string ItemCode { get; set; }
        public string TaxCode { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public int WarehouseCode { get; set; }
        public int DiscountPercent { get; set; }
    }
}





