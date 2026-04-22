using FluentValidation;

namespace ClinicApi.Application.Features.Appointments.Commands.CreateAppointment;

public class CreateAppointmentValidator : AbstractValidator<CreateAppointmentCommand>
{
    public CreateAppointmentValidator()
    {
        RuleFor(x => x.ScheduledAt).GreaterThan(DateTime.Now);
        RuleFor(x => x.DoctorId).GreaterThan(0);
        RuleFor(x => x.PatientId).GreaterThan(0);
    }
}