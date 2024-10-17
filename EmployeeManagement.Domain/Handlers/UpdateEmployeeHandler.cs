using MediatR;
using EmployeeManagement.Domain.Repositories;
using EmployeeManagement.Domain.Commands;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _employeeRepository.GetById(request.Id);
            if (employee == null)
            {
                throw new InvalidOperationException("Employee not found.");
            }

            employee.Update(request.LastName, request.Gender);
            _employeeRepository.Update(employee);

            return Task.FromResult(employee);
        }
    }
}
