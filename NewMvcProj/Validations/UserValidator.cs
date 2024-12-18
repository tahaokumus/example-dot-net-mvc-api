using FluentValidation;
using NewMvcProj.Models;

namespace NewMvcProj.Validations;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Id)
            .NotNull()
            .NotEmpty()
            .Length(6);

        RuleFor(user => user.UserName)
            .NotNull()
            .NotEmpty()
            .Must(name => name?.ToLower() != "erdal");

        RuleFor(user => user.Password)
            .NotNull()
            .NotEmpty()
            .Length(6, 15);

        RuleFor(user => user.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress();

        RuleFor(user => user.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .Length(10)
            .Must(number => number?.Length > 0 && number[0] == '+');

        RuleFor(user => user.BirthDate)
            .NotNull()
            .NotEmpty()
            .LessThanOrEqualTo(_ => new DateTime(2000, 1, 1))
            .WithMessage("Çoluk çocukla işimiz olmaz");
        
        RuleFor(user => user.CountryCode)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);
    }
}
