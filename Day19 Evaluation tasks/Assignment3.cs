
//Find the age from entered date of birth

using System;

class Program
{
    static void Main()
    {

        Console.WriteLine("Enter your date of birth:");
        Console.Write("Year: ");
        int birthYear = int.Parse(Console.ReadLine());
        Console.Write("Month (1-12): ");
        int birthMonth = int.Parse(Console.ReadLine());
        Console.Write("Day: ");
        int birthDay = int.Parse(Console.ReadLine());


        DateTime today = DateTime.Now;
        int currentYear = today.Year;
        int currentMonth = today.Month;
        int currentDay = today.Day;


        int age = currentYear - birthYear;


        if (birthMonth > currentMonth || (birthMonth == currentMonth && birthDay > currentDay))
        {
            age--;
        }


        Console.WriteLine($"Your age is: {age} years");
    }
}
