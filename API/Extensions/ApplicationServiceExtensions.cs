using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public  static class ApplicationServiceExtensions
    {
         public static IServiceCollection AddAppliationServices(this IServiceCollection services,IConfiguration _config )
    {
        services.AddScoped<ITokenService ,TokenService >();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
            });

            return services;

    }
   
        
    }
}