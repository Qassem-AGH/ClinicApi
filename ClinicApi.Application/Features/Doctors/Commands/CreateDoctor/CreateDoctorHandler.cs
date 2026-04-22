using AutoMapper;
using ClinicApi.Application.DTOs;
using ClinicApi.Domain.Entities;
using ClinicApi.Domain.Interfaces;
using MediatR;

namespace ClinicApi.Application.Features.Doctors.Commands.CreateDoctor;

public class CreateDoctorHandler(IRepository<Doctor> repo, IMapper mapper)
    : IRequestHandler<CreateDoctorCommand, DoctorDto>
{
    public async Task<DoctorDto> Handle(CreateDoctorCommand cmd, CancellationToken ct)
    {
        var doctor = new Doctor
        {
            FullName = cmd.FullName,
            Specialty = cmd.Specialty,
            Phone = cmd.Phone
        };
        await repo.AddAsync(doctor);
        await repo.SaveChangesAsync();
        return mapper.Map<DoctorDto>(doctor);
    }
}