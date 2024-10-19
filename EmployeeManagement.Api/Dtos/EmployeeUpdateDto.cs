using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Api.Dtos
{
    public record EmployeeUpdateDto(string LastName, Gender Gender);
}