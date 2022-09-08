using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Helpers;
using API.interfaces;
using API.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public  static class ApplicationServiceExtensions
    {
         public static IServiceCollection AddAppliationServices(this IServiceCollection services,IConfiguration _config )
    {
        services.Configure<CloudinarySettings>(_config.GetSection("CloudinarySettings"));
        
        services.AddScoped<ITokenService ,TokenService >();
        services.AddScoped<IPhotoService , PhotoService>();
        services.AddScoped<LogUserActivity>();
        services.AddScoped<IUserRepository , UserRepository>();
        services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
            });

            return services;

    }
   
        
    }
}