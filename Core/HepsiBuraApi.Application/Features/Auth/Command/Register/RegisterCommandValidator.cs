using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuraApi.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator:AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2)
                .WithMessage("FullName is required.");
           
            RuleFor(x => x.Email).NotEmpty()
                .MaximumLength(60)
                .WithMessage("Email is required.")
                .EmailAddress()
                .MinimumLength(8)
                .WithMessage("Invalid email format.");
            
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");
            
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Confirm Password is required.")
                .Equal(x => x.Password)
                .WithMessage("Passwords do not match.");
        }
    }
}
