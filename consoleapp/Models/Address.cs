using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _state;
        private string _postalCode;

        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        public Address(string street, string city, string state, string postalCode)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public override string ToString()
        {
            return $"----|Address|----\n" +
                   $"Street: {Street}\n" +
                   $"City: {City}\n" +
                   $"State: {State}\n" +
                   $"Postal Code: {PostalCode}\n";
        }
    }
}
