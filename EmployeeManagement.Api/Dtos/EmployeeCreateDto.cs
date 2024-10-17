using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Api.Dtos
{
    public class EmployeeCreateDto
    {
        public required string LastName { get; set; }
        public Gender Gender { get; set; }
    }
}