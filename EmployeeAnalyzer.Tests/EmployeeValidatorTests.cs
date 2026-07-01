using EmployeeAnalyzer;

namespace EmployeeAnalyzer.Tests;

public class EmployeeValidatorTests
{
    private readonly EmployeeValidator _validator;

    public EmployeeValidatorTests()
    {
        _validator = new EmployeeValidator();
    }

    [Fact]
    public void IsValid_ValidEmployee_ReturnsTrue()
    {
        var employee = new Employee { Id = 1, Name = "John", Salary = 5000 };

        var result = _validator.IsValid(employee);

        Assert.True(result);
    }

    [Fact]
    public void IsValid_NullEmployee_ReturnsFalse()
    {
        var result = _validator.IsValid(null!);

        Assert.False(result);
    }

    [Fact]
    public void IsValid_InvalidId_ReturnsFalse()
    {
        var employee = new Employee { Id = 0, Name = "John", Salary = 5000 };

        var result = _validator.IsValid(employee);

        Assert.False(result);
    }

    [Fact]
    public void IsValid_EmptyName_ReturnsFalse()
    {
        var employee = new Employee { Id = 1, Name = "", Salary = 5000 };

        var result = _validator.IsValid(employee);

        Assert.False(result);
    }

    [Fact]
    public void IsValid_NegativeSalary_ReturnsFalse()
    {
        var employee = new Employee { Id = 1, Name = "John", Salary = -100 };

        var result = _validator.IsValid(employee);

        Assert.False(result);
    }

    [Fact]
    public void FilterValid_MixedEmployees_ReturnsOnlyValid()
    {
        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John", Salary = 5000 },
            new Employee { Id = 0, Name = "Invalid", Salary = 3000 },
            new Employee { Id = 2, Name = "Jane", Salary = 6000 }
        };

        var result = _validator.FilterValid(employees);

        Assert.Equal(2, result.Count);
        Assert.Contains(result, e => e.Name == "John");
        Assert.Contains(result, e => e.Name == "Jane");
    }
}
