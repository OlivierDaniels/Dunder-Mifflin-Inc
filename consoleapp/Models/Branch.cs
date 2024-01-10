using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Branch:Entity
    {
        private string _manager;
        private Address _address;

        public string Manager
        {
            get { return _manager; }
            set { _manager = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        

        public Branch(int id, string name, string manager,Address address)
            :base(id,name)
        {
            Manager = manager;
            Address = address;
        }
        public override bool Equals(object? obj)
        {
            return obj is Branch branch && Name == branch.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

        public override string DisplayInformation()
        {
            return $"     {Name}     \n" +
                   $"Manager: {Manager}\n" +
                   $"{Address}";

        }
    }
}
