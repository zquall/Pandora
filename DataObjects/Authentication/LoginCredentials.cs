using System.Xml.Serialization;

namespace PandoraObjects.Authentication
{
    [XmlRoot(ElementName = "Login")]
    //[XmlRootAttribute(ElementName = "Login", Namespace = "http://www.sap.com/SBO/DIS")]
    public class LoginCredentials
    {
        [XmlAttribute("CommandID")]
        public string Command { get; set; }

        public string DatabaseServer { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseType { get; set; }
        public string DatabaseUsername { get; set; }
        public string DatabasePassword { get; set; }
        public string CompanyUsername { get; set; }
        public string CompanyPassword { get; set; }
        public string Language { get; set; }
        public string LicenseServer { get; set; }
    }
}


