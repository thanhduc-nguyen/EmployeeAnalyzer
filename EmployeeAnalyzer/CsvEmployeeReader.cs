using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace EmployeeAnalyzer;

public class CsvEmployeeReader
{
    public List<Employee> Read(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"CSV file not found: {path}");
        }

        var employees = new List<Employee>();

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            MissingFieldFound = null,
            BadDataFound = null
        };

        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, config);

        csv.Read();
        csv.ReadHeader();

        while (csv.Read())
        {
            try
            {
                var employee = new Employee
                {
                    Id = csv.GetField<int>("EmployeeId"),
                    Name = csv.GetField<string>("Name") ?? string.Empty,
                    Salary = csv.GetField<decimal>("Salary")
                };

                employees.Add(employee);
            }
            catch
            {
                // Ignore invalid rows as per requirements
                continue;
            }
        }

        return employees;
    }
}
