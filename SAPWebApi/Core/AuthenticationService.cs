using System;
using System.Collections.Generic;
using DataObjects.Authentication;
using BusinessOneObjects.Response;
using SoapXmlGenerator;

namespace Core
{
    public class AuthenticationService
    {
        public string Login(LoginCredentials loginCredentials)
        {
            var command = SoapXmlSerializer.LoginCommand(loginCredentials);

            var result = SapServer.Execute(command);

            return result.Body.LoginResponse.SessionID;
        }

        public void Logout(string sessionId)
        {
            var command = "<?xml version=\"1.0\" encoding=\"UTF-16\"?><env:Envelope xmlns:env=\"http://schemas.xmlsoap.org/soap/envelope/\"><env:Header><SessionID>" + sessionId + "</SessionID></env:Header><env:Body><dis:Logout xmlns:dis=\"http://www.sap.com/SBO/DIS\"></dis:Logout></env:Body></env:Envelope>";
            var result = SapServer.Execute(command);
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