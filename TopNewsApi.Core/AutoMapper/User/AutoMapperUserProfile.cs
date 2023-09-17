﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.DTOs.User;
using TopNewsApi.Core.Entities.User;

namespace TopNewsApi.Core.AutoMapper.User
{
    public class AutoMapperUserProfile: Profile
    {
        public AutoMapperUserProfile()
        {
            CreateMap<UserDTO, AppUser>().ReverseMap();
            //CreateMap<UpdateUserDTO, AppUser>().ReverseMap();
            //CreateMap<CreateUserDTO, AppUser>().ForMember(dst => dst.UserName, act => act.MapFrom(src => src.Email));
            //CreateMap<AppUser, CreateUserDTO>();
        }
    }
}
