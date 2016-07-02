using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using BusinessOneObjects.Response;
using Extensions.Types;

namespace Core
{
    internal static class SapServer
    {
        internal static EnvelopeResponse Execute(string command)
        {
            var sboServer = new SBODI_Server.Node();
            var result = sboServer.Interact(command);

            var response = ParseXml<EnvelopeResponse>(result);

            ErrorHandler(response);
            return response;
        }
        
        private static T ParseXml<T>(string xml) where T : class
        {
            var xdoc = XDocument.Parse(xml);
            var serializer = new XmlSerializer(typeof(T));
            return serializer.Deserialize(xdoc.CreateReader()) as T;
        }

        private static void ErrorHandler(EnvelopeResponse response)
        {
            if (response != null && response.Body.Fault != null)
            {
                throw new Exception(response.Body.Fault.Reason.Text.Value);
            }
        }
    }
}
