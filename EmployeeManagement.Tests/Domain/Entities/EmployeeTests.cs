using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Enums;

public class EmployeeTests
{
    [Fact]
    public void Employee_ShouldGenerateNewRegistryNumber_WhenCreated()
    {
        // Arrange
        var registryNumber = "00000001";

        // Act
        var employee = new Employee("Kowalski", Gender.Male, registryNumber);

        // Assert
        Assert.Equal("00000001", employee.RegistryNumber);
    }

    [Fact]
    public void Employee_ShouldThrowException_WhenLastNameIsInvalid()
    {
        // Arrange
        var registryNumber = "00000001";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Employee("", Gender.Male, registryNumber));
    }

    [Fact]
    public void Employee_ShouldThrowException_WhenGenderIsInvalid()
    {
        // Arrange
        var registryNumber = "00000001";
        var invalidGender = (Gender)100;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Employee("Kowalski", invalidGender, registryNumber));
    }

    [Fact]
    public void Employee_ShouldUpdateLastNameAndGender()
    {
        // Arrange
        var registryNumber = "00000001";
        var employee = new Employee("Kowalski", Gender.Male, registryNumber);

        // Act
        employee.Update("Nowak", Gender.Female);

        // Assert
        Assert.Equal("Nowak", employee.LastName);
        Assert.Equal(Gender.Female, employee.Gender);
    }
}
