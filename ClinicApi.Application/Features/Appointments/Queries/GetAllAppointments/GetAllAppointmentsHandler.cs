using AutoMapper;
using ClinicApi.Application.DTOs;
using ClinicApi.Domain.Entities;
using ClinicApi.Domain.Interfaces;
using MediatR;

namespace ClinicApi.Application.Features.Appointments.Queries.GetAllAppointments;

public class GetAllAppointmentsHandler(IRepository<Appointment> repo, IMapper mapper)
    : IRequestHandler<GetAllAppointmentsQuery, IEnumerable<AppointmentDto>>
{
    public async Task<IEnumerable<AppointmentDto>> Handle(
        GetAllAppointmentsQuery request, CancellationToken ct)
    {
        var appointments = await repo.GetAllAsync();
        return mapper.Map<IEnumerable<AppointmentDto>>(appointments);
    }
}