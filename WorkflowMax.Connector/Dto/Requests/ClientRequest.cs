namespace WorkflowMax.Connector.Dto
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot("Client")]
    public class ClientRequest
    {
        [XmlElement(ElementName = "ID")]
        public int Id { get; set; }
    }
}