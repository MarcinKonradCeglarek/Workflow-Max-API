namespace WorkflowMax.Connector.ValueObjects
{
    public class AddressValueObject
    {
        public AddressValueObject(string address, string city, string region, string country, string postCode)
        {
            this.Address = address;
            this.City = city;
            this.Region = region;
            this.Country = country;
            this.PostCode = postCode;
        }

        public string Address { get; }

        public string City { get; }

        public string Country { get; }

        public string PostCode { get; }

        public string Region { get; }
    }
}