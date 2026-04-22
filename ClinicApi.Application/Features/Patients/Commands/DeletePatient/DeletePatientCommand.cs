using MediatR;

namespace ClinicApi.Application.Features.Patients.Commands.DeletePatient;

public record DeletePatientCommand(int Id) : IRequest;