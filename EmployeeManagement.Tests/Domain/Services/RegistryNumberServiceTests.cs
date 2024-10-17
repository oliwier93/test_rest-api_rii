using EmployeeManagement.Domain.Services;

public class RegistryNumberGeneratorTests
{
    [Fact]
    public void GenerateNext_ShouldReturnFirstNumber_WhenNoExistingNumbers()
    {
        // Arrange
        var existingNumbers = new List<string>();
        var generator = new RegistryNumberGenerator(existingNumbers);

        // Act
        var newNumber = generator.GenerateNext();

        // Assert
        Assert.Equal("00000001", newNumber);
    }

    [Fact]
    public void GenerateNext_ShouldReturnNextNumber_WhenExistingNumbers()
    {
        // Arrange
        var existingNumbers = new List<string> { "00000001", "00000002", "00000003" };
        var generator = new RegistryNumberGenerator(existingNumbers);

        // Act
        var newNumber = generator.GenerateNext();

        // Assert
        Assert.Equal("00000004", newNumber);
    }

    [Fact]
    public void GenerateNext_ShouldHandleLargeNumbers()
    {
        // Arrange
        var existingNumbers = new List<string> { "00009999" };
        var generator = new RegistryNumberGenerator(existingNumbers);

        // Act
        var newNumber = generator.GenerateNext();

        // Assert
        Assert.Equal("00010000", newNumber);
    }

    [Fact]
    public void GenerateNext_ShouldThrowException_WhenInvalidNumberExists()
    {
        // Arrange
        var existingNumbers = new List<string> { "invalidNumber" };
        var generator = new RegistryNumberGenerator(existingNumbers);

        // Act & Assert
        Assert.Throws<System.FormatException>(() => generator.GenerateNext());
    }

    [Fact]
    public void GenerateNext_ShouldReturnFirstNumber_WhenExistingNumbersIsNull()
    {
        // Arrange
        List<string> existingNumbers = null!;
        var generator = new RegistryNumberGenerator(existingNumbers);

        // Act
        var newNumber = generator.GenerateNext();

        // Assert
        Assert.Equal("00000001", newNumber);
    }

    [Fact]
    public void GenerateNext_ShouldGenerateUniqueNumbersInMultithreadedEnvironment()
    {
        // Arrange
        var existingNumbers = new List<string> { "00000001", "00000002", "00000003" };
        var generator = new RegistryNumberGenerator(existingNumbers);
        var generatedNumbers = new List<string>();
        var lockObject = new object();

        // Act
        Parallel.For(0, 10, i =>
        {
            var nextNumber = generator.GenerateNext();
            lock (lockObject)
            {
                generatedNumbers.Add(nextNumber);
            }
        });

        // Assert
        Assert.Equal(10, generatedNumbers.Distinct().Count());
    }
}
