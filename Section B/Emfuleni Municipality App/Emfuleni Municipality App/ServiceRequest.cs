public class ServiceRequest
{
    public string RequestType { get; set; }
    public int Priority { get; set; }
    public int Severity { get; set; }
    public int EstimatedHours { get; set; }
    public Resident Resident { get; set; }

    public ServiceRequest(string type, int priority, int severity, int hours, Resident resident)
    {
        RequestType = type;
        Priority = priority;
        Severity = severity;
        EstimatedHours = hours;
        Resident = resident;
    }

    public int CalculateUrgency()
    {
        return Priority * Severity;
    }
    public int AdjustedResolution()
    {
     
        return EstimatedHours + Priority;
    }

    public double HouseholdImpact()
    {
        return Resident.MonthlyUsage * 0.8;
    }
}
