using System;
using System.Text;

public class CitizenProfile
{
    public string FullName { get; set; }
    public string IDNumber { get; set; }
    public int Age { get; set; }
    public string CitizenshipStatus { get; set; }

    public CitizenProfile(string name, string id, string status)
    {
        FullName = name;
        IDNumber = id;
        CitizenshipStatus = status;
        if (ValidateID() == "ID is valid.")
        {
            Age = CalculateAge();
        }
        else
        {
            Age = 0;
        }
    }

    private int CalculateAge()
    {
        try
        {
            string yearPart = IDNumber.Substring(0, 2);
            string monthPart = IDNumber.Substring(2, 2);
            string dayPart = IDNumber.Substring(4, 2);

            int year = int.Parse(yearPart);
            int month = int.Parse(monthPart);
            int day = int.Parse(dayPart);

            int fullYear = (year > DateTime.Now.Year % 100) ? 1900 + year : 2000 + year;

            DateTime birthDate = new DateTime(fullYear, month, day);

            int age = DateTime.Now.Year - birthDate.Year;

            if (DateTime.Now < birthDate.AddYears(age))
                age--;

            return age;
        }
        catch
        {
            return 0;
        }
    }

    public string ValidateID()
    {
        // Check length
        if (IDNumber.Length != 13)
            return "Invalid ID: Must be 13 digits.";

        // Check numeric
        if (!long.TryParse(IDNumber, out _))
            return "Invalid ID: Must be numeric.";

        try
        {
            // Extract date parts
            string yearPart = IDNumber.Substring(0, 2);
            string monthPart = IDNumber.Substring(2, 2);
            string dayPart = IDNumber.Substring(4, 2);

            int year = int.Parse(yearPart);
            int month = int.Parse(monthPart);
            int day = int.Parse(dayPart);

            // Determine full year
            int fullYear = (year > DateTime.Now.Year % 100) ? 1900 + year : 2000 + year;

            // Validate date
            DateTime birthDate = new DateTime(fullYear, month, day);

            return "ID is valid.";
        }
        catch
        {
            return "Invalid ID: Date of birth is incorrect.";
        }
    }

   
    public string GetValidationMessage()
    {
        string validationResult = ValidateID();

        if (validationResult == "ID is valid.")
        {
            return $"Valid ID. Citizen is {Age} years old.";
        }
        else
        {
            return validationResult;   
        }
    }

    
    public string GenerateProfileSummary()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("==== DIGITAL CITIZEN SUMMARY ====");
        sb.AppendLine($"Name: {FullName}");
        sb.AppendLine($"ID Number: {IDNumber}");
        sb.AppendLine($"Age: {Age}");
        sb.AppendLine($"Citizenship: {CitizenshipStatus}");
        sb.AppendLine($"Validation: {GetValidationMessage()}");
        sb.AppendLine("Processed at: Home Affairs Digital Desk");
        sb.AppendLine($"Timestamp: {DateTime.Now:yyyy/MM/dd HH:mm:ss}");

        return sb.ToString().TrimEnd();
    }


}