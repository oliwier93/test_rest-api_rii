using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Enums;
using EmployeeManagement.Domain.Repositories;

namespace EmployeeManagement.Tests.Domain.Repository
{
    public class InMemoryEmployeeRepositoryTests
{
    [Fact]
    public void Add_ShouldAddEmployee()
    {
        // Arrange
        var repository = new InMemoryEmployeeRepository();
        var employee = new Employee("Nowak", Gender.Male, "00000001");

        // Act
        repository.Add(employee);

        // Assert
        var result = repository.GetById(employee.Id);
        Assert.Equal(employee, result);
    }

    [Fact]
    public void GetById_ShouldThrowException_WhenEmployeeDoesNotExist()
    {
        // Arrange
        var repository = new InMemoryEmployeeRepository();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => repository.GetById(Guid.NewGuid()));
    }

    [Fact]
    public void Update_ShouldUpdateEmployee()
    {
        // Arrange
        var repository = new InMemoryEmployeeRepository();
        var employee = new Employee("Nowak", Gender.Male, "00000001");
        repository.Add(employee);

        // Act
        employee.Update("Kowalski", Gender.Female);
        repository.Update(employee);

        // Assert
        var updatedEmployee = repository.GetById(employee.Id);
        Assert.Equal("Kowalski", updatedEmployee.LastName);
        Assert.Equal(Gender.Female, updatedEmployee.Gender);
    }
}
}