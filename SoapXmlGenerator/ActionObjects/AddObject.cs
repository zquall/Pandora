using System.Collections.Generic;
using System.Xml.Serialization;

namespace SoapXmlGenerator.ActionObjects
{
    public class AddObject
    {
        [XmlAttribute("CommandID")]
        public string Command { get; set; }

        [XmlElement(ElementName = "BOM")]
        public BusinessObjectManager BusinessObjectManager { get; set; }
    }

    public class BusinessObjectManager
    {
        [XmlElement(ElementName = "BO")]
        public BusinessObject BusinessObject { get; set; }
    }

    public class BusinessObject
    {
        [XmlElement(ElementName = "AdminInfo")]
        public AdminInfo AdminInfo { get; set; }

        [XmlElement("Documents")]
        public List<DocumentLine> Documents { get; set; }

        [XmlElement("Document_Lines")]
        public List<DocumentLine> DocumentLines { get; set; }
    }

    public class AdminInfo
    {
        [XmlElement(ElementName = "Object")]
        public string ObjectName { get; set; }
    }

    public class Document
    {
        public string DocDate { get; set; }
        public string DocDueDate { get; set; }
        public string CardCode { get; set; }
    }

    public class DocumentLine
    {
        public string ItemCode { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string TaxCode { get; set; }
    }
}


