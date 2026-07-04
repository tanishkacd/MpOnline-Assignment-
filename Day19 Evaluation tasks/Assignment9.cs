//Write a C# program that prits numbers from 1 to 50, but with these rules:

//If the number is divisible by 3, print "3".
//If the number is divisible by 5, print "5".
//If the number is divisible by both 3 and 5, print "3-5".
//If the number is prime, print "Prime".
//Otherwise, just print the number itself.


using System;

class Program
{
    static void Main()
    {
        for (int i = 1; i <= 50; i++)
        {
            string output = "";


            if (i % 3 == 0 && i % 5 == 0)
                output = "3-5";
            else if (i % 3 == 0)
                output = "3";
            else if (i % 5 == 0)
                output = "5";
            else if (IsPrime(i))
                output = "Prime";
            else
                output = i.ToString();

            Console.WriteLine(output);
        }
    }


    static bool IsPrime(int num)
    {
        if (num < 2) return false;
        for (int d = 2; d * d <= num; d++)
            if (num % d == 0)
                return false;
        return true;
    }
}
