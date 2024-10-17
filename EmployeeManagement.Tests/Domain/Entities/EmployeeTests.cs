using Moq;

using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Enums;
using EmployeeManagement.Domain.Services;

public class EmployeeTests
{
    [Fact]
    public void Employee_ShouldGenerateNewRegistryNumber_WhenCreated()
    {
        // Arrange
        var registryNumberGeneratorMock = new Mock<IRegistryNumberGenerator>();
        registryNumberGeneratorMock.Setup(r => r.GenerateNext()).Returns("00000001");

        // Act
        var employee = new Employee("Kowalski", Gender.Male, "00000001", registryNumberGeneratorMock.Object);

        // Assert
        Assert.Equal("00000001", employee.RegistryNumber);
    }

    [Fact]
    public void Employee_ShouldThrowException_WhenLastNameIsInvalid()
    {
        // Arrange
        var registryNumberGeneratorMock = new Mock<IRegistryNumberGenerator>();
        registryNumberGeneratorMock.Setup(r => r.GenerateNext()).Returns("00000001");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Employee("", Gender.Male, "00000001", registryNumberGeneratorMock.Object));
    }

    [Fact]
    public void Employee_ShouldThrowException_WhenGenderIsInvalid()
    {
        // Arrange
        var registryNumberGeneratorMock = new Mock<IRegistryNumberGenerator>();
        registryNumberGeneratorMock.Setup(r => r.GenerateNext()).Returns("00000001");
        var invalidGender = (Gender)100;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Employee("Kowalski", invalidGender, "00000001", registryNumberGeneratorMock.Object));
    }

    [Fact]
    public void Employee_ShouldUpdateLastNameAndGender()
    {
        // Arrange
        var registryNumberGeneratorMock = new Mock<IRegistryNumberGenerator>();
        registryNumberGeneratorMock.Setup(r => r.GenerateNext()).Returns("00000001");
        var employee = new Employee("Kowalski", Gender.Male, "00000001", registryNumberGeneratorMock.Object);

        // Act
        employee.Update("Nowak", Gender.Female);

        // Assert
        Assert.Equal("Nowak", employee.LastName);
        Assert.Equal(Gender.Female, employee.Gender);
    }
}
