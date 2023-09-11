using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.AutoMapper.Categories;
using TopNewsApi.Core.AutoMapper.Ip;
using TopNewsApi.Core.AutoMapper.Posts;
using TopNewsApi.Core.AutoMapper.User;
using TopNewsApi.Core.Interfaces;
using TopNewsApi.Core.Services;

namespace TopNewsApi.Core
{
    public static class ServiceExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<UserService>();
            services.AddTransient<EmailServices>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IDashdoardAccessService, DashboardAccsessService>();
        }

        public static void AddMapping(this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(AutoMapperUserProfile));
            services.AddAutoMapper(typeof(AutoMapperCategoryProfile));
            services.AddAutoMapper(typeof(AutoMapperPostProfile));
            services.AddAutoMapper(typeof(AutoMapperDashboardAccsessProfile));
        }
    }
}
