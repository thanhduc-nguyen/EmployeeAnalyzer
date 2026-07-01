namespace EmployeeAnalyzer;

public class EmployeeValidator
{
    public bool IsValid(Employee employee)
    {
        if (employee == null)
            return false;

        if (employee.Id <= 0)
            return false;

        if (string.IsNullOrWhiteSpace(employee.Name))
            return false;

        if (employee.Salary < 0)
            return false;

        return true;
    }

    public List<Employee> FilterValid(List<Employee> employees)
    {
        return employees.Where(IsValid).ToList();
    }
}
