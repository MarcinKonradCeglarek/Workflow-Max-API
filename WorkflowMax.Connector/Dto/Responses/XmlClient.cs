namespace WorkflowMax.Connector.Dto
{
    using System;
    using System.Globalization;
    using System.Xml.Serialization;

    using WorkflowMax.Connector.ValueObjects;
    using WorkflowMax.Model;

    public class XmlClient
    {
        public XmlClient()
        {
            
        }

        public XmlClient(Client client)
        {
            this.Address = client.Address.Address;
            this.City = client.Address.City;
            this.Country = client.Address.Country;
            this.DateOfBirth = client.DateOfBirth?.ToString(XmlClient.DateFormat) ?? string.Empty;
            this.Email = client.Email;
            this.Fax = client.Fax;
            this.Id = client.Id;
            this.IsArchived = client.IsArchived ? XmlClient.TrueValue : XmlClient.FalseValue;
            this.IsDeleted = client.IsDeleted ? XmlClient.TrueValue : XmlClient.FalseValue;
            this.IsProspect = client.IsProspect ? XmlClient.TrueValue : XmlClient.FalseValue;
            this.Name = client.Name;
            this.Phone = client.Phone;
            this.PostCode = client.Address.PostCode;
            this.PostalAddress = client.PostalAddress.Address;
            this.PostalCountry = client.PostalAddress.Country;
            this.PostalCity = client.PostalAddress.City;
            this.PostalRegion = client.PostalAddress.Region;
            this.PostalPostCode = client.PostalAddress.PostCode;
            this.Region = client.Address.Region;
            this.Website = client.Website;
        }

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

        public Client ConvertToClient()
        {
            var dateOfBirth = DateTime.MinValue;
            DateTime.TryParseExact(this.DateOfBirth, XmlClient.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth);

            var isArchived = this.IsArchived == XmlClient.TrueValue;
            var isDeleted = this.IsDeleted == XmlClient.TrueValue;
            var isProspect = this.IsProspect == XmlClient.TrueValue;

            var client = new Client(
                new AddressValueObject(this.Address, this.City, this.Region, this.Country, this.PostCode),
                dateOfBirth,
                this.Email,
                this.Fax,
                this.Id,
                isArchived,
                isDeleted,
                isProspect,
                this.Name,
                this.Phone,
                new AddressValueObject(this.PostalAddress, this.PostalCity, this.PostalRegion, this.PostalCountry, this.PostalPostCode),
                this.Website);

            return client;
        }
    }
}