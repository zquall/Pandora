namespace BusinessOneObjects.Response
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class FaultResponse
    {
        public FaultResponseCode Code { get; set; }

        public FaultResponseReason Reason { get; set; }

        public FaultResponseDetail Detail { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class FaultResponseCode
    {
        public string Value { get; set; }

        public FaultResponseCodeSubcode Subcode { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class FaultResponseCodeSubcode
    {
        public int Value { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class FaultResponseReason
    {
        public FaultResponseReasonText Text { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class FaultResponseReasonText
    {
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang { get; set; }

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class FaultResponseDetail
    {
        public int Object { get; set; }

        public int ObjectIndex { get; set; }

        public string Command { get; set; }

        public string CommandID { get; set; }

        public string SessionID { get; set; }
    }


}
