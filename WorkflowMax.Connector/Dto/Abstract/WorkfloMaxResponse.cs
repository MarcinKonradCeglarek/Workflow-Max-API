namespace WorkflowMax.Connector.Dto.Abstract
{
    using System;
    using System.Xml.Serialization;

    [Serializable, XmlRoot("Response")]
    public abstract class WorkfloMaxResponse
    {
        public Status Status { get; set; }
    }
}