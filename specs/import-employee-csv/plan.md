# Technical Plan

## Architecture

Program.cs
    ↓
CsvEmployeeReader
    ↓
EmployeeValidator
    ↓
EmployeeService
    ↓
ConsoleOutput

## Classes

Employee
- Id
- Name
- Salary

CsvEmployeeReader
- Read(string path)

EmployeeService
- GetTopPaidEmployees()

## Libraries
- CsvHelper

## Error Handling
- File not found
- Invalid CSV format
- Empty file