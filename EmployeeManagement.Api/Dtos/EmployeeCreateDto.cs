using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Api.Dtos
{
    public record EmployeeCreateDto(string LastName, Gender Gender);
}