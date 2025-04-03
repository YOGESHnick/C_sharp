using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a positive integer: ");
        if (int.TryParse(Console.ReadLine(), out int number) && number >= 0)
        {
            Console.WriteLine($"Factorial of {number} is {Factorial(number)}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
    }

    static long Factorial(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}
