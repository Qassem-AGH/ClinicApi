using AutoMapper;
using ClinicApi.Application.DTOs;
using ClinicApi.Domain.Entities;
using ClinicApi.Domain.Interfaces;
using MediatR;

namespace ClinicApi.Application.Features.Doctors.Queries.GetAllDoctors;

public class GetAllDoctorsHandler(IRepository<Doctor> repo, IMapper mapper)
    : IRequestHandler<GetAllDoctorsQuery, IEnumerable<DoctorDto>>
{
    public async Task<IEnumerable<DoctorDto>> Handle(
        GetAllDoctorsQuery request, CancellationToken ct)
    {
        var doctors = await repo.GetAllAsync();
        return mapper.Map<IEnumerable<DoctorDto>>(doctors);
    }
}