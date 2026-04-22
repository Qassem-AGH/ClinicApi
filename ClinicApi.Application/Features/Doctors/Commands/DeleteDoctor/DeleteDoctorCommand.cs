using MediatR;

namespace ClinicApi.Application.Features.Doctors.Commands.DeleteDoctor;

public record DeleteDoctorCommand(int Id) : IRequest;