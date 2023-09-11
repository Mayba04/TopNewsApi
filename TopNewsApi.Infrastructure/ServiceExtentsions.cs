using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.Entities.User;
using TopNewsApi.Core.Interfaces;
using TopNewsApi.Infrastructure.Context;
using TopNewsApi.Infrastructure.Repository;
using TopNewsApi.Core.Entities.User;

namespace TopNewsApi.Infrastructure
{
    public static class ServiceExtentsions
    {
        public static void AddDbCotext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(opt => 
            {
                opt.UseSqlServer(connectionString);
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        public static void AddInfastructuresServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(options => 
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6 ;
                options.Password.RequireNonAlphanumeric = true;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>().
            AddDefaultTokenProviders();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
