using ClinicApi.Application.Features.Appointments.Commands.CreateAppointment;
using ClinicApi.Application.Features.Appointments.Commands.DeleteAppointment;
using ClinicApi.Application.Features.Appointments.Queries.GetAllAppointments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AppointmentsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await mediator.Send(new GetAllAppointmentsQuery()));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAppointmentCommand cmd)
    {
        var result = await mediator.Send(cmd);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteAppointmentCommand(id));
        return NoContent();
    }
}