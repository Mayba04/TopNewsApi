using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.DTOs.Roles;
using TopNewsApi.Core.DTOs.User;
using TopNewsApi.Core.Entities.Roles;
using TopNewsApi.Core.Entities.User;

namespace TopNewsApi.Core.Services
{
    public class RolesService
    {
        private readonly RoleManager<IdentityRole> _rolesManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public RolesService(RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration configuration)
        {
            _rolesManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;

        }

        public async Task<ServiceResponse> GetAllRolesAsync()
        {
            List<IdentityRole> roles = _rolesManager.Roles.ToList();

            List<RolesDTO> mappedUsers = roles.Select(u => _mapper.Map<IdentityRole, RolesDTO>(u)).ToList();

            return new ServiceResponse
            {
                Success = true,
                Message = "All roles loaded.",
                Payload = mappedUsers
            };
        }
    }
}
