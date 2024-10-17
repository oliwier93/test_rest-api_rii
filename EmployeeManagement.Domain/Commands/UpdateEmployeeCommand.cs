using MediatR;

using EmployeeManagement.Domain.Enums;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Commands
{
    public class UpdateEmployeeCommand : IRequest<Employee>
    {
        public Guid Id { get; }
        public string LastName { get; }
        public Gender Gender { get; }

        public UpdateEmployeeCommand(Guid id, string lastName, Gender gender)
        {
            Id = id;
            LastName = lastName;
            Gender = gender;
        }
    }
}