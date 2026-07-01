namespace EmployeeAnalyzer;

public class EmployeeService
{
    private readonly EmployeeValidator _validator;

    public EmployeeService(EmployeeValidator validator)
    {
        _validator = validator;
    }

    public List<Employee> GetTopPaidEmployees(List<Employee> employees, int count = 5)
    {
        var validEmployees = _validator.FilterValid(employees);

        return validEmployees
            .OrderByDescending(e => e.Salary)
            .Take(count)
            .ToList();
    }
}
