using AutoMapper;
using ClinicApi.Application.DTOs;
using ClinicApi.Domain.Entities;
using ClinicApi.Domain.Interfaces;
using MediatR;

namespace ClinicApi.Application.Features.Appointments.Commands.CreateAppointment;

public class CreateAppointmentHandler(IRepository<Appointment> repo, IMapper mapper)
    : IRequestHandler<CreateAppointmentCommand, AppointmentDto>
{
    public async Task<AppointmentDto> Handle(CreateAppointmentCommand cmd, CancellationToken ct)
    {
        var appointment = new Appointment
        {
            ScheduledAt = cmd.ScheduledAt,
            Notes = cmd.Notes,
            DoctorId = cmd.DoctorId,
            PatientId = cmd.PatientId,
            Status = AppointmentStatus.Pending
        };
        await repo.AddAsync(appointment);
        await repo.SaveChangesAsync();
        return mapper.Map<AppointmentDto>(appointment);
    }
}