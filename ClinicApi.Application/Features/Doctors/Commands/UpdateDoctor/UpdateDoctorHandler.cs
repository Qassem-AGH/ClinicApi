using AutoMapper;
using ClinicApi.Application.DTOs;
using ClinicApi.Domain.Entities;
using ClinicApi.Domain.Interfaces;
using MediatR;

namespace ClinicApi.Application.Features.Doctors.Commands.UpdateDoctor;

public class UpdateDoctorHandler(IRepository<Doctor> repo, IMapper mapper)
    : IRequestHandler<UpdateDoctorCommand, DoctorDto>
{
    public async Task<DoctorDto> Handle(UpdateDoctorCommand cmd, CancellationToken ct)
    {
        var doctor = await repo.GetByIdAsync(cmd.Id)
            ?? throw new KeyNotFoundException($"Doctor {cmd.Id} not found");
        doctor.FullName = cmd.FullName;
        doctor.Specialty = cmd.Specialty;
        doctor.Phone = cmd.Phone;
        repo.Update(doctor);
        await repo.SaveChangesAsync();
        return mapper.Map<DoctorDto>(doctor);
    }
}