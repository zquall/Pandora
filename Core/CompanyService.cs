using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using PandoraObjects.Authentication;
using SoapXmlGenerator;
using Extensions.Types;

namespace Core
{
    public class CompanyService
    {

        public string GetAdminInfo(string sessionId)
        {
            SBODI_Server.Node DISnode = null;
            string result = null;

            DISnode = new SBODI_Server.Node();
            
            var soapCommand = @"<?xml version=""1.0"" encoding=""UTF-16""?>" +
                                 @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" +
                                    "<env:Header><SessionID>" + sessionId + "</SessionID></env:Header>" +
                                @"<env:Body><dis:GetAdminInfo xmlns:dis=""http://www.sap.com/SBO/DIS"">" +
                                    "<Service>CompanyService</Service>" +
                                "</dis:GetAdminInfo></env:Body></env:Envelope>";

            result = DISnode.Interact(soapCommand);
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(result);
            return xmlDoc.InnerXml;
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