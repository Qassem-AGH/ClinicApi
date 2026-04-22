using ClinicApi.Domain.Entities;
using ClinicApi.Domain.Interfaces;
using MediatR;

namespace ClinicApi.Application.Features.Appointments.Commands.DeleteAppointment;

public class DeleteAppointmentHandler(IRepository<Appointment> repo)
    : IRequestHandler<DeleteAppointmentCommand>
{
    public async Task Handle(DeleteAppointmentCommand cmd, CancellationToken ct)
    {
        var appointment = await repo.GetByIdAsync(cmd.Id)
            ?? throw new KeyNotFoundException($"Appointment {cmd.Id} not found");
        repo.Delete(appointment);
        await repo.SaveChangesAsync();
    }
}