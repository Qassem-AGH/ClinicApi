using ClinicApi.Application.DTOs;
using MediatR;

namespace ClinicApi.Application.Features.Patients.Commands.UpdatePatient;

public record UpdatePatientCommand(
    int Id,
    string FullName,
    string Email,
    string Phone,
    DateOnly DateOfBirth) : IRequest<PatientDto>;