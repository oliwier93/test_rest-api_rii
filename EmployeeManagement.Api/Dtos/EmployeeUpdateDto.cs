using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Api.Dtos
{
    public class EmployeeUpdateDto
    {
        public required string LastName { get; set; }
        public Gender Gender { get; set; }
    }
}