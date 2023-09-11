using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.DTOs.Post;
using TopNewsApi.Core.Entities;

namespace TopNewsApi.Core.AutoMapper.Posts
{
    public class AutoMapperPostProfile: Profile
    {
        public AutoMapperPostProfile()
        {
            CreateMap<Post, PostDTO>().ReverseMap();
        }
    }
}
