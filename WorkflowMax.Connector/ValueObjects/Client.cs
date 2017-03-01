namespace WorkflowMax.Connector.ValueObjects
{
    using System;
    using System.Globalization;

    using WorkflowMax.Connector.Dto;

    public class Client
    {
        public Client(XmlClient client)
        {
            this.Address = client.Address;
            this.City = client.City;
            this.Country = client.Country;

            DateTime temp;
            if (DateTime.TryParseExact(client.DateOfBirth, XmlClient.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
            {
                this.DateOfBirth = temp;
            }

            this.Email = client.Email;
            this.Fax = client.Fax;
            this.Id = client.Id;
            this.IsArchived = client.IsArchived == XmlClient.TrueValue;
            this.IsDeleted = client.IsDeleted == XmlClient.TrueValue;
            this.IsProspect = client.IsProspect == XmlClient.TrueValue;
            this.Name = client.Name;
            this.Phone = client.Phone;
            this.PostCode = client.PostCode;
            this.PostalAddress = client.PostalAddress;
            this.PostalCity = client.PostalCity;
            this.PostalCountry = client.PostalCountry;
            this.PostalPostCode = client.PostalPostCode;
            this.PostalRegion = client.PostalRegion;
            this.Region = client.Region;
            this.Website = client.Website;
        }

        public string Address { get; }

        public string City { get; }

        public string Country { get; }

        public DateTime? DateOfBirth { get; }

        public string Email { get; }

        public string Fax { get; }

        public int Id { get; }

        public bool IsArchived { get; }

        public bool IsDeleted { get; }

        public bool IsProspect { get; }

        public string Name { get; }

        public string Phone { get; }

        public string PostalAddress { get; }

        public string PostalCity { get; }

        public string PostalCountry { get; }

        public string PostalPostCode { get; }

        public string PostalRegion { get; }

        public string PostCode { get; }

        public string Region { get; }

        public string Website { get; }

        public XmlClient ToXmlClient()
        {
            var retVal = new XmlClient()
                             {
                                 Address = this.Address,
                                 City = this.City,
                                 Country = this.Country,
                                 DateOfBirth = this.DateOfBirth?.ToString(XmlClient.DateFormat) ?? string.Empty,
                                 Email = this.Email,
                                 Fax = this.Fax,
                                 Id = this.Id,
                                 IsArchived = this.IsArchived ? XmlClient.TrueValue : XmlClient.FalseValue,
                                 IsDeleted = this.IsDeleted ? XmlClient.TrueValue : XmlClient.FalseValue,
                                 IsProspect = this.IsProspect ? XmlClient.TrueValue : XmlClient.FalseValue,
                                 Name = this.Name,
                                 Phone = this.Phone,
                                 PostCode = this.PostCode,
                                 PostalAddress = this.PostalAddress,
                                 PostalCountry = this.PostalCountry,
                                 PostalCity = this.PostalCity,
                                 PostalRegion = this.PostalRegion,
                                 PostalPostCode = this.PostalPostCode,
                                 Region = this.Region,
                                 Website = this.Website
                             };

            return retVal;
        }
    }
}