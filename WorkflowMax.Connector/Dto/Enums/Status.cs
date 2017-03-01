namespace WorkflowMax.Connector.Dto
{
    using System.Xml.Serialization;

    public enum Status
    {
        Unset, 

        [XmlEnum(Name = "OK")]
        Success,

        [XmlEnum(Name = "ERROR")]
        Error
    }
}