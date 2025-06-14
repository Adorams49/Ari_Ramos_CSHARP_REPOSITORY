using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            // Setup: City list and simulated random database
            List<string> cityList = new List<string>
            {
                "London", "Paris", "Tokyo", "New York", "Berlin",
                "Madrid", "Sydney", "Toronto", "Rome", "Cairo"
            };

            List<string> companyWords = new List<string>
            {
                "Global", "Solutions", "Tech", "Imports", "Foods", "Logistics",
                "Dynamics", "Partners", "Express", "Beverages", "Industries", "Group"
            };

            Random rnd = new Random();
            List<Customer> customers = new List<Customer>();

            foreach (var city in cityList)
            {
                int numCompanies = rnd.Next(4, 9); // 4 to 8 companies
                for (int i = 0; i < numCompanies; i++)
                {
                    string word1, word2;
                    do
                    {
                        word1 = companyWords[rnd.Next(companyWords.Count)];
                        word2 = companyWords[rnd.Next(companyWords.Count)];
                    } while (word1 == word2); // Avoid duplicates

                    string companyName = $"{word1} {word2}";
                    customers.Add(new Customer { City = city, CompanyName = companyName });
                }
            }

            bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("--------------- Welcome to the Northwind Viewer ---------------\n");
                Console.WriteLine("Here are the cities with customer records:\n");

                for (int i = 0; i < cityList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {cityList[i]}");
                }

                Console.WriteLine("\n---------------------------------------------------------------");
                Console.Write("Enter the number of the city you'd like to view: ");
                string input = Console.ReadLine();
                Console.WriteLine("---------------------------------------------------------------");

                if (!int.TryParse(input, out int choice) || choice < 1 || choice > cityList.Count)
                {
                    Console.WriteLine("Invalid input. Press any key to try again...");
                    Console.ReadKey();
                    continue;
                }

                string selectedCity = cityList[choice - 1];
                var cityCustomers = customers
                    .Where(c => c.City == selectedCity)
                    .Select(c => c.CompanyName)
                    .ToList();

                Console.WriteLine($"\n--------------- Customers in {selectedCity} ---------------");
                Console.WriteLine($"There are {cityCustomers.Count} customers in {selectedCity}:\n");

                foreach (var company in cityCustomers)
                {
                    Console.WriteLine($"- {company}");
                }

                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("\nPress 'R' to choose another city or any other key to exit...");
                var key = Console.ReadKey().Key;
                if (key != ConsoleKey.R)
                {
                    repeat = false;
                }
            }
        }
    }
}