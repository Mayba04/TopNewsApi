using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.DTOs.Login;

namespace TopNewsApi.Core.Validation.User
{
    public class LoginUserValidation: AbstractValidator<LoginDTO>
    {
        public LoginUserValidation()
        {
            RuleFor(r => r.Email).NotEmpty().WithMessage("Filed must not be empty")
                .EmailAddress().WithMessage("Invalid email format.");
            
            RuleFor(r => r.Password).NotEmpty().WithMessage("Filed must not be empty")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");
            
        }
    }
}
