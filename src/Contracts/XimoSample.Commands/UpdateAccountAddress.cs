using System;

namespace XimoSample.Commands
{
    public class UpdateAccountAddress
    {
        private UpdateAccountAddress()
        {
        }

        public UpdateAccountAddress(Guid accountId, string addressLine1, string addressLine2, string postcode,
            string city, string state, string countryName) : this()
        {
            AccountId = accountId;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            Postcode = postcode;
            City = city;
            State = state;
            CountryName = countryName;
        }

        public Guid AccountId { get; }
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public string Postcode { get; }
        public string City { get; }
        public string State { get; }
        public string CountryName { get; }
    }
}