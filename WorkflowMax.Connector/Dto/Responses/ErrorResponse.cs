namespace WorkflowMax.Connector.Dto
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    using WorkflowMax.Connector.Dto.Abstract;

    [Serializable, XmlRoot("Response")]
    public class ErrorResponse : WorkfloMaxResponse
    {
        [DisplayName("ErrorDescription")]
        public string Description { get; set; }
    }
}