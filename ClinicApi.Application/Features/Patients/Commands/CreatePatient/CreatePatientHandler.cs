using AutoMapper;
using ClinicApi.Application.DTOs;
using ClinicApi.Domain.Entities;
using ClinicApi.Domain.Interfaces;
using MediatR;

namespace ClinicApi.Application.Features.Patients.Commands.CreatePatient;

public class CreatePatientHandler(IRepository<Patient> repo, IMapper mapper)
    : IRequestHandler<CreatePatientCommand, PatientDto>
{
    public async Task<PatientDto> Handle(CreatePatientCommand cmd, CancellationToken ct)
    {
        var patient = new Patient
        {
            FullName = cmd.FullName,
            Email = cmd.Email,
            Phone = cmd.Phone,
            DateOfBirth = cmd.DateOfBirth
        };
        await repo.AddAsync(patient);
        await repo.SaveChangesAsync();
        return mapper.Map<PatientDto>(patient);
    }
}