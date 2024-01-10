using consoleapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    [TestCategory("Models")]
    public class DepartementTest
    {
        [TestMethod]
        public void Department_Constructor_CreatesCorrectInstance()
        {
            //Arrange
            string birthdateS = "15-May-1964";
            DateTime birthdate = DateTime.Parse(birthdateS);
            List<Employee> employees = new List<Employee>();
            Address address1 = new Address("Tree Street", "testCity", "TestState", "1234");
            Employee employee1 = new Employee(1,"Bart","Peeters",birthdate ,address1,23,"Temp","Temp");
            Address address2 = new Address("Palm Street", "Columbus", "Ohio", "43201");
            Department department = new Department(9, "Temp", "Olivier Daniels",employees);

            //Act
            department.Id = 15;

            //Assert
            Assert.IsNotNull(department);
            Assert.AreEqual(15, department.Id);
            Assert.AreEqual("Temp", department.Name);
            Assert.AreEqual("Olivier Daniels", department.Head);
        }
    }
}