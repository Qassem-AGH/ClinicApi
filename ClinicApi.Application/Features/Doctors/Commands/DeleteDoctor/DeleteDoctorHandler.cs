using ClinicApi.Domain.Entities;
using ClinicApi.Domain.Interfaces;
using MediatR;

namespace ClinicApi.Application.Features.Doctors.Commands.DeleteDoctor;

public class DeleteDoctorHandler(IRepository<Doctor> repo)
    : IRequestHandler<DeleteDoctorCommand>
{
    public async Task Handle(DeleteDoctorCommand cmd, CancellationToken ct)
    {
        var doctor = await repo.GetByIdAsync(cmd.Id)
            ?? throw new KeyNotFoundException($"Doctor {cmd.Id} not found");
        repo.Delete(doctor);
        await repo.SaveChangesAsync();
    }
}