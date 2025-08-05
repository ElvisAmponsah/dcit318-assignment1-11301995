using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Movie Ticket Price Calculator ===");
        Console.WriteLine("Let's figure out how much your ticket will cost.");
        Console.WriteLine("Type 'exit' to quit the program.\n");

        while (true)
        {
            try
            {
                int customerAge = GetCustomerAge();
                if (customerAge == -1) break;

                Console.WriteLine($"Age entered: {customerAge}");

                decimal ticketPrice = CalculateTicketPrice(customerAge);
                string ageCategory = GetAgeCategory(customerAge);
                
                Console.WriteLine($"Age Category: {ageCategory}");
                Console.WriteLine($"Ticket Price: GHC{ticketPrice}");

                Console.Write("\nWould you like to calculate another ticket price? (y/n): ");
                string? continueInput = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(continueInput) || 
                    continueInput.ToLower() != "y" && continueInput.ToLower() != "yes")
                {
                    Console.WriteLine("Thanks for using Movie Ticket Price Calculator! Goodbye!");
                    break;
                }
                
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.WriteLine("Please try again.\n");
            }
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static int GetCustomerAge()
    {
        while (true)
        {
            Console.Write("Please enter your age: ");
            string? ageInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ageInput) || ageInput.ToLower() == "exit")
            {
                Console.WriteLine("Goodbye!");
                return -1;
            }

            if (int.TryParse(ageInput, out int customerAge))
            {
                if (customerAge > 0 && customerAge < 130)
                {
                    return customerAge;
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid age between 1 and 130.");
                }
            }
            else
            {
                Console.WriteLine("Error: That wasn't a valid number. Please try again.");
            }
        }
    }

    static decimal CalculateTicketPrice(int age)
    {
        if (age <= 12 || age >= 65)
        {
            return 7.00m;
        }
        else
        {
            return 10.00m;
        }
    }

    static string GetAgeCategory(int age)
    {
        return age switch
        {
            <= 12 => "Child (12 and under) - Discount Applied",
            >= 65 => "Senior (65 and over) - Discount Applied", 
            _ => "Regular (13-64) - Standard Price"
        };
    }
}