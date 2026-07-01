using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
    public DateTime JoiningDate { get; set; }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 103, Name = "Alice", Salary = 50000, JoiningDate = new DateTime(2021, 5, 10) },
            new Employee { Id = 101, Name = "Bob", Salary = 60000, JoiningDate = new DateTime(2020, 3, 15) },
            new Employee { Id = 102, Name = "Charlie", Salary = 45000, JoiningDate = new DateTime(2022, 1, 20) }
        };

        Console.WriteLine("Sort by: 1-Salary 2-JoiningDate 3-EmployeeId");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                employees.Sort((e1, e2) => e1.Salary.CompareTo(e2.Salary));
                Console.WriteLine("Sorted by Salary (Ascending):");
                break;
            case "2":
                employees.Sort((e1, e2) => e1.JoiningDate.CompareTo(e2.JoiningDate));
                Console.WriteLine("Sorted by Joining Date (Oldest first):");
                break;
            case "3":
                employees.Sort((e1, e2) => e1.Id.CompareTo(e2.Id));
                Console.WriteLine("Sorted by Employee ID (Ascending):");
                break;
            default:
                Console.WriteLine("Invalid choice");
                return;
        }

        foreach (var e in employees)
            Console.WriteLine($"{e.Id} {e.Name} {e.Salary} {e.JoiningDate.ToShortDateString()}");
    }
}
