using Application.DTOs;
using FluentValidation;

namespace Application.Validator
{
    public sealed class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone is required")
                .Matches(@"^(?:\+966|0)5\d{8}$")
                .WithMessage("Invalid Phone number. Format: +9665XXXXXXXX or 05XXXXXXXX");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches("[0-9]").WithMessage("Password must contain at least one digit")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character");

            RuleFor(x => x.CheckPassword)
                .Equal(x => x.Password)
                .WithMessage("Passwords do not match");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email format");

            RuleFor(x => x.Message)
                .MaximumLength(500).WithMessage("Message must be less than 500 characters long")
                .Matches(@"^[a-zA-Z0-9\s.,!?]+$").WithMessage("Message contains invalid characters")
                .When(x => !string.IsNullOrEmpty(x.Message));
        }
    }
}
