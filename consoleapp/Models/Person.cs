using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Person: Entity
    {
        private string _firstName;
        private string _lastName;
        private DateTime _birthdate;
        public Address _address;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public DateTime Birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public Person(int id, string firstName, string lastName, DateTime birthdate, Address address)
            :base(id,firstName + " "+lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Address = address;
        }

        public override string DisplayInformation()
        {
            return $"ID: {Id}\n" +
                   $"Name: {FirstName} {LastName}\n" +
                   $"BirthDate: {Birthdate.ToShortDateString()}\n" +
                   $"{Address}\n";

        }
    }
}
