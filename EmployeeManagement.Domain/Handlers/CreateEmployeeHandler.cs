using MediatR;

using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Repositories;
using EmployeeManagement.Domain.Services;
using EmployeeManagement.Domain.Commands;

namespace EmployeeManagement.Domain.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IRegistryNumberGenerator _registryNumberGenerator;

    public CreateEmployeeHandler(IEmployeeRepository employeeRepository, IRegistryNumberGenerator registryNumberGenerator)
    {
        _employeeRepository = employeeRepository;
        _registryNumberGenerator = registryNumberGenerator;
    }

    public Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var registryNumber = _registryNumberGenerator.GenerateNext();
        var employee = new Employee(request.LastName, request.Gender, registryNumber);

        _employeeRepository.Add(employee);

        return Task.FromResult(employee);
    }
}
}