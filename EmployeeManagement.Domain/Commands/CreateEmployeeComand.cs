using MediatR;

using EmployeeManagement.Domain.Enums;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Commands
{
    public class CreateEmployeeCommand : IRequest<Employee>
{
    public string LastName { get; }
    public Gender Gender { get; }

    public CreateEmployeeCommand(string lastName, Gender gender)
    {
        LastName = lastName;
        Gender = gender;
    }
}
}