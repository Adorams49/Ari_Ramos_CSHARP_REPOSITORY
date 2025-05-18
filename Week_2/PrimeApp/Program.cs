using System;
using PrimeLib;

namespace PrimeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number (max 1000): ");
            int num = int.Parse(Console.ReadLine());

            if (num < 2 || num > 1000)
            {
                Console.WriteLine("Enter a number between 2 and 1000.");
            }
            else
            {
                string result = Factorizer.PrimeFactors(num);
                Console.WriteLine($"Prime factors of {num} are: {result}");
            }
        }
    }
}
