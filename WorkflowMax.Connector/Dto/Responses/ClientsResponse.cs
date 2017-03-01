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

    public class XmlClient
    {
        public static string DateFormat => "yyyy-MM-dd";

        public static string TrueValue => "Yes";

        public static string FalseValue => "No";

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Fax { get; set; }

        [XmlElement(ElementName = "ID")]
        public int Id { get; set; }

        public string IsArchived { get; set; }

        public string IsDeleted { get; set; }

        public string IsProspect { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string PostalAddress { get; set; }

        public string PostalCity { get; set; }

        public string PostalCountry { get; set; }

        public string PostalPostCode { get; set; }

        public string PostalRegion { get; set; }

        public string PostCode { get; set; }

        public string Region { get; set; }

        public string Website { get; set; }
    }
}