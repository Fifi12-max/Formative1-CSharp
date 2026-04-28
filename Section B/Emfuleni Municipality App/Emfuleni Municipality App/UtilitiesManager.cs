using System;
using System.Collections.Generic;

public class UtilitiesManager
{
    public List<ServiceRequest> requests = new List<ServiceRequest>();
    public List<ServiceRequest> processed = new List<ServiceRequest>();

    public void AddRequest(ServiceRequest request)
    {
        requests.Add(request);
    }

    public void DisplayQueue()
    {
        Console.WriteLine("\n--- Pending Requests ---");

        for (int i = 0; i < requests.Count; i++)
        {
            var r = requests[i];
            Console.WriteLine($"{i + 1}. {r.RequestType} | {r.Resident.Name} | Urgency: {r.CalculateUrgency()}");
        }
    }

    public void ProcessRequest(int index)
    {
        var req = requests[index];
        processed.Add(req);
        requests.RemoveAt(index);

        Console.WriteLine("\n==== Service Report ====");
        Console.WriteLine($"Resident: {req.Resident.Name}");
        Console.WriteLine($"Service Type: {req.RequestType}");
        Console.WriteLine($"Urgency Score: {req.CalculateUrgency()}");
        Console.WriteLine($"Adjusted Resolution: {req.AdjustedResolution()} hours");
        Console.WriteLine($"Household Impact Score: {req.HouseholdImpact():0.00}");
    }

    public void ShowSummary()
    {
        Console.WriteLine("\n==== FINAL MUNICIPAL SUMMARY ====");

        int maxUrgency = 0;
        ServiceRequest highest = null;

        foreach (var r in processed)
        {
            if (r.CalculateUrgency() > maxUrgency)
            {
                maxUrgency = r.CalculateUrgency();
                highest = r;
            }
        }

        if (highest != null)
        {
            Console.WriteLine("Highest priority issue:");
            Console.WriteLine($"Resident: {highest.Resident.Name}");
            Console.WriteLine($"Service Type: {highest.RequestType}");
            Console.WriteLine($"Urgency Score: {highest.CalculateUrgency()}");
            Console.WriteLine($"Adjusted Resolution: {highest.AdjustedResolution()} hours");
            Console.WriteLine($"Household Impact Score: {highest.HouseholdImpact():0.00}");
        }

        Console.WriteLine("\nThank you for using the Emfuleni Municipality Service Desk.");
    }
}