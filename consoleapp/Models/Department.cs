using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public class Department : Entity
    {
        private string _head;
        private List<Employee> _employees;


        public string Head
        {
            get { return _head; } 
            set { _head = value; } 
        }

        public List<Employee> Employees
        {
            get { return _employees; }
            private set { _employees = value; }
        }

        public Department(int id,string name,string head,List<Employee> employees)
            : base(id, name)
        {
            Head = head;
            Employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            if (!Employees.Contains(employee))
            {
                Employees.Add(employee);
            }
        }

        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        public override bool Equals(object? obj)
        {
            return obj is Department department && Name == department.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

        public override string DisplayInformation()
        {
            return $"Department: {Id}\n" +
                   $"{Name}\n";
        }

        
    }
}
