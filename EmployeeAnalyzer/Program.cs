using EmployeeAnalyzer;

const string csvPath = "test-employees.csv";

try
{
    var reader = new CsvEmployeeReader();
    var employees = reader.Read(csvPath);

    var validator = new EmployeeValidator();
    var service = new EmployeeService(validator);
    var topEmployees = service.GetTopPaidEmployees(employees);

    if (topEmployees.Count == 0)
    {
        Console.WriteLine("No valid employees found.");
        return 0;
    }

    foreach (var employee in topEmployees)
    {
        Console.WriteLine($"{employee.Name} {employee.Salary}");
    }

    return 0;
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    return 1;
}
catch (Exception ex)
{
    Console.WriteLine($"Error processing CSV file: {ex.Message}");
    return 1;
}
