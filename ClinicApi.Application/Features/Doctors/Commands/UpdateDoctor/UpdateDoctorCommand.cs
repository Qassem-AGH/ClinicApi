using ClinicApi.Application.DTOs;
using MediatR;

namespace ClinicApi.Application.Features.Doctors.Commands.UpdateDoctor;

public record UpdateDoctorCommand(int Id, string FullName, string Specialty, string Phone)
    : IRequest<DoctorDto>;