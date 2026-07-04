//Input password and Find the Password strength based on following rules
//Length should be 8
//Must have one capital letter
//One digit is compulsory   

using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your password: ");
        string pd = Console.ReadLine();


        bool isStrong = CheckPasswordStrength(pd);

        if (isStrong)
        {
            Console.WriteLine("Password is STRONG (all rules met).");
        }
        else
        {
            Console.WriteLine("Password is WEAK. Please follow the rules.");
        }
    }

    static bool CheckPasswordStrength(string pwd)
    {
        bool hasValidLength = (pwd.Length == 8);
        bool hasUpperCase = false;
        bool hasDigit = false;


        foreach (char ch in pwd)
        {
            if (char.IsUpper(ch))
                hasUpperCase = true;
            if (char.IsDigit(ch))
                hasDigit = true;
        }


        Console.WriteLine("\n Password Rules Check:");
        Console.WriteLine($"Length exactly 8 characters: {(hasValidLength ? "OK" : "FAIL")}");
        Console.WriteLine($"At least one uppercase letter: {(hasUpperCase ? "OK" : "FAIL")}");
        Console.WriteLine($"At least one digit: {(hasDigit ? "OK" : "FAIL")}");


        return hasValidLength && hasUpperCase && hasDigit;
    }
}
