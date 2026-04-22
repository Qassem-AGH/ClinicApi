using MediatR;

namespace ClinicApi.Application.Features.Appointments.Commands.DeleteAppointment;

public record DeleteAppointmentCommand(int Id) : IRequest;