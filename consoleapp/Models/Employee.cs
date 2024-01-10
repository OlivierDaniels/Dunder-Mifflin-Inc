using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Employee: Person
    {
        private int _employeeId;
        private string _department;
        private string _function;

        public int EmployeeId
        {
            get { return _employeeId; }
            set 
            { 
                _employeeId = value;
                if (value<0)
                {
                    throw new IdNietOkException();
                }
            }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public string Function
        {
            get { return _function; }
            set { _function = value; }
        }

        public Employee(int id, string firstName, string lastName, DateTime birthDate, Address address,
                    int employeeId, string department, string function)
        : base(id, firstName, lastName, birthDate, address)
        {
            EmployeeId = employeeId;
            Department = department;
            Function = function;
        }

        public override bool Equals(object? obj)
        {
            return obj is Employee employee && FirstName == employee.FirstName
                && LastName == employee.LastName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id,FirstName, LastName, Function);
        }

        public override string DisplayInformation()
        {
            return $"{base.DisplayInformation()}" +
                   $"Department: {Department}\n" +
                   $"Function: {Function}\n";


        }
    }
}
