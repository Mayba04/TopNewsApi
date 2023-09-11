using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.DTOs.User;

namespace TopNewsApi.Core.Validation.User
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserValidation()
        {
            RuleFor(r => r.FirstName).NotEmpty();
            RuleFor(r => r.LastName).NotEmpty();
            RuleFor(r => r.Email).NotEmpty();
            RuleFor(r => r.PhoneNumber).NotEmpty();
        }
    }
}
