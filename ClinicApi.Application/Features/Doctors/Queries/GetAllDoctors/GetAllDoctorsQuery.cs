using ClinicApi.Application.DTOs;
using MediatR;

namespace ClinicApi.Application.Features.Doctors.Queries.GetAllDoctors;

public record GetAllDoctorsQuery : IRequest<IEnumerable<DoctorDto>>;