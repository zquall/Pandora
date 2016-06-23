namespace BusinessOneObjects.Response
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sap.com/SBO/DIS")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sap.com/SBO/DIS", IsNullable = false)]
    public class AddObjectResponse
    {

        private byte retKeyField;

        private string commandIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
        public byte RetKey
        {
            get
            {
                return this.retKeyField;
            }
            set
            {
                this.retKeyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CommandID
        {
            get
            {
                return this.commandIDField;
            }
            set
            {
                this.commandIDField = value;
            }
        }
    }


}
