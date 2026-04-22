using ClinicApi.Application.Features.Doctors.Commands.CreateDoctor;
using ClinicApi.Application.Features.Doctors.Commands.DeleteDoctor;
using ClinicApi.Application.Features.Doctors.Commands.UpdateDoctor;
using ClinicApi.Application.Features.Doctors.Queries.GetAllDoctors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DoctorsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await mediator.Send(new GetAllDoctorsQuery()));

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] CreateDoctorCommand cmd)
    {
        var result = await mediator.Send(cmd);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDoctorCommand cmd) =>
        Ok(await mediator.Send(cmd with { Id = id }));

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteDoctorCommand(id));
        return NoContent();
    }
}