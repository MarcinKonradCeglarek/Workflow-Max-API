namespace WorkflowMax.Connector.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    using WorkflowMax.Connector.Dto.Abstract;

    [Serializable, XmlRoot("Response")]
    public class ClientsResponse : WorkfloMaxResponse
    {
        [XmlArray("Clients")]
        [XmlArrayItem(ElementName = "Client", Type = typeof(XmlClient))]
        public List<XmlClient> Clients { get; set; }
    }

    [Serializable, XmlRoot("Response")]
    public class ClientResponse : WorkfloMaxResponse
    {
        public XmlClient Client { get; set; }
    }
}