using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopNewsApi.Core.Entities.Roles
{
    public class AppRoles : IdentityUser
    {
        public string Id { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
