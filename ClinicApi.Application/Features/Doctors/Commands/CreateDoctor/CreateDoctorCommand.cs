using ClinicApi.Application.DTOs;
using MediatR;

namespace ClinicApi.Application.Features.Doctors.Commands.CreateDoctor;

public record CreateDoctorCommand(string FullName, string Specialty, string Phone)
    : IRequest<DoctorDto>;