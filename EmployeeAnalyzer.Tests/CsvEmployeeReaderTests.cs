using EmployeeAnalyzer;

namespace EmployeeAnalyzer.Tests;

public class CsvEmployeeReaderTests
{
    private readonly CsvEmployeeReader _reader;

    public CsvEmployeeReaderTests()
    {
        _reader = new CsvEmployeeReader();
    }

    [Fact]
    public void Read_ValidCsvFile_ReturnsEmployees()
    {
        var tempFile = Path.GetTempFileName();
        File.WriteAllText(tempFile, @"EmployeeId,Name,Salary
1,Alice,5000
2,Bob,8000
3,John,6000");

        try
        {
            var result = _reader.Read(tempFile);

            Assert.Equal(3, result.Count);
            Assert.Equal("Alice", result[0].Name);
            Assert.Equal(5000, result[0].Salary);
            Assert.Equal("Bob", result[1].Name);
            Assert.Equal(8000, result[1].Salary);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [Fact]
    public void Read_FileNotFound_ThrowsFileNotFoundException()
    {
        Assert.Throws<FileNotFoundException>(() => _reader.Read("nonexistent.csv"));
    }

    [Fact]
    public void Read_InvalidRows_IgnoresThem()
    {
        var tempFile = Path.GetTempFileName();
        File.WriteAllText(tempFile, @"EmployeeId,Name,Salary
1,Alice,5000
invalid,row,data
2,Bob,8000");

        try
        {
            var result = _reader.Read(tempFile);

            Assert.Equal(2, result.Count);
            Assert.Equal("Alice", result[0].Name);
            Assert.Equal("Bob", result[1].Name);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [Fact]
    public void Read_EmptyFile_ReturnsEmptyList()
    {
        var tempFile = Path.GetTempFileName();
        File.WriteAllText(tempFile, "EmployeeId,Name,Salary");

        try
        {
            var result = _reader.Read(tempFile);

            Assert.Empty(result);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }
}
