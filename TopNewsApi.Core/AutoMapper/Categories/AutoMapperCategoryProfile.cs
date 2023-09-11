using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.DTOs.Category;
using TopNewsApi.Core.Entities;

namespace TopNewsApi.Core.AutoMapper.Categories
{
    public class AutoMapperCategoryProfile: Profile
    {
        public AutoMapperCategoryProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
