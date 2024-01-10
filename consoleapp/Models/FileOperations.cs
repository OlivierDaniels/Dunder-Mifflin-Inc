using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace consoleapp.Models
{
    public static class FileOperations
    {

        public static string FileEmployees = "DMScranton.txt";
        public static string FileDepartments = "DMDepartments.txt";
        public static string FileBranches = "DMBranches.txt";
        

        /*public static List<User> ShowUsers()
        {
            List<User> users = new List<User>();


            //Return a empty list if the txt file doesnt exist
            if (!File.Exists(FileUsers)) 
            {
                return users;
            }


            //Reads the txt file and adds users if they are not already in the list
            using (StreamReader reader = new StreamReader(FileUsers))
            {
                while (!reader.EndOfStream) 
                { 
           
                    string record = reader.ReadLine();
                    string[] data = record.Split(";");
                    int id = int.Parse(data[0]);
                    string firstname = data[1];
                    string lastname = data[2];
                    string function = data[3];
                    User user = new User(id, firstname, lastname, function);
                    if (!users.Contains(user))
                    {
                        users.Add(user);
                    }
           
                }
            }
            return users;
        }*/
        public static List<Department> ShowDeparments()
        {
            List<Department> departments = new List<Department>();
            List<Employee> employees = FileOperations.ShowEmployees();


            //Return a empty list if the txt file doesnt exist
            if (!File.Exists(FileDepartments))
            {
                return departments;
            }


            //Reads the txt file and adds users if they are not already in the list
            using (StreamReader reader = new StreamReader(FileDepartments))
            {
                while (!reader.EndOfStream)
                {

                    string record = reader.ReadLine();
                    string[] data = record.Split(";");
                    int id = int.Parse(data[0]);
                    string name = data[1];
                    string head = data[2];
                    
                    Department department = new Department(id, name, head,employees);
                    foreach (Employee employeeInList in employees)
                    {
                        if (department.Name.Equals(employeeInList.Department))
                        {
                            department.AddEmployee(employeeInList);
                        }
                    }
                    if (!departments.Contains(department))
                    {
                        departments.Add(department);
                    }

                }
            }
            return departments;
        }

        public static List<Branch> ShowBranches()
        {
            List<Branch> branches = new List<Branch>();



            //Return a empty list if the txt file doesnt exist
            if (!File.Exists(FileBranches))
            {
                return branches;
            }


            //Reads the txt file and adds users if they are not already in the list
            using (StreamReader reader = new StreamReader(FileBranches))
            {
                while (!reader.EndOfStream)
                {

                    string record = reader.ReadLine();
                    string[] data = record.Split(";");
                    int id = int.Parse(data[0]);
                    string name = data[1];
                    string manager = data[2];
                    string street = data[3];
                    string city = data[4];
                    string state = data[5];
                    string postalcode = data[6];
                    Address address = new Address(street, city, state, postalcode);
                    Branch branch = new Branch(id, name, manager,address);
                    if (!branches.Contains(branch))
                    {
                        branches.Add(branch);
                    }

                }
            }
            return branches;
        }

        public static List<Employee> ShowEmployees()
        {
            List<Employee> employees = new List<Employee>();
            
            try
            {

                //Reads the txt file and adds users if they are not already in the list
                using (StreamReader reader = new StreamReader(FileEmployees))
                {                
                    while (!reader.EndOfStream)
                    {

                        string record = reader.ReadLine();
                        string[] data = record.Split(";");
                        int id = int.Parse(data[0]);
                        string firstname = data[1];
                        string lastname = data[2];
                        DateTime birthdate = DateTime.Parse(data[3]);
                        string street = data[4];
                        string city = data[5];
                        string state = data[6];
                        string postalcode = data[7];
                        int employeeId = int.Parse(data[8]);
                        string department = data[9];
                        string function = data[10];

                        Address address = new Address(street, city, state, postalcode);
                        Employee employee = new Employee(id, firstname, lastname, birthdate, address, employeeId, department, function);

                        if (!employees.Contains(employee))
                        {
                            employees.Add(employee);
                        }
                    }
                }
                return employees;
            }
                catch (Exception ex) {
                    {
                        FoutLoggen(ex);
                        return null;
                    }

            }
        }
        public static void FoutLoggen(Exception fout)
        {
            using (StreamWriter writer = new StreamWriter("foutenbestand.txt", true))
            {
                writer.WriteLine(fout.GetType().Name);
                writer.WriteLine(fout.Message);
                writer.WriteLine(fout.StackTrace);
            }
        }
    }
}
