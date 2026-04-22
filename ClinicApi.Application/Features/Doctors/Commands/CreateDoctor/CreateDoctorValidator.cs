using FluentValidation;

namespace ClinicApi.Application.Features.Doctors.Commands.CreateDoctor;

public class CreateDoctorValidator : AbstractValidator<CreateDoctorCommand>
{
    public CreateDoctorValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Specialty).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(20);
    }
}