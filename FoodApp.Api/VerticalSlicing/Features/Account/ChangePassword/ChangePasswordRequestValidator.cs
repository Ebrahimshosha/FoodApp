﻿using FluentValidation;

namespace FoodApp.Api.VerticalSlicing.Features.Account.ChangePassword
{
    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("A valid email is required");

            RuleFor(x => x.CurrentPassword)
               .NotEmpty().WithMessage("CurrentPassword is required");

            RuleFor(x => x.NewPassword)
              .NotEmpty().WithMessage("Password is required.")
              .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
              .WithMessage("Password must be at least 8 characters long, and include at least one uppercase letter, one lowercase letter, one digit, and one special character");

        }

    }
}
