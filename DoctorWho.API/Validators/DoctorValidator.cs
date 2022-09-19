using DoctorWho.Db.Entities;
using FluentValidation;

namespace DoctorWho.API.Validators;

public class DoctorValidator : AbstractValidator<Doctor>
{
    public DoctorValidator()
    {
        RuleFor(doctor => doctor.DoctorName).NotEmpty();
        RuleFor(doctor => doctor.DoctorNumber).NotEmpty();
        RuleFor(doctor => doctor.LastEpisodeDate).GreaterThanOrEqualTo(doctor => doctor.FirstEpisodeDate)
            .WithMessage("Last Episode date should be greater than First Episode date");
        RuleFor(doctor => doctor.LastEpisodeDate)
            .Null().When(doctor => doctor.FirstEpisodeDate == default)
            .WithMessage("LastEpisodeDate can't have a value when FirstEpisodeDate is empty");
    }
}