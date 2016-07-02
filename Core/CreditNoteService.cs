using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using PandoraObjects.Authentication;

using BusinessOneObjects.Response;
using BusinessOneObjects.Request;
using PandoraObjects.Customer;
using PandoraObjects.Item;
using SoapXmlGenerator;
using Extensions.Types;

namespace Core
{
    public class CreditNoteService
    {
        public string Add(string sessionId, CustomerInvoice invoice)
        {
        //    invoice = new CustomerInvoice
        //    {
        //        CustomerCode = "C004200",
        //        DocumentDate = DateTime.Today.AddDays(1),
        //        DueDate = DateTime.Today.AddMonths(1),
        //        PostingDate = DateTime.Today,
        //        SellerCode = 1,
        //        DiscountPercent = 0,
        //        DocumentType = "Alquileres",
        //        HandWritten = false,
        //        ManualNumber = false,

        //ItemDetails = new List<ItemDetail>
        //                {
        //                    //new ItemDetail() {ItemCode = "abc001", Quantity = 1, TaxCode = "IV", Currency = "COL"},
        //                    new ItemDetail() {ItemCode = "A9999999", Quantity = 1,TaxLiable = true, TaxCode = "IV", Currency = "USD", Price = 1234, WarehouseCode = 16}
        //                },
        //        Comments = "Migrado desde Pithos"
        //    };



            var addObject = new AddObject
                {
                CommandID = "Add CN", BOM = {BO = Mapper.Map<Bombo>(invoice)}
                };
            addObject.BOM.BO.AdmInfo.Object = "oCreditNotes";
            
            // Generate SOAP Message
            var command = SoapXmlSerializer.SoapXmlSerialize(addObject, sessionId);

            var result = SapServer.Execute(command);

            return result.Body.Fault == null ? result.Body.AddObjectResponse.RetKey.ToString(CultureInfo.InvariantCulture) : result.Body.Fault.Reason.Text.Value;
        }
    }
}