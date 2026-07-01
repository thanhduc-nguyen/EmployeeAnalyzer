# Feature: Import Employee CSV

## Goal
Allow users to load employee information from a CSV file and display the top 5 highest-paid employees.

## User Story
As a HR user,
I want to import employee data from a CSV file,
So that I can quickly identify the highest-paid employees.

## Requirements

### Functional
1. Accept CSV as hard-coded input file path
2. Parse employee records
3. Ignore invalid rows
4. Sort employees by salary descending
5. Print top 5 employees

### Non-functional
1. Support files up to 100,000 rows
2. Complete processing in under 3 seconds

## Acceptance Criteria

Given:

EmployeeId,Name,Salary
1,Alice,5000
2,Bob,8000
3,John,6000

When:

dotnet run employees.csv

Then:

Bob 8000
John 6000
Alice 5000