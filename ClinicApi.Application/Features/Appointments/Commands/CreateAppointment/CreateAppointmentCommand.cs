using ClinicApi.Application.DTOs;
using MediatR;

namespace ClinicApi.Application.Features.Appointments.Commands.CreateAppointment;

public record CreateAppointmentCommand(
    DateTime ScheduledAt,
    string Notes,
    int DoctorId,
    int PatientId) : IRequest<AppointmentDto>;