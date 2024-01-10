using consoleapp.Models;
using System.Drawing;
using System.IO;
using Console = Colorful.Console;

List<Employee> employees = FileOperations.ShowEmployees();
List<Branch> branches = FileOperations.ShowBranches();
List<Department> departments = FileOperations.ShowDeparments();

DisplayLogo();
DisplayWelcomeMessage();
Menu();



void DisplayWelcomeMessage()
{
    Console.WriteLine("Welcome to the Dunder Mifflin Inc, Paper Company Information System!");
    Console.WriteLine();
    Console.WriteLine("We're delighted to have you here! This system is your gateway to explore and " +
        "stay connected with the vibrant community at Dunder Mifflin Inc. Here, you can find valuable " +
        "information about your colleagues, their roles, and the various departments that make our " +
        "workplace unique.");
    Console.WriteLine();
    Console.WriteLine("Feel free to browse through the profiles, learn more about your fellow team " +
        "members, and discover the diverse talents that contribute to the success of our office. ");
    Console.WriteLine();
    Console.WriteLine("If you have any questions or need assistance, don't hesitate to reach out " +
        "to the IT department. Thank you for being a valuable part of the Dunder Mifflin family. " +
        "Together, we make our workplace extraordinary!");
    Console.WriteLine();
    Console.WriteLine("Best regards,");
    Console.WriteLine("Dunder Mifflin Inc IT");
}


void Menu()
{
    Console.WriteLine();
    string[] menu = new string[] {"Exit program", "Branch database", "Employee Database", "Department Database" };
    int choiceMenu = LeesMenu(menu, "Choose an option: ");
    Console.Clear();
    switch (choiceMenu)
    {
        case 1:
            DisplayLogoBranch();
            Branches();
            Menu();
            break;
        case 2:
            DisplayLogoEmployee();
            Employees();
            Menu();
            break;

        case 3:
            DisplayLogoDepartments();
            Deparments();
            string[] DepartmentMenu = new string[] { "Go Back", "Look at a department", "Add employee to a department", "Remove employee from department"};
            int choiceDepartmentMenu = LeesMenu(DepartmentMenu, "\nChoose an option: ");
            switch (choiceDepartmentMenu)
            {
                case 1:
                    int departmentChoice = LeesGetalMinMax("\nChoose a department: ", 1, departments.Count);
                    Department chosenDepartment = departments[departmentChoice - 1];
                    Console.WriteLine($"Head of {chosenDepartment.Name}: {chosenDepartment.Head}");
                    foreach (Employee employee in chosenDepartment.Employees)
                    {
                        Console.WriteLine($"\nID: {employee.Id}");
                        Console.WriteLine($"Name: {employee.Name}");
                        Console.WriteLine($"Function: {employee.Function}");
                    }
                    break;
                case 2:
                    int departmentChoice1 = LeesGetalMinMax("\nChoose a department: ", 1, departments.Count);
                    Department chosenDepartment1 = departments[departmentChoice1 - 1];
                    Console.WriteLine("Add employee to a department");
                    Employees();
                    int addEmployeeChoice = LeesGetalMinMax("\nChoose a employee: ", 1, employees.Count);
                    Employee chosenEmployeeDepartment = employees[addEmployeeChoice - 1];
                    chosenDepartment1.AddEmployee(chosenEmployeeDepartment);
                    break;
                case 3:
                    int departmentChoice2 = LeesGetalMinMax("\nChoose a department: ", 1, departments.Count);
                    Department chosenDepartment2 = departments[departmentChoice2 - 1];
                    Console.WriteLine("Remove employee to a department");
                    foreach (Employee employee in chosenDepartment2.Employees)
                    {
                        Console.WriteLine($"\nID: {employee.Id}");
                        Console.WriteLine($"Name: {employee.Name}");
                        Console.WriteLine($"Function: {employee.Function}");
                    }
                    int addEmployeeChoice2 = LeesGetalMinMax("\nChoose a employee: ", 1, employees.Count);
                    Employee chosenEmployeeDepartment2 = employees[addEmployeeChoice2 - 1];
                    chosenDepartment2.RemoveEmployee(chosenEmployeeDepartment2);
                    break;
            }
            Menu();
            break; 
    }
}

void AddEmployee(Department chosenDepartment)
{
    int employeeId;

    employeeId = employees.Count + 1;

    Console.Clear();

    string firstname = LeesStringNietLeeg("Enter the first name: ");
    string lastname = LeesStringNietLeeg("Enter the last name: ");
    DateTime birthdate = LeesDateTime("Enter their birthdate (dd-mm-yyyy): ");

    string street = LeesStringNietLeeg("Enter their street address: ");
    string city = LeesStringNietLeeg("Enter their city: ");
    string state = LeesStringNietLeeg("Enter their state: ");
    string postalCode = LeesStringNietLeeg("Enter their postal code: ");

    int leesGetal = LeesGetal("Enter their employeeId: ");
    string department = LeesStringNietLeeg("Enter their department: ");
    string function = LeesStringNietLeeg("Enter their function: ");
    Address address = new Address(street, city, state, postalCode);
    Employee employee = new Employee(employeeId, firstname, lastname, birthdate, address, employeeId, department, function);

    chosenDepartment.AddEmployee(employee);
    Employees();

}
void DeleteEmployees(List<Employee> employees)
{
    Console.Clear();
    Employees();

    int employeeId = LeesGetal("Enter the employee Id you want to remove: ");


    for (int i = 0; i < employees.Count; i++)
    {
        if (employees[i].Id == employeeId)
        {
            employees.Remove(employees[i]);
        }
    }

    foreach (Employee employee in employees)
    {
        if (employee.Id >= employeeId)
        {
            employee.Id--;
        }
    }
    Employees();

}

