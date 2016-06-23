using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using DataObjects.Authentication;

using BusinessOneObjects.Response;
using BusinessOneObjects.Request;
using DataObjects.Customer;
using DataObjects.Item;
using SoapXmlGenerator;
using Extensions.Types;

namespace Core
{
    public class InvoiceService
    {
        public string Add(string sessionId, CustomerInvoice invoice)
        {

            //Real Object
            //var invoice = new CustomerInvoice
            //    {
            //        CustomerCode = "C004200",
            //        DocumentDate = DateTime.Today,
            //        DueDate = DateTime.Today.AddMonths(1),
            //        PostingDate = new DateTime(2015, 11, 01),
            //        SellerCode = 4,
            //        DiscountPercent = 0,
            //        DocumentType = "Alquileres",
            //        ItemDetails = new List<ItemDetail>
            //            {
            //                //new ItemDetail() {ItemCode = "abc001", Quantity = 1, TaxCode = "IV", Currency = "COL"},
            //                new ItemDetail() {ItemCode = "A9999999", Quantity = 2.5,TaxLiable = false, Currency = "USD", Price = 60 }
            //            },
            //            Comments = "Migrado desde Pithos"
            //    };

            var addObject = new AddObject
                {
                    CommandID = "Add invoice", BOM = {BO = Mapper.Map<Bombo>(invoice)}
                };
            addObject.BOM.BO.AdmInfo.Object = "oInvoices";


            // Generate SOAP Message
            var command = SoapXmlSerializer.SoapXmlSerialize(addObject, sessionId);

            var result = SapServer.Execute(command);

            return result.Body.Fault == null ? result.Body.AddObjectResponse.RetKey.ToString(CultureInfo.InvariantCulture) : result.Body.Fault.Reason.Text.Value;
        }
    }
}




/*
var xDoc = XDocument.Load(sSOAPans);

dynamic root = new ExpandoObject();

XmlToDynamic.Parse(root, xDoc.Elements().First());

//  Parse the SOAP answer
System.Xml.XmlValidatingReader xmlValid = null;
xmlValid = new System.Xml.XmlValidatingReader(sSOAPans, System.Xml.XmlNodeType.Document, null);
while (xmlValid.Read())
{
    if (xmlValid.NodeType == System.Xml.XmlNodeType.Text)
    {
        if (sRet == null)
        {
            sRet += xmlValid.Value;
        }
        else
        {
            if (sRet.StartsWith("Error"))
            {
                sRet += " " + xmlValid.Value;
            }
            else
            {
                sRet = "Error " + sRet + " " + xmlValid.Value;
            }
        }
    }
}
             
             
  //// get the xml value somehow
  //  var xdoc= XDocument.Parse(@"<Class><Property>Value</Property></Class>");
  //  // deserialize the xml into the proxy type
  //  var proxy = Deserialize<ClassSerializerProxy>(xdoc);
  //  // read the resulting value
  //  var value = proxy.ClassValue;
*/