using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.DTOs.User;

namespace TopNewsApi.Core.Validation.User
{
    public class UpdatePasswordValidation: AbstractValidator<UpdatePasswordDTO>
    {
        public UpdatePasswordValidation()
        {
            RuleFor(r => r.OldPassword).MinimumLength(6).NotEmpty();
            RuleFor(r => r.NewPassword).MinimumLength(6).NotEmpty();
            RuleFor(r => r.ConfirmPassword).MinimumLength(6).Equal(r => r.NewPassword);
        }
    }
}
