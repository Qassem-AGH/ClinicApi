using ClinicApi.Application.DTOs;
using MediatR;

namespace ClinicApi.Application.Features.Patients.Commands.CreatePatient;

public record CreatePatientCommand(
    string FullName,
    string Email,
    string Phone,
    DateOnly DateOfBirth) : IRequest<PatientDto>;