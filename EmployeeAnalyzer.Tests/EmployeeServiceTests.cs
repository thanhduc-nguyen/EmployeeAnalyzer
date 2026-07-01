using EmployeeAnalyzer;

namespace EmployeeAnalyzer.Tests;

public class EmployeeServiceTests
{
    private readonly EmployeeService _service;

    public EmployeeServiceTests()
    {
        var validator = new EmployeeValidator();
        _service = new EmployeeService(validator);
    }

    [Fact]
    public void GetTopPaidEmployees_ReturnsTop5BySalary()
    {
        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Salary = 5000 },
            new Employee { Id = 2, Name = "Bob", Salary = 8000 },
            new Employee { Id = 3, Name = "John", Salary = 6000 },
            new Employee { Id = 4, Name = "Diana", Salary = 9000 },
            new Employee { Id = 5, Name = "Eve", Salary = 7000 },
            new Employee { Id = 6, Name = "Frank", Salary = 4000 }
        };

        var result = _service.GetTopPaidEmployees(employees);

        Assert.Equal(5, result.Count);
        Assert.Equal("Diana", result[0].Name);
        Assert.Equal(9000, result[0].Salary);
        Assert.Equal("Bob", result[1].Name);
        Assert.Equal("Eve", result[2].Name);
        Assert.Equal("John", result[3].Name);
        Assert.Equal("Alice", result[4].Name);
    }

    [Fact]
    public void GetTopPaidEmployees_FewerThan5Employees_ReturnsAll()
    {
        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Salary = 5000 },
            new Employee { Id = 2, Name = "Bob", Salary = 8000 }
        };

        var result = _service.GetTopPaidEmployees(employees);

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void GetTopPaidEmployees_FiltersInvalidEmployees()
    {
        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Salary = 5000 },
            new Employee { Id = 0, Name = "Invalid", Salary = 10000 },
            new Employee { Id = 2, Name = "Bob", Salary = 8000 }
        };

        var result = _service.GetTopPaidEmployees(employees);

        Assert.Equal(2, result.Count);
        Assert.DoesNotContain(result, e => e.Name == "Invalid");
    }

    [Fact]
    public void GetTopPaidEmployees_EmptyList_ReturnsEmpty()
    {
        var employees = new List<Employee>();

        var result = _service.GetTopPaidEmployees(employees);

        Assert.Empty(result);
    }
}
