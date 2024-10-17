using Microsoft.AspNetCore.Mvc;
using MediatR;

using EmployeeManagement.Api.Dtos;
using EmployeeManagement.Domain.Commands;

namespace EmployeeManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDto dto)
        {
            var command = new CreateEmployeeCommand(dto.LastName, dto.Gender);
            var employee = await _mediator.Send(command);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] EmployeeUpdateDto dto)
        {
            var command = new UpdateEmployeeCommand(id, dto.LastName, dto.Gender);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
