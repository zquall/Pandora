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
    public class BusinessPartnerService
    {
        public string GetList(string sessionId)
        {
            SBODI_Server.Node DISnode = null; 
			string strSOAPans = null, strSOAPcmd = null; 
			System.Xml.XmlDocument xmlDoc = null; 
            
			xmlDoc = new System.Xml.XmlDocument(); 
			DISnode = new SBODI_Server.Node();

            strSOAPcmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" + "<env:Header>" + "<SessionID>" + sessionId + "</SessionID>" + @"</env:Header><env:Body><dis:GetBPList xmlns:dis=""http://www.sap.com/SBO/DIS"">" + "<CardType>" + "" + "</CardType>" + "</dis:GetBPList></env:Body></env:Envelope>"; 
            
			strSOAPans = DISnode.Interact( strSOAPcmd ); 
			xmlDoc.LoadXml( strSOAPans );


            return strSOAPans; // xmlDoc.ToString();
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