void Branches()
{

    Console.WriteLine();
    foreach (Branch branch in branches)
    {
        Console.WriteLine(branch.DisplayInformation());
    }
}

void Employees()
{
    Console.WriteLine();
    foreach (Employee employee in employees)
    {
        Console.WriteLine(employee.DisplayInformation());
    }
}

void Deparments()
{
    Console.WriteLine();
    List<Department> departments = FileOperations.ShowDeparments();
    foreach (Department deparment in departments)
    {
        Console.WriteLine(deparment.DisplayInformation());
    }
}

int LeesGetal(string vraag)
{
    string invoer;
    int getal;
    do
    {
        Console.Write(vraag);
        invoer = Console.ReadLine();
    } while (!int.TryParse(invoer, out getal));
    return getal;
}

string LeesStringNietLeeg(string vraag)
{
    string invoer;
    do
    {
        Console.Write(vraag);
        invoer = Console.ReadLine();
    } while (string.IsNullOrEmpty(invoer));
    return invoer;
}
DateTime LeesDateTime(string vraag)
{
    DateTime invoer;
    do
    {
        Console.Write(vraag);
    } while (!DateTime.TryParse(Console.ReadLine(), out invoer));
    return invoer;
}

int LeesGetalMinMax(string vraag, int min, int max)
{
    int getal;
    do
    {
        getal = LeesGetal(vraag);
    } while (getal<min || getal > max);
    return getal;
}

int LeesMenu(string[] menu, string vraag)
{
    for (int i = 0; i < menu.Length ; i++)
    {
        Console.WriteLine($"{i}:{menu[i]}");
    }
    int getal = LeesGetalMinMax(vraag,0,menu.Length -1);
    return getal;
}

void DisplayLogo()
{
    string logo = @" 
  _____                  _             __  __ _  __  __ _ _       
 |  __ \                | |           |  \/  (_)/ _|/ _| (_)      
 | |  | |_   _ _ __   __| | ___ _ __  | \  / |_| |_| |_| |_ _ __  
 | |  | | | | | '_ \ / _` |/ _ \ '__| | |\/| | |  _|  _| | | '_ \ 
 | |__| | |_| | | | | (_| |  __/ |    | |  | | | | | | | | | | | |
 |_____/ \__,_|_| |_|\__,_|\___|_|    |_|  |_|_|_| |_| |_|_|_| |_|
                                                                  
                                                                  
";
    Console.WriteLine(logo,Color.LightBlue); ;
}
void DisplayLogoBranch()
{
    string logo = @"

  ____                       _               
 |  _ \                     | |              
 | |_) |_ __ __ _ _ __   ___| |__   ___  ___ 
 |  _ <| '__/ _` | '_ \ / __| '_ \ / _ \/ __|
 | |_) | | | (_| | | | | (__| | | |  __/\__ \
 |____/|_|  \__,_|_| |_|\___|_| |_|\___||___/

                                 
";
    Console.WriteLine(logo, Color.Magenta); ;
}

void DisplayLogoEmployee()
{
    string logo = @"

 
  ______                 _                            
 |  ____|               | |                           
 | |__   _ __ ___  _ __ | | ___  _   _  ___  ___  ___ 
 |  __| | '_ ` _ \| '_ \| |/ _ \| | | |/ _ \/ _ \/ __|
 | |____| | | | | | |_) | | (_) | |_| |  __/  __/\__ \
 |______|_| |_| |_| .__/|_|\___/ \__, |\___|\___||___/
                  | |             __/ |               
                  |_|            |___/                
                                 
";
    Console.WriteLine(logo, Color.Cyan); ;
}

void DisplayLogoDepartments()
{
    string logo = @"
  _____                        _                        _       
 |  __ \                      | |                      | |      
 | |  | | ___ _ __   __ _ _ __| |_ _ __ ___   ___ _ __ | |_ ___ 
 | |  | |/ _ \ '_ \ / _` | '__| __| '_ ` _ \ / _ \ '_ \| __/ __|
 | |__| |  __/ |_) | (_| | |  | |_| | | | | |  __/ | | | |_\__ \
 |_____/ \___| .__/ \__,_|_|   \__|_| |_| |_|\___|_| |_|\__|___/
             | |                                                
             |_|                                                     
                                 
";
    Console.WriteLine(logo, Color.Cyan); ;
}
