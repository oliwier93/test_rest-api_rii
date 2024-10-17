using Microsoft.AspNetCore.Mvc;

using EmployeeManagement.Api.Dtos;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Services;
using EmployeeManagement.Domain.Repositories;


namespace EmployeeManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRegistryNumberGenerator _registryNumberGenerator;
        private readonly InMemoryEmployeeRepository _employeeRepository;

        public EmployeeController(IRegistryNumberGenerator registryNumberGenerator, InMemoryEmployeeRepository employeeRepository)
        {
            _registryNumberGenerator = registryNumberGenerator;
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeCreateDto dto)
        {
            var employee = new Employee(dto.LastName, dto.Gender, _registryNumberGenerator.GenerateNext());
            _employeeRepository.Add(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(Guid id, [FromBody] EmployeeUpdateDto dto)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.Update(dto.LastName, dto.Gender);
            _employeeRepository.Update(employee);

            return NoContent();
        }
    }
}