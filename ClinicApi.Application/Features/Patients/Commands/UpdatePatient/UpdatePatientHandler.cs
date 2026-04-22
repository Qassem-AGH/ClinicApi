using AutoMapper;
using ClinicApi.Application.DTOs;
using ClinicApi.Domain.Entities;
using ClinicApi.Domain.Interfaces;
using MediatR;

namespace ClinicApi.Application.Features.Patients.Commands.UpdatePatient;

public class UpdatePatientHandler(IRepository<Patient> repo, IMapper mapper)
    : IRequestHandler<UpdatePatientCommand, PatientDto>
{
    public async Task<PatientDto> Handle(UpdatePatientCommand cmd, CancellationToken ct)
    {
        var patient = await repo.GetByIdAsync(cmd.Id)
            ?? throw new KeyNotFoundException($"Patient {cmd.Id} not found");
        patient.FullName = cmd.FullName;
        patient.Email = cmd.Email;
        patient.Phone = cmd.Phone;
        patient.DateOfBirth = cmd.DateOfBirth;
        repo.Update(patient);
        await repo.SaveChangesAsync();
        return mapper.Map<PatientDto>(patient);
    }
}