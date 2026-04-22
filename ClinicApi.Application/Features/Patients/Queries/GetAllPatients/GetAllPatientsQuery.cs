using ClinicApi.Application.DTOs;
using MediatR;

namespace ClinicApi.Application.Features.Patients.Queries.GetAllPatients;

public record GetAllPatientsQuery : IRequest<IEnumerable<PatientDto>>;