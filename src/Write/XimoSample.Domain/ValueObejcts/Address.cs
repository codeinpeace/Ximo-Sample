using Ximo.Domain;
using Ximo.Validation;

namespace XimoSample.Domain.ValueObejcts
{
    public class Address : ValueObject<Address>
    {
        private string _addressLine1;
        private string _addressLine2;
        private string _city;
        private string _countryName;
        private string _planet;
        private string _postcode;
        private string _state;

        private Address()
        {
        }

        public Address(string addressLine1 = null, string addressLine2 = null, string city = null,
            string postCode = null, string state = null, string countryName = null, string planet = null)
            : this()
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            Postcode = postCode;
            State = state;
            CountryName = countryName;
            Planet = planet;
        }

        public string AddressLine1
        {
            get => _addressLine1;
            private set
            {
                PropertyCheck.MaxLength(value, 100);
                _addressLine1 = value;
            }
        }

        public string AddressLine2
        {
            get => _addressLine2;
            private set
            {
                PropertyCheck.MaxLength(value, 100);
                _addressLine2 = value;
            }
        }

        public string City
        {
            get => _city;
            private set
            {
                PropertyCheck.MaxLength(value, 100);
                _city = value;
            }
        }

        public string Planet
        {
            get => _planet;
            private set
            {
                PropertyCheck.MaxLength(value, 100);
                _planet = value;
            }
        }

        public string Postcode
        {
            get => _postcode;
            private set
            {
                PropertyCheck.MaxLength(value, 12);
                _postcode = value;
            }
        }

        public string State
        {
            get => _state;
            private set
            {
                PropertyCheck.MaxLength(value, 100);
                _state = value;
            }
        }

        public string CountryName
        {
            get => _countryName;
            private set
            {
                PropertyCheck.MaxLength(value, 100);
                _countryName = value;
            }
        }
    }
}