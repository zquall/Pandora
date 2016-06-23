using System.Xml.Serialization;

namespace BusinessOneObjects.Response
{
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    [XmlRootAttribute( ElementName = "Envelope" ,Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
    public class EnvelopeResponse
    {
        public EnvelopeBody Body { get; set; }
    }

    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class EnvelopeBody
    {
        public FaultResponse Fault { get; set; }

        [XmlElementAttribute(Namespace = "http://www.sap.com/SBO/DIS")]
        public AddObjectResponse AddObjectResponse { get; set; }

        [XmlElement(Namespace = "http://www.sap.com/SBO/DIS")]
        public LoginResponse LoginResponse { get; set; }
    }
}
