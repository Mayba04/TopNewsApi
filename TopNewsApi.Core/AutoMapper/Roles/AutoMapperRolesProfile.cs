using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.DTOs.Roles;
using TopNewsApi.Core.DTOs.User;
using TopNewsApi.Core.Entities.Roles;
using TopNewsApi.Core.Entities.User;

namespace TopNewsApi.Core.AutoMapper.Roles
{
    public class AutoMapperRolesProfile: Profile
    {
        public AutoMapperRolesProfile()
        {
            CreateMap<RolesDTO, IdentityRole>().ReverseMap();
            //CreateMap<UpdateUserDTO, AppUser>().ReverseMap();
            //CreateMap<CreateUserDTO, AppUser>().ForMember(dst => dst.UserName, act => act.MapFrom(src => src.Email));
            //CreateMap<AppUser, CreateUserDTO>();
        }
    }
}
