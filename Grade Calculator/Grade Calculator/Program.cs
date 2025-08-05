using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Grade Checker ===");
        Console.WriteLine("Hi there! Let's figure out your letter grade.");
        Console.WriteLine("Type 'exit' to quit the program.\n");

        while (true)
        {
            try
            {
                Console.Write("Please type your grade (0 to 100): ");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "exit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                if (!int.TryParse(input, out int gradeInput))
                {
                    Console.WriteLine("Error: That doesn't look like a valid number. Please try again.");
                    continue;
                }

                if (gradeInput < 0 || gradeInput > 100)
                {
                    Console.WriteLine("Error: Grade must be between 0 and 100. Please try again.");
                    continue;
                }

                Console.WriteLine($"Grade received: {gradeInput}");

                string letterGrade = GetLetterGrade(gradeInput);
                Console.WriteLine($"Letter Grade: {letterGrade}");

                string gradeDescription = GetGradeDescription(letterGrade);
                Console.WriteLine($"{gradeDescription}\n");

                Console.Write("Would you like to check another grade? (y/n): ");
                string? continueInput = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(continueInput) || 
                    continueInput.ToLower() != "y" && continueInput.ToLower() != "yes")
                {
                    Console.WriteLine("Thanks for using Grade Checker! Goodbye!");
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

    static string GetLetterGrade(int grade)
    {
        return grade switch
        {
            >= 90 => "A",
            >= 80 => "B", 
            >= 70 => "C",
            >= 60 => "D",
            _ => "F"
        };
    }

    static string GetGradeDescription(string letterGrade)
    {
        return letterGrade switch
        {
            "A" => "Excellent! Outstanding performance.",
            "B" => "Good work! Above average performance.",
            "C" => "Satisfactory. Meets basic requirements.",
            "D" => "Below average. Needs improvement.",
            "F" => "Failing. Significant improvement needed.",
            _ => "Unknown grade."
        };
    }
}