using ClinicApi.Application.Features.Patients.Commands.CreatePatient;
using ClinicApi.Application.Features.Patients.Commands.DeletePatient;
using ClinicApi.Application.Features.Patients.Commands.UpdatePatient;
using ClinicApi.Application.Features.Patients.Queries.GetAllPatients;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PatientsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll() =>
        Ok(await mediator.Send(new GetAllPatientsQuery()));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePatientCommand cmd)
    {
        var result = await mediator.Send(cmd);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePatientCommand cmd) =>
        Ok(await mediator.Send(cmd with { Id = id }));

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeletePatientCommand(id));
        return NoContent();
    }
}