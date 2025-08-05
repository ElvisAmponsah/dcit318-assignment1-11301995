using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Triangle Type Identifier ===");
        Console.WriteLine("Enter the three side lengths to determine the triangle type.");
        Console.WriteLine("Type 'exit' to quit the program.\n");

        while (true)
        {
            try
            {
                double a = GetSideLength("A");
                if (a == -1) break;

                double b = GetSideLength("B");
                if (b == -1) break;

                double c = GetSideLength("C");
                if (c == -1) break;

                if (IsValidTriangle(a, b, c))
                {
                    Console.WriteLine($"Sides entered: A={a}, B={b}, C={c}");
                    
                    string triangleType = GetTriangleType(a, b, c);
                    Console.WriteLine($"Triangle Type: {triangleType}");
                    
                    Console.Write("\nWould you like to check another triangle? (y/n): ");
                    string? continueInput = Console.ReadLine();
                    
                    if (string.IsNullOrWhiteSpace(continueInput) || 
                        continueInput.ToLower() != "y" && continueInput.ToLower() != "yes")
                    {
                        Console.WriteLine("Thanks for using Triangle Type Identifier! Goodbye!");
                        break;
                    }
                    
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Error: These sides don't form a valid triangle. Please try again.\n");
                }
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

    static double GetSideLength(string sideName)
    {
        while (true)
        {
            Console.Write($"Side {sideName}: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "exit")
            {
                Console.WriteLine("Goodbye!");
                return -1;
            }

            if (double.TryParse(input, out double side))
            {
                if (side > 0)
                {
                    return side;
                }
                else
                {
                    Console.WriteLine("Error: Side length must be positive. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
        }
    }

    static bool IsValidTriangle(double a, double b, double c)
    {
        return (a + b > c) && (a + c > b) && (b + c > a);
    }

    static string GetTriangleType(double a, double b, double c)
    {
        if (a == b && b == c)
        {
            return "Equilateral triangle - All sides are equal";
        }
        else if (a == b || a == c || b == c)
        {
            return "Isosceles triangle - Two sides are equal";
        }
        else
        {
            return "Scalene triangle - All sides are different";
        }
    }
}