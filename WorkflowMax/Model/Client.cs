namespace WorkflowMax.Model
{
    using System;

    using WorkflowMax.Connector.ValueObjects;

    public class Client
    {
        public Client(
            AddressValueObject address,
            DateTime? dateOfBirth,
            string email,
            string fax,
            int id,
            bool isArchived,
            bool isDeleted,
            bool isProspect,
            string name,
            string phone,
            AddressValueObject postalAddress,
            string website)
        {
            this.Address = address;
            this.DateOfBirth = dateOfBirth;
            this.Email = email;
            this.Fax = fax;
            this.Id = id;
            this.IsArchived = isArchived;
            this.IsDeleted = isDeleted;
            this.IsProspect = isProspect;
            this.Name = name;
            this.Phone = phone;
            this.PostalAddress = postalAddress;
            this.Website = website;
        }

        public AddressValueObject Address { get; }

        public DateTime? DateOfBirth { get; }

        public string Email { get; }

        public string Fax { get; }

        public int Id { get; }

        public bool IsArchived { get; }

        public bool IsDeleted { get; }

        public bool IsProspect { get; }

        public string Name { get; }

        public string Phone { get; }

        public AddressValueObject PostalAddress { get; }

        public string Website { get; }
    }
}