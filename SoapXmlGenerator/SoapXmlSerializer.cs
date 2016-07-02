using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using PandoraObjects.Authentication;

namespace SoapXmlGenerator
{
    public static class SoapXmlSerializer
    {
        
        public static string LoginCommand(LoginCredentials loginCredentials)
        {
            // send by parameters
            return SoapXmlSerialize(loginCredentials);
        }

        // La idea es que este metodo se pueda iterar y generar el envelope por cada objeto
        // 
        public static string AddObject(object objectInstance)
        {
            var stringBuilder = new StringBuilder();
            var xmlSetting = new XmlWriterSettings { OmitXmlDeclaration = false };
            using (var writer = XmlWriter.Create(stringBuilder, xmlSetting))
            {
                new XmlSerializer(objectInstance.GetType()).Serialize(writer, objectInstance);
            }

            return stringBuilder.ToString();
        }
         
        public static string SoapXmlSerialize(object objectInstance)
        {
           
            var result = string.Empty;
            if (objectInstance != null)
            {
                var stringBuilder = new StringBuilder();
                var xmlSetting = new XmlWriterSettings() { OmitXmlDeclaration = false };
                using (var writer = XmlWriter.Create(stringBuilder, xmlSetting))
                {
                    writer.WriteStartElement("env", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
                    writer.WriteAttributeString("xmlns", "env", string.Empty, "http://schemas.xmlsoap.org/soap/envelope/");
                    
                    writer.WriteStartElement("Body", "http://schemas.xmlsoap.org/soap/envelope/");

                    var emptyNamepsaces = new XmlSerializerNamespaces();
                    emptyNamepsaces.Add("dis", "http://www.sap.com/SBO/DIS");
                    
                    new XmlSerializer(objectInstance.GetType()).Serialize(writer, objectInstance, emptyNamepsaces);
                    
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                result = stringBuilder.ToString();
            }
            return result;
        }

        // Genera un envelope con una accoin especifica como agregar o borrar
        public static string SoapXmlSerialize(object objectInstance, string sessionId)
        {
            var result = string.Empty;
            if (objectInstance != null)
            {
                var stringBuilder = new StringBuilder();
                var xmlSetting = new XmlWriterSettings { OmitXmlDeclaration = false };
                using (var writer = XmlWriter.Create(stringBuilder, xmlSetting))
                {
                    writer.WriteStartElement("env", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
                    writer.WriteAttributeString("xmlns", "env", string.Empty, "http://schemas.xmlsoap.org/soap/envelope/");

                    #region Header
                    // Add header with session Id when is needed
                    writer.WriteStartElement("Header", "http://schemas.xmlsoap.org/soap/envelope/");
                    writer.WriteElementString("SessionID", sessionId);
                    writer.WriteEndElement();
                    #endregion

                    #region Body
                    
                    writer.WriteStartElement("Body", "http://schemas.xmlsoap.org/soap/envelope/");

                    var emptyNamepsaces = new XmlSerializerNamespaces();
                    emptyNamepsaces.Add("dis", "http://www.sap.com/SBO/DIS");

                    new XmlSerializer(objectInstance.GetType()).Serialize(writer, objectInstance, emptyNamepsaces);
                    writer.WriteEndElement(); 

                    #endregion

                    writer.WriteEndElement();
                }
                result = stringBuilder.ToString();
            }
            return result;
        }

        public static T SoapXmlDeserialize<T>(this string objectData)
        {
            var serializer = new XmlSerializer(typeof(T));
            object result;

            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }
            return (T)result;
        }
    }
}
