using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.DTOs.Ip;
using TopNewsApi.Core.DTOs.Post;

namespace TopNewsApi.Core.Validation.Ip
{
    public class CreateIPValidation : AbstractValidator<DashboardAccessDTO>
    {
        public CreateIPValidation()
        {
            RuleFor(da => da.IpAddress).NotEmpty();
        }
    }
}
