using System;

class Program
{
    static void Main()
    {
        // Declare variables
        string studentName;
        double mark1, mark2, mark3, total, average;

        // Ask for student name
        Console.Write("Enter student name: ");
        studentName = Console.ReadLine();

        try
        {
            // Ask for 3 subject marks
            Console.Write("Enter mark 1: ");
            mark1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter mark 2: ");
            mark2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter mark 3: ");
            mark3 = Convert.ToDouble(Console.ReadLine());

            // Calculate total
            total = mark1 + mark2 + mark3;

            // Calculate average
            average = total / 3;

            // Determine PASS or FAIL
            string result;
            if (average >= 50)
            {
                result = "PASS";
            }
            else
            {
                result = "FAIL";
            }

            // Display results
            Console.WriteLine("\n===== STUDENT RESULTS =====");
            Console.WriteLine("Name: " + studentName);
            Console.WriteLine("Total: " + total);
            Console.WriteLine("Average: " + Math.Round(average));
            Console.WriteLine("Result: " + result);
        }
        catch
        {
            // Error handling if user enters text instead of numbers
            Console.WriteLine("Invalid input! Please enter numeric values only.");
        }

        Console.ReadLine();
    }
}