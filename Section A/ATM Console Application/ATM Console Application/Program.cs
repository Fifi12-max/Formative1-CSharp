using System;

class Program
{
    static void Main()
    {
        // Variables
        string name;
        double balance, withdrawal;

        // Ask for account holder name
        Console.Write("Enter account holder name: ");
        name = Console.ReadLine();

        try
        {
            // Ask for current balance
            Console.Write("Enter current balance: ");
            balance = Convert.ToDouble(Console.ReadLine());

            // Ask for withdrawal amount
            Console.Write("Enter withdrawal amount: ");
            withdrawal = Convert.ToDouble(Console.ReadLine());

            // Check if enough balance
            if (withdrawal > balance)
            {
                Console.WriteLine("\nTransaction Failed: Insufficient funds.");
            }
            else
            {
                // Deduct amount
                balance -= withdrawal;

                // Display success message
                Console.WriteLine("\nTransaction Successful!");
                Console.WriteLine("Account Holder: " + name);
                Console.WriteLine("Withdrawn Amount: " + withdrawal);
                Console.WriteLine("Remaining Balance: " + balance);

                // Display current date and time
                Console.WriteLine("Transaction Time: " + DateTime.Now);
            }
        }
        catch
        {
            // Handle invalid input
            Console.WriteLine("Invalid input! Please enter numeric values.");
        }

        Console.ReadLine();
    }
}