# Employee Analyzer

A .NET console application that analyzes employee data from CSV files and displays the top 5 highest-paid employees.

## Features

- Parse employee data from CSV files
- Validate employee records
- Sort employees by salary
- Display top 5 highest-paid employees
- Gracefully handle invalid data rows
- Support for files up to 100,000 rows

## Requirements

- .NET 10.0 or higher

## Installation

Clone the repository:
```bash
git clone <repository-url>
cd EmployeeAnalyzer
```

## Usage

Run the application with a CSV file path as an argument:

```bash
dotnet run --project EmployeeAnalyzer/EmployeeAnalyzer.csproj <path-to-csv-file>
```

### Example

Given a CSV file `employees.csv`:
```csv
EmployeeId,Name,Salary
1,Alice,5000
2,Bob,8000
3,John,6000
4,Charlie,7500
5,Diana,9000
```

Run the command:
```bash
dotnet run --project EmployeeAnalyzer/EmployeeAnalyzer.csproj employees.csv
```

Output:
```
Diana 9000
Bob 8000
Charlie 7500
John 6000
Alice 5000
```

## CSV Format

The CSV file must have the following columns:
- `EmployeeId` - Integer employee identifier
- `Name` - Employee name (string)
- `Salary` - Employee salary (decimal)

Invalid rows are automatically skipped during processing.

## Architecture

The application follows a layered architecture:

```
Program.cs
    ↓
CsvEmployeeReader - Reads and parses CSV files
    ↓
EmployeeValidator - Validates employee records
    ↓
EmployeeService - Business logic (sorting, filtering)
    ↓
Console Output - Displays results
```

## Running Tests

Execute the unit tests:

```bash
dotnet test
```

## Error Handling

- **File not found**: Displays error message if the CSV file doesn't exist
- **Invalid CSV format**: Skips invalid rows and continues processing
- **Empty file**: Returns message indicating no valid employees found
- **Invalid data**: Rows with missing or malformed data are ignored

## Project Structure

```
EmployeeAnalyzer/
├── EmployeeAnalyzer/           # Main application
│   ├── Employee.cs             # Employee model
│   ├── CsvEmployeeReader.cs    # CSV parsing logic
│   ├── EmployeeValidator.cs    # Validation logic
│   ├── EmployeeService.cs      # Business logic
│   └── Program.cs              # Entry point
├── EmployeeAnalyzer.Tests/     # Unit tests
└── README.md
```

## License

This is a sample project to learn about spec-kit.
