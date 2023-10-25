using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.DTOs.User;

namespace TopNewsApi.Core.Validation.User
{
    public class CreateUserValidation: AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidation()
        {
            RuleFor(r => r.FirstName).MinimumLength(2).NotEmpty().MaximumLength(12);
            RuleFor(r => r.LastName).MinimumLength(2).NotEmpty().MaximumLength(12);
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.Role).NotEmpty();
            RuleFor(r => r.Password).NotEmpty().WithMessage("Filed must not be empty")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");
            RuleFor(r => r.ConfirmPassword).NotEmpty().WithMessage("Filed must not be empty").
                MinimumLength(6).WithMessage("Password must be at least 6 characters").
                Equal(p => p.Password).WithMessage("The verification password is incorrect");
            RuleFor(r => r.PhoneNumber).NotEmpty();
        }
    }
   
}
