using AutoMapper;
using ClinicApi.Application.DTOs;
using ClinicApi.Domain.Entities;
using ClinicApi.Domain.Interfaces;
using MediatR;

namespace ClinicApi.Application.Features.Patients.Queries.GetAllPatients;

public class GetAllPatientsHandler(IRepository<Patient> repo, IMapper mapper)
    : IRequestHandler<GetAllPatientsQuery, IEnumerable<PatientDto>>
{
    public async Task<IEnumerable<PatientDto>> Handle(
        GetAllPatientsQuery request, CancellationToken ct)
    {
        var patients = await repo.GetAllAsync();
        return mapper.Map<IEnumerable<PatientDto>>(patients);
    }
}