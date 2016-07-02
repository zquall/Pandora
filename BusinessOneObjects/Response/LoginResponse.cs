using System.Xml.Serialization;

namespace BusinessOneObjects.Response
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sap.com/SBO/DIS")]
    [XmlRootAttribute(Namespace = "http://www.sap.com/SBO/DIS", IsNullable = false)]
    public class LoginResponse
    {
        /// <remarks/>
        public string SessionID { get; set; }
    }
}


