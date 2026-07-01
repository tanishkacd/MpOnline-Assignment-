using System;

class Program
{
    static void Main()
    {
        // 1. Logical Operators
        bool a1 = true, b1 = false;

        Console.WriteLine("1)");
        Console.WriteLine(a1 && b1);
        Console.WriteLine(a1 || b1);
        Console.WriteLine(!a1);

        // 2. Pre and Post Increment
        int a2 = 5;

        Console.WriteLine("\n2)");
        Console.WriteLine(++a2);
        Console.WriteLine(a2++);
        Console.WriteLine(a2);

        // 3. Integer Division
        int a3 = 7;
        int b3 = 2;

        Console.WriteLine("\n3)");
        Console.WriteLine(a3 / b3 * b3);

        // 4. Combination of Post and Pre Increment
        int x = 5;

        Console.WriteLine("\n4)");
        Console.WriteLine(x++ + ++x);

        // 5. Logical Expression
        bool a5 = true;
        bool b5 = false;

        Console.WriteLine("\n5)");
        Console.WriteLine(a5 || b5 && !a5);

        // 6. Compound Assignment Operators
        int num = 10;

        num += 5;
        num -= 3;
        num *= 2;

        Console.WriteLine("\n6)");
        Console.WriteLine(num);

        // 7. Modulus Logic
        int result = (17 % 5) * (20 % 6);

        Console.WriteLine("\n7)");
        Console.WriteLine(result);
    }
}
