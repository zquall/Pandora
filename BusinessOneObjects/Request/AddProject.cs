
using System.Xml.Serialization;

namespace BusinessOneObjects.Request
{
    [XmlRootAttribute(Namespace = "http://www.sap.com/SBO/DIS", IsNullable = false)]
    public class AddProject
    {
        public AddProject()
        {
            Service = "ProjectsService";
        }

        [XmlElementAttribute(Namespace = "")]
        public string Service { get; set; }
        
        [XmlElementAttribute(Namespace = "")]
        public Project Project { get; set; }
    }

    public class UpdateProject:AddProject{}

    public class Project
    {
        public string Code { get; set; }
        public string Name { get; set; }

        [XmlElementAttribute(ElementName = "U_UDF_NombreCliente")]
        public string CustomerName { get; set; }

        [XmlElementAttribute(ElementName = "U_SCG_DireccionProy")]
        public string Address { get; set; }
    }
}
