using System;
using System.Collections.Generic;

class Employee
{
    public string Name { get; set; }
    public int Salary { get; set; }

    public Employee(string name, int salary)
    {
        Name = name;
        Salary = salary;
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        Console.WriteLine("Personalregister");

        while (true)
        {
            Console.Write("Ange namn (eller skriv exit): ");
            string name = Console.ReadLine();

            if (name.ToLower() == "exit")
            {
                break;
            }

            Console.Write("Ange lön: ");
            int salary = int.Parse(Console.ReadLine());

            employees.Add(new Employee(name, salary));
        }

        Console.WriteLine("\nAnställda:");

        foreach (Employee employee in employees)
        {
            Console.WriteLine($"Namn: {employee.Name}, Lön: {employee.Salary}");
        }
    }
}