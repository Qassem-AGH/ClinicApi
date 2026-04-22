using ClinicApi.Application.DTOs;
using MediatR;

namespace ClinicApi.Application.Features.Appointments.Queries.GetAllAppointments;

public record GetAllAppointmentsQuery : IRequest<IEnumerable<AppointmentDto>>;
