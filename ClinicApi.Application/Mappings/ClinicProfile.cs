using AutoMapper;
using ClinicApi.Application.DTOs;
using ClinicApi.Domain.Entities;

namespace ClinicApi.Application.Mappings;

public class ClinicProfile : Profile
{
    public ClinicProfile()
    {
        CreateMap<Doctor, DoctorDto>();
        CreateMap<Patient, PatientDto>();
        CreateMap<Appointment, AppointmentDto>()
            .ForMember(d => d.DoctorName, o => o.MapFrom(s => s.Doctor.FullName))
            .ForMember(d => d.PatientName, o => o.MapFrom(s => s.Patient.FullName))
            .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));
    }
}