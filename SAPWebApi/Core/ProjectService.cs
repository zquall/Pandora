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
    public class ProjectService
    {
        public string Add(string sessionId)
        {
            
            var project = new CustomerProject
                {
                    Code = "TEST01",
                    Name = "Proyecto Manhathan",
                    CustomerName = "Tomela S.A.",
                    Address = "Atras de ti, bruto"
                };

            var addProject = Mapper.Map<AddProject>(project);

            // Generate SOAP Message
            var command = SoapXmlSerializer.SoapXmlSerialize(addProject, sessionId);

            var result = SapServer.Execute(command);

            return result.Body.Fault == null ? result.Body.AddObjectResponse.RetKey.ToString(CultureInfo.InvariantCulture) : result.Body.Fault.Reason.Text.Value;
        }

        public string Update(string sessionId)
        {

            var project = new CustomerProject
            {
                Code = "TEST01",
                Name = "Proyecto Manhathan",
                CustomerName = "Tomela S.A.",
                Address = "Atras de ti, bruto"
            };

            var addProject = Mapper.Map<UpdateProject>(project);

            // Generate SOAP Message
            var command = SoapXmlSerializer.SoapXmlSerialize(addProject, sessionId);

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