using ClinicApi.Domain.Entities;
using ClinicApi.Domain.Interfaces;
using MediatR;

namespace ClinicApi.Application.Features.Patients.Commands.DeletePatient;

public class DeletePatientHandler(IRepository<Patient> repo)
    : IRequestHandler<DeletePatientCommand>
{
    public async Task Handle(DeletePatientCommand cmd, CancellationToken ct)
    {
        var patient = await repo.GetByIdAsync(cmd.Id)
            ?? throw new KeyNotFoundException($"Patient {cmd.Id} not found");
        repo.Delete(patient);
        await repo.SaveChangesAsync();
    }
}