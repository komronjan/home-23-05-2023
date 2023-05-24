using Domain.Dtos;
using Infrastructure.Services;

var employeesServices = new EmployeesServices();
while (true)
{
    System.Console.WriteLine();
    System.Console.WriteLine($"               Input '{1}' for Show All Employees");
    System.Console.WriteLine($"               Input '{2}' for GetById");
    System.Console.WriteLine($"               Input '{3}' for UpdateEmployee");
    System.Console.WriteLine($"               Input '{4}' for AddEmployee");
    System.Console.WriteLine($"               Input '{5}' for DeleteEmployee");
    System.Console.WriteLine($"               Input '{0}' for Exit Program");
    var t = Convert.ToInt32(Console.ReadLine());
    if (t == 1)
    {
        Show();
        void Show()
        {

            var employees = employeesServices.GetEmployees();
            System.Console.WriteLine($"{"Id",-3}| {"FirstName",-16} | {"LastName",-16} | {"Email",-30} | {"BirthDate",-16}   |");
            System.Console.WriteLine($"------------------------------------------------------------------------------------------------");
            foreach (var employee in employees)
            {
                System.Console.WriteLine($"{employee.Id,-2} | {employee.FirstName,-16} | {employee.LastName,-16} | {employee.Email,-30} | {employee.BirthDate,-16} | ");
            }

        }
    }
    if (t == 2)
    {
        var n = Convert.ToInt32(Console.ReadLine());
        void GetById()
        {
            var employee = employeesServices.GetById(n);
            System.Console.WriteLine($"{"Id",-2} | {"FirstName",-15} | {"LastName",-15} | {"Email",-30} | {"BirthDate",-15}");
            System.Console.WriteLine("----------------------------------------------------------------------------------------------");
            System.Console.WriteLine($"{employee.Id,-2} | {employee.FirstName,-15} | {employee.LastName,-15} | {employee.Email,-30} | {employee.BirthDate,-15} |");
        }
        GetById();

    }
    if (t == 3)
    {
        var dtosEmployee = new DtosEmployee()
        {
            Id = Convert.ToInt32(Console.ReadLine),
            FirstName = Console.ReadLine(),
            LastName = Console.ReadLine(),
            Email = Console.ReadLine(),
            BirthDate = Convert.ToDateTime(Console.ReadLine()),

        };
        void UpdateEmployee()
        {
            employeesServices.UpdateEmployee(dtosEmployee);
        }
        UpdateEmployee();
    }
    if (t == 4)
    {
        var dtosEmployee = new DtosEmployee()
        {
            FirstName = Console.ReadLine(),
            LastName = Console.ReadLine(),
            Email = Console.ReadLine(),
            BirthDate = Convert.ToDateTime(Console.ReadLine()),

        };
        AddEmployee();
        void AddEmployee()
        {
            employeesServices.AddEmployee(dtosEmployee);
        }
    }
    if (t == 5)
    {
        var n = Convert.ToInt32(Console.ReadLine());
        void DeleteEmployee()
        {
            employeesServices.DeleteEmployee(n);
        }
        DeleteEmployee();
    }


    if (t == 0) { break; }
}