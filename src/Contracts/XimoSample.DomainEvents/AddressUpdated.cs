using System;
using System.Diagnostics.CodeAnalysis;

namespace XimoSample.DomainEvents
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class AddressUpdated
    {
        private AddressUpdated()
        {
        }

        public AddressUpdated(Guid accountId, string addressLine1 = null, string addressLine2 = null,
            string city = null,
            string postcode = null, string state = null, string countryName = null) : this()
        {
            AccountId = accountId;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            Postcode = postcode;
            State = state;
            CountryName = countryName;
        }

        public Guid AccountId { get; private set; }

        public string AddressLine1 { get; private set; }

        public string AddressLine2 { get; private set; }

        public string City { get; private set; }

        public string Postcode { get; private set; }

        public string State { get; private set; }

        public string CountryName { get; private set; }
    }
}