using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("==== Welcome to Emfuleni Municipality Service Desk ====");

        List<Resident> residents = new List<Resident>();
        UtilitiesManager manager = new UtilitiesManager();

        // STEP 1: Capture Residents
        
        Console.Write("How many residents do you want to register? ");
        int resCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < resCount; i++)
        {
            Console.WriteLine($"\n--- Resident {i + 1} ---");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Account Number: ");
            string acc = Console.ReadLine();

            Console.Write("Monthly Utility Usage : ");
            double usage = double.Parse(Console.ReadLine());

            residents.Add(new Resident(name, address, acc, usage));
        }

       
        // STEP 2: Capture Requests
     
        Console.Write("\nHow many service requests do you want to log? ");
        int reqCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < reqCount; i++)
        {
            Console.WriteLine($"\n--- Service Request {i + 1} ---");

            // Show residents
            Console.WriteLine("Select resident by number:");
            for (int j = 0; j < residents.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {residents[j].Name}");
            }

            int resIndex;
            while (true)
            {
                resIndex = int.Parse(Console.ReadLine()) - 1;

                if (resIndex >= 0 && resIndex < residents.Count)
                    break;

                Console.WriteLine("Invalid selection. Try again:");
            }

            Console.Write("Request Type: ");
            string type = Console.ReadLine();

            Console.Write("Priority Level (1–5): ");
            int priority = int.Parse(Console.ReadLine());

            Console.Write("Severity Level (1–10): ");
            int severity = int.Parse(Console.ReadLine());

            Console.Write("Estimated Resolution Hours: ");
            int hours = int.Parse(Console.ReadLine());

            manager.AddRequest(new ServiceRequest(type, priority, severity, hours, residents[resIndex]));
        }

        // STEP 3: Process Requests
       
        while (manager.requests.Count > 0)
        {
            manager.DisplayQueue();

            int choice;
            while (true)
            {
                Console.Write("Choose request to process: ");
                choice = int.Parse(Console.ReadLine()) - 1;

                if (choice >= 0 && choice < manager.requests.Count)
                    break;

                Console.WriteLine("Invalid choice. Try again.");
            }

            manager.ProcessRequest(choice);
        }

     
        // STEP 4: Summary
       
        manager.ShowSummary();

        Console.ReadLine();
    }
}